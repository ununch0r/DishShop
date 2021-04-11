import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { City } from '../models/city.model'
import { Country } from '../models/country.model';
import { ValueType } from '../models/value-type.model';

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

    getAllCountries(): Observable<Country[]>{
        const endpoint = this.endpoint  + '/countries'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'GET')

        return this.http.get<Country[]>(endpoint, {headers: headers});
    }

    getAllValueTypes(): Observable<ValueType[]>{
        const endpoint = this.endpoint  + '/value-types'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'GET')

        return this.http.get<ValueType[]>(endpoint, {headers: headers});
    }


    createProducer(body): Observable<any>{
        const endpoint = this.endpoint  + '/producers'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')

        return this.http.post(endpoint,body, {headers: headers});
    }

    createCountry(body): Observable<any>{
        const endpoint = this.endpoint  + '/countries'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')

        return this.http.post(endpoint,body, {headers: headers});
    }

    createCity(body): Observable<any>{
        const endpoint = this.endpoint  + '/cities'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')

        return this.http.post(endpoint,body, {headers: headers});
    }

    createCharacteristic(body): Observable<any>{
        const endpoint = this.endpoint  + '/characteristics'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')

        return this.http.post(endpoint, body, {headers: headers});
    }

    createValueType(body): Observable<any>{
        const endpoint = this.endpoint  + '/value-types'
        const headers = this.headers.append('Access-Control-Allow-Methods', 'POST')

        return this.http.post(endpoint, body, {headers: headers});
    }
}