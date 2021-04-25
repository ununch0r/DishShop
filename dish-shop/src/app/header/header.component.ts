import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../http-services/auth.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
    public authService : AuthService,
    public userService : UserService,
    private router : Router
    ) { }

  ngOnInit(): void {
  }

  logout(){
    this.authService.logout();
    this.router.navigate(['auth']);
  }

}
