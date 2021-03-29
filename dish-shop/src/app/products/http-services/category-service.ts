import { Injectable } from '@angular/core';
import { Category } from '../../models/category.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class CategoryService{
    endpoint : string;

    constructor(public http: HttpClient){
        this.endpoint = 'https://localhost:44310/api/categories'
    }

    getAllCategories(): Observable<Category[]>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'GET')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.get<Category[]>(this.endpoint, {headers: headers});
    }

    createCategory(body) : Observable<Category>{
        const headers = new HttpHeaders()
        .append('Content-Type', 'application/json')
        .append('Access-Control-Allow-Headers', 'Content-Type')
        .append('Access-Control-Allow-Methods', 'POST')
        .append('Access-Control-Allow-Origin', '*');

        return this.http.post<Category>(this.endpoint,body,{headers: headers})
    }
}