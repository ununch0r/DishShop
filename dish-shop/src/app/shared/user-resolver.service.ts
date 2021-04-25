import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Employee } from '../models/employee.model';
import { UserService } from '../user.service'

@Injectable({providedIn: 'root'})
export class UserResolverService implements Resolve<Employee>{
    constructor(private userService: UserService){}

    resolve(route : ActivatedRouteSnapshot, state : RouterStateSnapshot){
        let user = this.userService.currentEmployee;
        if(user === undefined)
        {
            return this.userService.getCurrentUser();
        }
        else{
            return user;
        }
    }
}