import { Injectable } from '@angular/core';
import { Characteristic } from '../../models/characteristic.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class CharacteristicService{
    endpoint : string;

    characteristics : Characteristic[] =[];

    constructor(public http: HttpClient){
        this.endpoint = 'https://localhost:44310/api/characteristics';
        this.getAllCharacteristics().subscribe(
            (data) => {
                this.characteristics = data;
            }
        )
    }

    getSavedCharacteristics():Characteristic[]{
        return this.characteristics.slice();
    }

    getAllCharacteristics(): Observable<Characteristic[]>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'GET')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.get<Characteristic[]>(this.endpoint, {headers: headers});
    }

    createCharacteristic(body) : Observable<Characteristic>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'POST')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.post<Characteristic>(this.endpoint,body,{headers: headers})
    }
}