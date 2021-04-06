import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShopAvailability } from 'src/app/models/shop-availability.model';

@Component({
  selector: 'app-availability-item',
  templateUrl: './availability-item.component.html',
  styleUrls: ['./availability-item.component.css']
})
export class AvailabilityItemComponent implements OnInit {
  @Input() availability : ShopAvailability

  constructor(private router : Router) { }

  ngOnInit(): void {
  }

  showInCatalog(){
    this.router.navigate(['products', this.availability.product.id])
  }

}
