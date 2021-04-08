import { Injectable } from '@angular/core';
import { Provider } from '../../models/provider.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ProviderService{
    endpoint : string;

    constructor(public http: HttpClient){
        this.endpoint = 'https://localhost:44310/api/providers'
    }

    getAllProviders(): Observable<Provider[]>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'GET')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.get<Provider[]>(this.endpoint, {headers: headers});
    }

    createProvider(body) : Observable<Provider>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'POST')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.post<Provider>(this.endpoint,body,{headers: headers})
    }
}