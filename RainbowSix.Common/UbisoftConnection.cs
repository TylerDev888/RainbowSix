using RainbowSix.Common.Enums;
using RainbowSix.Common.Interfaces;
using RainbowSix.Common.Models;
using RainbowSix.Common.Models.Response;
using RainbowSix.WebClient;
using RainbowSix.WebClient.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RainbowSix.Common
{
    public enum UbisoftPlatform
    {
        PC,
        PSN,
        XBL
    }
    public class UbisoftConnection : IDisposable
    {
        private readonly HttpConnection _httpConnection;
        private readonly IUbisoftSessionStore _sessionStore;
        public UbisoftConnection(
            IHttpConnectionLogger logger,
            IUbisoftSessionStore sessionStore)
        {
            _httpConnection = new HttpConnection(logger, new Uri(UbisoftPublicAPI.Domain.ToString()));
            _sessionStore = sessionStore;
        }

        public async Task<IUbisoftSession> Authenticate(string username, string password, Func<string> get2faCodeEntry)
        {
            var session = _sessionStore.LoadSessionByUsername(username);

            if (session.IsSessionExpired())
            {
                session = await LoginAsync(username, password);

                if (session.Is2faRequired())
                {
                    var code = get2faCodeEntry();
                    session = await CompleteTwoFactorAsync(session!.TwoFactorAuthenticationTicket!, code);
                }

                _sessionStore.SaveSession(username, session);
            }

            if (session == null || string.IsNullOrEmpty(session.Ticket))
            {
                throw new Exception("Failed to authenticate with Ubisoft. No ticket returned.");
            }

            return session;
        }
        public async Task<IUbisoftSession?> LoginAsync(string username, string password)
        {
            try
            {
                var requestData = new
                {
                    rememberMe = true,
                    email = username,
                    password = password
                };
               
                SetLoginHeaders(username, password);

                var endpoint = $"{UbisoftPublicAPI.Domain}{UbisoftPublicAPI.Auth}";
                return await _httpConnection.PostAsJsonAsync<object, UbisoftAuthResponseModel>(
                    endpoint, requestData);
            }
            catch (Exception ex)
            {
                throw new Exception("Ubisoft login failed", ex);
            }
        }

        public async Task<IUbisoftSession?> CompleteTwoFactorAsync(string twoFactorTicket, string code)
        {
            try
            {
                var requestData = new
                {
                    twoFactorAuthenticationTicket = twoFactorTicket,
                    code = code
                };

                SetTwoFaHeaders(twoFactorTicket, code);

                var endpoint = $"{UbisoftPublicAPI.Domain}{UbisoftPublicAPI.Auth}";
                return  await _httpConnection.PostAsJsonAsync<object, UbisoftAuthResponseModel>(
                    endpoint, requestData);
            }
            catch (Exception ex)
            {
                throw new Exception("Ubisoft 2fa failed", ex);
            }
        }
        public async Task<MarketableItemsModel?> GetBuyableItemsAsync(IUbisoftSession session, int limit = 40, int offset = 0)
        {
            if (session == null)
                throw new Exception("Not authenticated. Please authenticate first.");

            var batch = GraphQLBatchBuilder.BuildBatch(
                GraphQLBuilder.QueryMarketPlaceItems(MarketPlaceItemQueryType.Buy, limit, offset)
            );

            var data = await SendGraphQLRequestAsync(session, batch);

            if (data == null)
            {
                _sessionStore.DeleteSession(session.Username ?? "");
                throw new Exception("Failed to retrieve marketable items.");
            }
            return data[0]
                .Data?
                .Game?
                .MarketableItems;
        }
        public async Task<MarketableItemsModel?> GetSellableItemsAsync(IUbisoftSession session, int limit = 40, int offset  = 0)
        {
            if (session == null)
                throw new Exception("Not authenticated. Please authenticate first.");

            var batch = GraphQLBatchBuilder.BuildBatch(
                GraphQLBuilder.QueryMarketPlaceItems(MarketPlaceItemQueryType.Sell, limit, offset)
            );

            var data = await SendGraphQLRequestAsync(session, batch);

            if (data == null)
            {
                _sessionStore.DeleteSession(session.Username ?? "");
                throw new Exception("Failed to retrieve sellable items.");
            }
            return data[0]
                .Data?
                .Game?
                .Viewer?
                .Meta?
                .MarketableItems;
        }

        public async Task<List<GraphQLResponse<GameDataModel>>?> SendGraphQLRequestAsync(
            IUbisoftSession session,
            IEnumerable<object> batchOperations)
        {
            SetSessionHeaders(session);

            var result = await _httpConnection.PostAsJsonAsync<
                IEnumerable<object>,
                List<GraphQLResponse<GameDataModel>>
            >($"{UbisoftPublicAPI.Domain}{UbisoftPublicAPI.MarketPlace}", batchOperations);

            return result[0]?.Data is not null ? result : null;
        }

        private void SetSessionHeaders(IUbisoftSession session)
        {
            var headers = new Dictionary<string, string>();

            headers["apollographql-client-version"] = "1.66.0";

            if (!string.IsNullOrEmpty(session.Ticket))
                headers["Authorization"] = $"ubi_v1 t={session.Ticket}";

            headers["Content-Type"] = "application/json";
            headers["Ubi-Appid"] = UbisoftVariables.AppId.ToString();
            headers["Ubi-Countryid"] = "CA";
            headers["Ubi-Localecode"] = "en-US";
            headers["Ubi-Profileid"] = session.ProfileId;
            headers["Ubi-Regionid"] = "WW";
            headers["Ubi-Sessionid"] = session.SessionId;
            headers["X-Platform-Appid"] = UbisoftVariables.XPlatformAppId.ToString();
            headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36";

            _httpConnection.ClearRequestHeaders();
            _httpConnection.SetRequestHeaders(headers);
        }

        private void SetAuthHeaders(
            string? username = null, 
            string? password = null,
            string? twoFaTicket = null, 
            string? twoFaCode = null)
        {
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Ubi-Appid", UbisoftVariables.AppId.ToString() },
                { "Ubi-RequestedPlatformType", "uplay" },
                { "Genomeid", UbisoftVariables.GenomeId.ToString() },
                { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36" }
            };

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                headers["Authorization"] = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"))}";

            if (!string.IsNullOrEmpty(twoFaTicket) && !string.IsNullOrEmpty(twoFaCode))
            {
                headers["Authorization"] = $"ubi_2fa_v1 t={twoFaTicket}";
                headers["Ubi-2facode"] = twoFaCode;
            }

            _httpConnection.ClearRequestHeaders();
            _httpConnection.SetRequestHeaders(headers);
        }

        private void SetLoginHeaders(string username, string password) =>
            SetAuthHeaders(username: username, password: password);

        private void SetTwoFaHeaders(string twoFaTicket, string twoFaCode) =>
            SetAuthHeaders(twoFaTicket: twoFaTicket, twoFaCode: twoFaCode);

        public void Dispose()
        {
            _httpConnection.Dispose();
        }
    }
}
