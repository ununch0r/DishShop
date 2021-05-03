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
import { ShopDetailComponent } from './shops/shop-detail/shop-detail.component';
import { ShopsResolverService } from './shops/resolvers/shops-resolver.service';
import { EmployeeService } from './shops/http-services/employee.servise';
import { EmployeeListComponent } from './shops/employee-list/employee-list.component';
import { EmployeeItemComponent } from './shops/employee-list/employee-item/employee-item.component';
import { SupplyListComponent } from './shops/supply-list/supply-list.component';
import { SupplyItemComponent } from './shops/supply-list/supply-item/supply-item.component';
import { AvailabilityListComponent } from './shops/availability-list/availability-list.component';
import { AvailabilityItemComponent } from './shops/availability-list/availability-item/availability-item.component';
import { EmployeeEditComponent } from './shops/employee-edit/employee-edit.component';
import { SupplyService } from './http-services/supply.service'
import { ProviderService } from './providers/http-services/provider.service'
import { ProvidersResolverService } from './providers/resolvers/providers-resolver.service'
import { SuppliesResolverService } from './supplies/resolvers/supplies-resolver.service'
import { ProvidersStateService } from './providers/providers-state.service'
import { TruncatePipe } from './pipes/truncate.pipe';
import { ShopEditComponent } from './shops/shop-edit/shop-edit.component';
import { UtilitiesService } from './http-services/utilities.service';
import { ContractService } from './providers/http-services/contract.service';
import { ProvidersComponent } from './providers/providers.component';
import { ProviderListComponent } from './providers/provider-list/provider-list.component';
import { ProviderEditComponent } from './providers/provider-edit/provider-edit.component';
import { ContractListComponent } from './providers/contract-list/contract-list.component';
import { ContractItemComponent } from './providers/contract-list/contract-item/contract-item.component';
import { ProviderItemComponent } from './providers/provider-list/provider-item/provider-item.component';
import { ContractEditComponent } from './providers/contract-list/contract-edit/contract-edit.component';
import { ContractDetailComponent } from './providers/contract-detail/contract-detail.component';
import { SuppliesComponent } from './supplies/supplies.component';
import { SuppliesStateService } from './supplies/supplies-state-service';
import { SupplyDetailComponent } from './supplies/supply-detail/supply-detail.component';
import { SupplyEditComponent } from './supplies/supply-edit/supply-edit.component';
import { SuppliesListComponent } from './supplies/supplies-list/supplies-list.component';
import { SuppliesItemComponent } from './supplies/supplies-list/supplies-item/supplies-item.component';
import { StartComponent } from './start/start.component';
import { UtilitiesComponent } from './utilities/utilities.component';
import { JwtModule } from '@auth0/angular-jwt';
import {HomeComponent} from './home/home.component'
import {AuthComponent} from './auth/auth.component'
import { environment } from 'src/environments/environment';
import {ACCESS_TOKEN_KEY} from './http-services/auth.service';
import { StatisticsComponent } from './statistics/statistics.component';
import { StatisticItemComponent } from './statistics/statistic-item/statistic-item.component';
import { SupplyStatisticComponent } from './statistics/statistic-item/supply-statistic/supply-statistic.component';
import { AvailabilityStatisticComponent } from './statistics/statistic-item/availability-statistic/availability-statistic.component';

export function tokenGetter(){
  return localStorage.getItem(ACCESS_TOKEN_KEY)
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProductListComponent,
    ProductItemComponent,
    ProductEditComponent,
    ProductDetailComponent,
    ProductsComponent,
    ConfirmationDialogComponent,
    ShopsComponent,
    ShopListComponent,
    ShopItemComponent,
    ShopDetailComponent,
    EmployeeListComponent,
    EmployeeItemComponent,
    SupplyListComponent,
    SupplyItemComponent,
    AvailabilityListComponent,
    AvailabilityItemComponent,
    EmployeeEditComponent,
    TruncatePipe,
    ShopEditComponent,
    ProvidersComponent,
    ProviderListComponent,
    ProviderEditComponent,
    ContractListComponent,
    ContractItemComponent,
    ProviderItemComponent,
    ContractEditComponent,
    ContractDetailComponent,
    SuppliesComponent,
    SupplyDetailComponent,
    SupplyEditComponent,
    SuppliesListComponent,
    SuppliesItemComponent,
    StartComponent,
    UtilitiesComponent,
    HomeComponent,
    AuthComponent,
    StatisticsComponent,
    StatisticItemComponent,
    SupplyStatisticComponent,
    AvailabilityStatisticComponent
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
    NgbModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: ['localhost:44310']
      }
    })
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
    EmployeeService,
    UtilitiesService,
    SupplyService,
    ProviderService,
    ProvidersStateService,
    ProvidersResolverService,
    ContractService,
    SuppliesStateService,
    SuppliesResolverService
    ],
  bootstrap: [AppComponent],
  entryComponents: [ ConfirmationDialogComponent ]
})
export class AppModule { }
