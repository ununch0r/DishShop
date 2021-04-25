import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { UserService } from 'src/app/user.service';
import { ProductService } from '../http-services/product.service';
import { ProductsStateService } from '../products-state.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {
  productsSubscription : Subscription;
  products : Product[];

  constructor(
    private productService: ProductsStateService,
    public userService : UserService
    ) { }

  ngOnDestroy(): void {
    this.productsSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.products = this.productService.getProducts();
    this.productsSubscription = this.productService.productsCollectionChanged.subscribe(
      data => {
        this.products = data;
      }
    );
  }

}
