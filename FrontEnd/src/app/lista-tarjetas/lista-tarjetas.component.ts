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
  enableEdit = false;
  enableEditIndex = null;
  constructor(public tarjetaService:TarjetaService, public toastr:ToastrService) { }

  ngOnInit(): void {
    this.tarjetaService.obtenerTarjetas(); 
  }
  eliminarTarjeta(id){
   if(confirm('Desea eliminar la tarjeta?')){
   const index = this.tarjetaService.list.indexOf(id);
    this.tarjetaService.list.splice(index,1);
    //  this.tarjetaService.eliminarTarjeta(id).subscribe(data=>{
    //    this.toastr.warning('Eliminar Exitoso', 'Tarjeta Eliminada');

    //    this.tarjetaService.obtenerTarjetas();
    //  })
   }
  }
  editar(tarjeta){
    this.tarjetaService.actualizar(tarjeta);
  }
  enableEditMethod(e, i) {
    this.enableEdit = true;
    this.enableEditIndex = i;
    console.log(i, e);
  }

}
