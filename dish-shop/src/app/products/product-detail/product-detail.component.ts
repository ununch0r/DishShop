import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { UserService } from 'src/app/user.service';
import { ProductsStateService } from '../products-state.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit, OnDestroy {
  product: Product;
  id : number;
  subscriptions : Subscription = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private productService: ProductsStateService,
    private router: Router,
    public userService : UserService
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit(): void {
    this.subscriptions.add(this.activatedRoute.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.product = this.productService.getProduct(this.id);
      }
    ));

    this.subscriptions.add(this.productService.productsCollectionChanged.subscribe(
      () => {
        this.product = this.productService.getProduct(this.id);
      }
    ));
  }

  onEdit(){
    this.router.navigate(['edit'], {relativeTo: this.activatedRoute});
  }
}
