import { Component, Input, OnInit } from '@angular/core';
import { ShopAvailability } from 'src/app/models/shop-availability.model';

@Component({
  selector: 'app-availability-statistic',
  templateUrl: './availability-statistic.component.html',
  styleUrls: ['./availability-statistic.component.css']
})
export class AvailabilityStatisticComponent implements OnInit {
  @Input() availability : ShopAvailability

  constructor() { }

  ngOnInit(): void {
  }

}
