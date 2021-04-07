import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Position } from 'src/app/models/position.model';
import { EmployeeService } from '../http-services/employee.servise';
import { ShopsStateService } from '../shops-state.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  subscriptions : Subscription[] = [];
  id: number;
  employeeForm : FormGroup;
  positions : Position[] = [];

  constructor(
    private route: ActivatedRoute,
    private router : Router,
    private employeeService : EmployeeService,
    private shopsService : ShopsStateService
  ) { }

  ngOnDestroy(): void {
    this.subscriptions.forEach(
      subscription => subscription.unsubscribe()
    );
  }


  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.initForm();
      }
    )

    this.subscriptions.push(
      this.employeeService.getAllPositions().subscribe(
        positions => this.positions = positions
      )
    );
  }

  private initForm(){
    this.employeeForm = new FormGroup({
      'firstName' : new FormControl(null, [Validators.required]),
      'lastName' : new FormControl(null, [Validators.required]),
      'positionId' : new FormControl(null, [Validators.required]),
      'email' : new FormControl(null, [Validators.required]),
      'phoneNumber' : new FormControl(null, [Validators.required]),
      'passwordHash' : new FormControl(null, [Validators.required]),
      'shopId' : new FormControl(this.id, [Validators.required])
    });
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  onSubmit(){
    this.employeeService.addEmployee(this.employeeForm.value);
    this.router.navigate(['../'], {relativeTo: this.route})
    this.shopsService.fetchShops();
  }
}
