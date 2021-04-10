import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ShopsStateService } from '../shops/shops-state.service';
import { NotificationService } from '../notification.service';
import { Supply } from '../models/supply.model';
import { SuppliesStateService } from '../supplies/supplies-state-service';

@Injectable()
export class SupplyService{
    endpoint : string;
    subscriptions : Subscription[] = []

    headers = new HttpHeaders()
    .append('Content-Type', 'application/json')
    .append('Access-Control-Allow-Headers', 'Content-Type')
    .append('Access-Control-Allow-Origin', '*');

    constructor(
        public http: HttpClient,
        public shopsService : ShopsStateService,
        private notifyService : NotificationService
        ){
        this.endpoint = 'https://localhost:44310/api/supplies'
    }

    cancelSupply(id : number){
        const endpoint = this.endpoint + '/' + id + '/cancel';
        const headers = this.headers.append('Access-Control-Allow-Methods', 'PUT');

        return this.http.put(endpoint,{headers: headers});
    }

    receiveSupply(id : number){
        const endpoint = this.endpoint + '/' + id + '/receive';
        const headers = this.headers.append('Access-Control-Allow-Methods', 'PUT');
        
        return this.http.put(endpoint,{headers: headers})
    }

    getAllSupplies(): Observable<Supply[]>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'GET')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.get<Supply[]>(this.endpoint, {headers: headers});
    }

    createSupply(body) : Observable<Supply>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'POST')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.post<Supply>(this.endpoint,body,{headers: headers})
    }
}