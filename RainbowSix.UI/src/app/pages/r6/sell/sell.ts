
import { AfterViewInit, Component, OnDestroy, OnInit } from "@angular/core";
import { AppSettings } from '../../../service/app-settings.service';
import { R6ApiService } from "../../../service/r6-api.service";
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'sell',
  templateUrl: './sell.html',
  standalone: false
})

export class SellComponent implements OnInit {

  sellableItems = [];

  constructor(
    public appSettings: AppSettings,
    public r6ApiService: R6ApiService
  ) {

  }
  ngOnInit(): void {
    console.log("RAN")
    this.r6ApiService.getSellableItems()
      .subscribe({
        next: (items) => {
          this.sellableItems = items;
          console.log('Fetched sellable items:', this.sellableItems);
        },
        error: (err) => {
          console.error('Error fetching sellable items:', err);
        }
      });
  }
}

export class SellItem {

}
