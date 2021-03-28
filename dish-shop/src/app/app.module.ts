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
import { ProductService  } from './products/product.service';
import { CategoryService  } from './products/http-services/category-service';
import { CharacteristicService  } from './products/http-services/characteristic-service';
import { ProducerService  } from './products/http-services/producer.service';
import { ProductsResolverService  } from './products/products-resolver.service';
import { CharacteristicResolverService  } from './products/resolvers/characteristic-resolver.service';
import { ProductsStateService  } from './products/products-state.service';
import { ProductStartComponent } from './products/product-start/product-start.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProductListComponent,
    ProductItemComponent,
    ProductEditComponent,
    ProductDetailComponent,
    ProductsComponent,
    ProductStartComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule 
  ],
  providers: [
    ProductService,
    ProductsStateService,
    ProductsResolverService,
    CategoryService,
    ProducerService,
    CharacteristicService,
    CharacteristicResolverService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
