import { Injectable } from '@angular/core';
import { Shop } from '../../models/shop.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ShopService{
    endpoint : string;

    constructor(public http: HttpClient){
        this.endpoint = 'https://localhost:44310/api/shops'
    }

    getAllShops(): Observable<Shop[]>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'GET')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.get<Shop[]>(this.endpoint, {headers: headers});
    }

    createShop(body) : Observable<Shop>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'POST')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.post<Shop>(this.endpoint,body,{headers: headers})
    }
}