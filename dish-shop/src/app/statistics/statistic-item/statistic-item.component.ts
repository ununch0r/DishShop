import { Component, Input, OnInit } from '@angular/core';
import { Shop } from 'src/app/models/shop.model';

@Component({
  selector: 'app-statistic-item',
  templateUrl: './statistic-item.component.html',
  styleUrls: ['./statistic-item.component.css']
})
export class StatisticItemComponent implements OnInit {
  @Input() shop : Shop
  @Input() index : number


  constructor() { }

  ngOnInit(): void {
  }

}
