import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { City } from '../models/city.model'

@Injectable()
export class UtilitiesService{
    endpoint : string;
    subscriptions : Subscription[] = []

    headers = new HttpHeaders()
    .append('Content-Type', 'application/json')
    .append('Access-Control-Allow-Headers', 'Content-Type')
    .append('Access-Control-Allow-Origin', '*');

    constructor(
        public http: HttpClient){
        this.endpoint = 'https://localhost:44310/api/utilities'
    }

    getAllCities(): Observable<City[]>{
        const endpoint = this.endpoint  + '/cities'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'GET')

        return this.http.get<City[]>(endpoint, {headers: headers});
    }
}