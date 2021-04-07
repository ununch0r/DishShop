import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShopNestedEmployee } from 'src/app/models/shop-nested-models/shop-nested-employee.model';
import { EmployeeService } from '../../http-services/employee.servise';

@Component({
  selector: 'app-employee-item',
  templateUrl: './employee-item.component.html',
  styleUrls: ['./employee-item.component.css']
})
export class EmployeeItemComponent implements OnInit {
  @Input() employee : ShopNestedEmployee
  @Input() index : number

  constructor(
    private employeeService: EmployeeService,
    private router : Router,
    private route : ActivatedRoute
    ) { }

  ngOnInit(): void {
  }

  onPromote(){
    this.employeeService.promoteEmployee(this.index);
  }

  onFire(){
    this.employeeService.fireEmployee(this.index);
  }

}
