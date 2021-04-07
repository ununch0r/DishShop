import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http'
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module'

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductItemComponent } from './products/product-list/product-item/product-item.component';
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { ProductsComponent } from './products/products.component';
import { ProductService  } from './products/http-services/product.service';
import { CategoryService  } from './products/http-services/category.service';
import { ShopService  } from './shops/http-services/shop.service';
import { ShopsStateService  } from './shops/shops-state.service';
import { CharacteristicService  } from './products/http-services/characteristic.service';
import { ProducerService  } from './products/http-services/producer.service';
import { ProductsResolverService  } from './products/resolvers/products-resolver.service';
import { CharacteristicResolverService  } from './products/resolvers/characteristic-resolver.service';
import { ProductsStateService  } from './products/products-state.service';
import { ProductStartComponent } from './products/product-start/product-start.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ConfirmationDialogService } from './confirmation-dialog/confirmation-dialog.service';
import { ToastrModule } from 'ngx-toastr';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ShopsComponent } from './shops/shops.component';
import { ShopListComponent } from './shops/shop-list/shop-list.component';
import { ShopItemComponent } from './shops/shop-list/shop-item/shop-item.component';
import { ShopStartComponent } from './shops/shop-start/shop-start.component';
import { ShopDetailComponent } from './shops/shop-detail/shop-detail.component';
import { ShopsResolverService } from './shops/resolvers/shops-resolver.service';
import { EmployeeService } from './shops/http-services/employee.servise';
import { EmployeeListComponent } from './shops/employee-list/employee-list.component';
import { EmployeeItemComponent } from './shops/employee-list/employee-item/employee-item.component';
import { SupplyListComponent } from './shops/supply-list/supply-list.component';
import { SupplyItemComponent } from './shops/supply-list/supply-item/supply-item.component';
import { AvailabilityListComponent } from './shops/availability-list/availability-list.component';
import { AvailabilityItemComponent } from './shops/availability-list/availability-item/availability-item.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProductListComponent,
    ProductItemComponent,
    ProductEditComponent,
    ProductDetailComponent,
    ProductsComponent,
    ProductStartComponent,
    ConfirmationDialogComponent,
    ShopsComponent,
    ShopListComponent,
    ShopItemComponent,
    ShopStartComponent,
    ShopDetailComponent,
    EmployeeListComponent,
    EmployeeItemComponent,
    SupplyListComponent,
    SupplyItemComponent,
    AvailabilityListComponent,
    AvailabilityItemComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    NgbModule
  ],
  providers: [
    ProductService,
    ProductsStateService,
    ProductsResolverService,
    CategoryService,
    ProducerService,
    CharacteristicService,
    CharacteristicResolverService,
    ConfirmationDialogService,
    ShopService,
    ShopsStateService,
    ShopsResolverService,
    EmployeeService
    ],
  bootstrap: [AppComponent],
  entryComponents: [ ConfirmationDialogComponent ]
})
export class AppModule { }
