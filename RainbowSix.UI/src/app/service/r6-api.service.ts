import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface SellableItem {
  id: number;
  name: string;
  price: number;
}

interface ApiResponse {
  success: boolean;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class R6ApiService {
  private baseUrl = 'http://localhost:5010'; // 🔹 API Endpoint

  constructor(private http: HttpClient) {}
  /**
   * POST request: Login
   */
  login(username: string, password: string): Observable<ApiResponse> {
    const body = { username, password };
    return this.http.post<ApiResponse>(`${this.baseUrl}/auth/login`, body);
  }

  /**
   * POST request: Two-factor authentication (2FA)
   */
  twoFactorAuth(userId: number, code: string): Observable<ApiResponse> {
    const body = { code };
    return this.http.post<ApiResponse>(`${this.baseUrl}/auth/2fa`, body);
  }
  /**
   * GET request: Fetch all sellable items
   */
  getSellableItems(): Observable<SellableItem[]> {
    return this.http.get<SellableItem[]>(`${this.baseUrl}/api/marketplace/sell?sessionId=d2735ee9-ff02-4ff4-9caa-bcbba7da7cf3&limit=40&offset=0`);
  }
}
