import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TarjetaCredito } from '../models/tarjetaCredito';
import { TarjetaService } from '../services/tarjeta.service';
import { TarjetasComponent } from '../tarjetas/tarjetas.component';

@Component({
  selector: 'app-lista-tarjetas',
  templateUrl: './lista-tarjetas.component.html',
  styleUrls: ['./lista-tarjetas.component.css']
})
export class ListaTarjetasComponent implements OnInit {

  constructor(public tarjetaService:TarjetaService, public toastr:ToastrService) { }

  ngOnInit(): void {
    this.tarjetaService.obtenerTarjetas(); 
  }
  eliminarTarjeta(id:number){
   if(confirm('Desea eliminar la tarjeta?')){
     this.tarjetaService.eliminarTarjeta(id).subscribe(data=>{
       this.toastr.warning('Eliminar Exitoso', 'Tarjeta Eliminada');

       this.tarjetaService.obtenerTarjetas();
     })
   }
  }

}
