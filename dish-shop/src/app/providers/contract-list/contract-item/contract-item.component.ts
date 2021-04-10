import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contract } from 'src/app/models/contract.model';

@Component({
  selector: 'app-contract-item',
  templateUrl: './contract-item.component.html',
  styleUrls: ['./contract-item.component.css']
})
export class ContractItemComponent implements OnInit {
  @Input() contract : Contract
  @Input() index : number

  constructor(
    private router : Router,
    private route : ActivatedRoute
    ) { }

  ngOnInit(): void {
  }

  onShowContent(){
  }

  onCreateSupply(){
    
  }
}
