import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-moneda',
  templateUrl: './moneda.component.html',
  styleUrls: ['./moneda.component.css']
})
export class MonedaComponent implements OnInit {
  selected ='option2';

  constructor() { }

  ngOnInit(): void {
  }

}
