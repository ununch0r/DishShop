import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ShopsStateService } from '../shops-state.service';
import { NotificationService } from '../../notification.service';

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

        this.subscriptions.push(this.http.put(endpoint,{headers: headers}).subscribe(
            () => {
                this.subscriptions.push(this.shopsService.fetchShops().subscribe(
                    shops => {
                        this.shopsService.reloadShops(shops);
                        this.notifyService.showSuccess("Supply was canceled", "Successfully canceled!");
                     },
                     error => this.notifyService.showError(error, "Error occured(")
                ));
            }
        ));
    }

    receiveSupply(id : number){
        const endpoint = this.endpoint + '/' + id + '/receive';
        const headers = this.headers.append('Access-Control-Allow-Methods', 'PUT');
        
        this.subscriptions.push(this.http.put(endpoint,{headers: headers}).subscribe(
            () => {
                this.subscriptions.push(this.shopsService.fetchShops().subscribe(
                    shops => {
                        this.shopsService.reloadShops(shops);
                        this.notifyService.showSuccess("Supply was reveived", "Successfully received!");
                     },
                     error => this.notifyService.showError(error, "Error occured(")
                ));
            }
        ));
    }
}