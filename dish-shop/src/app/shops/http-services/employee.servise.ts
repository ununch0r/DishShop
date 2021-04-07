import { Injectable } from '@angular/core';
import { ShopNestedEmployee } from '../../models/shop-nested-models/shop-nested-employee.model';
import { Observable, Subscription } from 'rxjs';
import { flatMap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ShopsStateService } from '../shops-state.service';
import { NotificationService } from 'src/app/notification.service';
import { Position } from 'src/app/models/position.model';

@Injectable()
export class EmployeeService{
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
        this.endpoint = 'https://localhost:44310/api/employees'
    }

    createEmployee(body) : Observable<ShopNestedEmployee>{
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')
        return this.http.post<ShopNestedEmployee>(this.endpoint,body,{headers: headers})
    }

    promoteEmployee(id : number){
        const endpoint = this.endpoint + '/' + id + '/promote'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')
        this.subscriptions.push(this.http.post<ShopNestedEmployee>(endpoint,{headers: headers}).subscribe(
            () => {
                this.subscriptions.push(this.shopsService.fetchShops().subscribe(
                    shops => {
                        this.shopsService.reloadShops(shops);
                        this.notifyService.showSuccess("Employee was promoted", "Successfully promoted!");
                     },
                     error => this.notifyService.showError(error, "Error occured(")
                ));
            }
        ));
    }

    fireEmployee(id : number){
        const endpoint = this.endpoint + '/' + id + '/fire'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')
        this.subscriptions.push(this.http.post<ShopNestedEmployee>(endpoint,{headers: headers}).subscribe(
            () => {
                this.subscriptions.push(this.shopsService.fetchShops().subscribe(
                    shops => {
                        this.shopsService.reloadShops(shops);
                        this.notifyService.showSuccess("Employee was fired", "Successfully fired!");
                     },
                     error => this.notifyService.showError(error, "Error occured(")
                ));
            }
        ));
    }

    getAllPositions(): Observable<Position[]>{
        const endpoint = this.endpoint  + '/positions'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'GET')

        return this.http.get<Position[]>(endpoint, {headers: headers});
    }

    addEmployee(body){
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')

        return this.http.post<ShopNestedEmployee>(this.endpoint,body,{headers: headers})
        .pipe (flatMap(() => this.shopsService.fetchShops()))
        .subscribe(
            data => {
                this.notifyService.showSuccess("Employee was added", "Successfully added!");
            },
            error => this.notifyService.showError(error, "Error occured(")
        )
    }
}