import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ProductService{
    endpoint : string;

    constructor(public http: HttpClient){
        this.endpoint = 'https://localhost:44310/api/products'
    }

    getAllProducts(): Observable<Product[]>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'GET')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.get<Product[]>(this.endpoint, {headers: headers});
    }

    createProduct(body) : Observable<Product>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'POST')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.post<Product>(this.endpoint,body,{headers: headers})
    }
}