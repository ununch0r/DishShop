import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  myForm:FormGroup;  
  constructor() { }

  ngOnInit(): void {
    this.myForm = new FormGroup({          
      'login':new FormControl(null,[Validators.email, Validators.required]),
      'password':new FormControl(null, Validators.required)
    })
  }

  onSubmit(){
    console.log(this.myForm.value);
  }
}
