import { Component, Input, OnInit } from '@angular/core';
import { ShopNestedEmployee } from 'src/app/models/shop-nested-models/shop-nested-employee.model';

@Component({
  selector: 'app-employee-item',
  templateUrl: './employee-item.component.html',
  styleUrls: ['./employee-item.component.css']
})
export class EmployeeItemComponent implements OnInit {
  @Input() employee : ShopNestedEmployee
  @Input() index : number

  constructor() { }

  ngOnInit(): void {
  }

}
