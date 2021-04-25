import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../http-services/auth.service';
import { NotificationService } from '../notification.service';
import { UserService } from '../user.service'

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  myForm:FormGroup;  
  constructor(
    private authService : AuthService,
    private router : Router,
    private userService : UserService,
    private notificationService : NotificationService
    ) { }

  ngOnInit(): void {
    this.myForm = new FormGroup({          
      'login':new FormControl(null,[Validators.email, Validators.required]),
      'password':new FormControl(null, Validators.required)
    })
  }

  onSubmit(){
    this.authService.login(this.myForm.value.login, this.myForm.value.password)
    .subscribe(
      success => {
        this.router.navigate(['']);
        this.userService.getAuthorizedUser();
      },
      error => {
        this.notificationService.showError('Wrong password or email!', 'Not authorized!');
      });
  }
}
