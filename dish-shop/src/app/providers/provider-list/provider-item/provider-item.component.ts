import { Component, Input, OnInit } from '@angular/core';
import { Provider } from 'src/app/models/provider.model';

@Component({
  selector: 'app-provider-item',
  templateUrl: './provider-item.component.html',
  styleUrls: ['./provider-item.component.css']
})
export class ProviderItemComponent implements OnInit {
  @Input() provider : Provider
  @Input() index : number

  constructor() { }

  ngOnInit(): void {
  }

}
