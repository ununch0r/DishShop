import { Component, Input, OnInit } from '@angular/core';
import { Shop } from 'src/app/models/shop.model';

@Component({
  selector: 'app-shop-item',
  templateUrl: './shop-item.component.html',
  styleUrls: ['./shop-item.component.css']
})
export class ShopItemComponent implements OnInit {
  @Input() shop : Shop
  @Input() index : number

  constructor() { }

  ngOnInit(): void {
  }

}
