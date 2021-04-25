import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Employee } from './models/employee.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  employeeSubject : BehaviorSubject<Employee> = new BehaviorSubject<Employee>(null);
  currentEmployee : Employee;
  endpoint : string;

  headers = new HttpHeaders()
  .append('Content-Type', 'application/json')
  .append('Access-Control-Allow-Headers', 'Content-Type')
  .append('Access-Control-Allow-Origin', '*');

  constructor(public http: HttpClient) {
    this.endpoint = 'https://localhost:44310/api/auth/user'
   }


  getCurrentUser(): Observable<Employee>{
    const headers = new HttpHeaders()
    .append('Content-Type', 'application/json')
    .append('Access-Control-Allow-Headers', 'Content-Type')
    .append('Access-Control-Allow-Methods', 'GET')
    .append('Access-Control-Allow-Origin', '*');

    return this.http.get<Employee>(this.endpoint, {headers: headers}).pipe(
      tap(user => this.currentEmployee = user)
    );
  }

  getAuthorizedUser() {
    this.getCurrentUser().subscribe(
      response => {
        this.currentEmployee = response;
        this.employeeSubject.next(response);
      }
    )
  }

  isUserAdmin() : boolean{
    return this.currentEmployee.position.name === 'Administrator';
  }

  isUserCurrentShopManagerOrAdmin(shopId : number) : boolean{
    const isAdmin = this.isUserAdmin();
    const isUserCurrentShopManager =  (this.isUserManager()
    && this.currentEmployee.shop.id === shopId);

    return isAdmin || isUserCurrentShopManager;
  }

  isUserManager() : boolean{
    return this.currentEmployee.position.name === 'Manager';
  }

  isUserManagerOrAdmin() : boolean{
    return this.currentEmployee.position.name === 'Manager' || this.currentEmployee.position.name === 'Administrator';
  }
}
