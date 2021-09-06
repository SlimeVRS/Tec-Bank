import { Component, OnInit } from '@angular/core';
import { TarjetaCredito } from '../models/tarjetaCredito';
import { TarjetasComponent } from '../tarjetas/tarjetas.component';

@Component({
  selector: 'app-lista-tarjetas',
  templateUrl: './lista-tarjetas.component.html',
  styleUrls: ['./lista-tarjetas.component.css']
})
export class ListaTarjetasComponent implements OnInit {

  constructor(public tarjetaCredito:TarjetasComponent) { }

  ngOnInit(): void {
    this.tarjetaCredito.data;
  }

}
