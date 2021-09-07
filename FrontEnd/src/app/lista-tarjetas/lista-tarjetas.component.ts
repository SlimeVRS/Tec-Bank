import { Component, OnInit } from '@angular/core';
import { TarjetaCredito } from '../models/tarjetaCredito';
import { TarjetaService } from '../tarjeta.service';
import { TarjetasComponent } from '../tarjetas/tarjetas.component';

@Component({
  selector: 'app-lista-tarjetas',
  templateUrl: './lista-tarjetas.component.html',
  styleUrls: ['./lista-tarjetas.component.css']
})
export class ListaTarjetasComponent implements OnInit {

  constructor(public tarjetaService:TarjetaService) { }

  ngOnInit(): void {
    this.tarjetaService.obtenerTarjetas(); 
  }

}
