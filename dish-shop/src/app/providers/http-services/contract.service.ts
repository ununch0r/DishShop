import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { flatMap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProvidersStateService } from '../providers-state.service';
import { NotificationService } from '../../notification.service';
import { Contract } from '../../models/contract.model';

@Injectable()
export class ContractService{
    endpoint : string;
    subscriptions : Subscription[] = []

    headers = new HttpHeaders()
    .append('Content-Type', 'application/json')
    .append('Access-Control-Allow-Headers', 'Content-Type')
    .append('Access-Control-Allow-Origin', '*');

    constructor(
        public http: HttpClient,
        public providersService : ProvidersStateService,
        private notifyService : NotificationService
        ){
        this.endpoint = 'https://localhost:44310/api/contracts'
    }

    createContract(body) : Observable<Contract>{
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')
        return this.http.post<Contract>(this.endpoint,body,{headers: headers})
    }

    addContract(body){
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')

        return this.http.post<Contract>(this.endpoint,body,{headers: headers})
        .pipe (flatMap(() => this.providersService.fetchProviders()))
        .subscribe(
            data => {
                this.notifyService.showSuccess("Contract was added", "Successfully added!");
            },
            error => this.notifyService.showError(error, "Error occured(")
        )
    }
}