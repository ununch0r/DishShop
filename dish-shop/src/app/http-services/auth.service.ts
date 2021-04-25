import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import {Token} from '../models/token'
import { tap } from 'rxjs/operators';

export const ACCESS_TOKEN_KEY = 'dishshop_access_token'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  endpoint : string;

  constructor(
    private http : HttpClient,
    private jwtHelper : JwtHelperService,
    private router : Router
  ) { 
    this.endpoint = "https://localhost:44310/";
  }

  login(email:string, password:string) : Observable<Token> {
    const endpoint = this.endpoint+'api/auth/login';
    return this.http.post<Token>(endpoint,{
      email, password
    }).pipe(
      tap(token => {
        localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token);
      })
    );

  }

  isAuthenticated() : boolean{
    var token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  logout() : void {
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    this.router.navigate(['']);
  }
}
