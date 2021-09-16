import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';
import { TarjetaCredito } from '../models/tarjetaCredito';
import { TarjetaService } from '../services/tarjeta.service';

//El componente tarjetas es el encargado de manejar
//formularios guardarTarjetas, editarTarjetas y borrar

@Component({
  selector: 'app-tarjetas',
  templateUrl: './tarjetas.component.html',
  styleUrls: ['./tarjetas.component.css']
})
//constructor del objecto tarjetas
export class TarjetasComponent implements OnInit {
  form: FormGroup;
  list: TarjetaCredito[];
  tarjeta: TarjetaCredito;
  idTarjeta: string;
  

  constructor(private formBuilder: FormBuilder, private tarjetaService: TarjetaService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      id: 0,
      nombre: ['', [Validators.required]],
      numeroTarjeta: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(16)]],
      tipoTarjeta: ['', [Validators.required, Validators.maxLength(16)]],
      fecha: ['', [Validators.required, Validators.maxLength(5), Validators.minLength(5)]],
      montoDisponible: ['', [Validators.required, Validators.maxLength(16)]],
      cvv: ['', [Validators.required, Validators.maxLength(3), Validators.minLength(3)]],
    })
  }

  ngOnInit(): void {
    this.tarjetaService.obtenerTarjeta().subscribe(data=>{
      console.log(data);
      this.tarjeta =data;
      this.form.patchValue({
        nombre: this.tarjeta.nombre,
        numeroTarjeta: this.tarjeta.numeroTarjeta,
        tipoTarjeta:this.tarjeta.tipoTarjeta,
        fecha:this.tarjeta.fecha,
        montoDisponible:this.tarjeta.montoDisponible,
        cvv:this.tarjeta.cvv
      })
    })
  }
  //metodo encargado de guardar los datos del form de vista tarjetas
  guardarTarjeta() {
    const tarjeta: TarjetaCredito = {
    
      nombre: this.form.get('nombre').value,
      numeroTarjeta: this.form.get('numeroTarjeta').value,
      tipoTarjeta:this.form.get('tipoTarjeta').value,
      fecha: this.form.get('fecha').value,
      montoDisponible: this.form.get('montoDisponible').value,
      cvv:this.form.get('cvv').value,
      
    }
    this.idTarjeta+1;
    this.tarjetaService.guardarTarjeta(tarjeta).subscribe(data =>{
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    });
   
    console.log(this.form);
    console.log(tarjeta);
  }
  //Metodo encargardo de editar las tarjetas segun el numero de tarjeta
  editar(){
    const tarjeta: TarjetaCredito = {
      
      nombre: this.form.get('nombre').value,
      numeroTarjeta: this.form.get('numeroTarjeta').value,
      tipoTarjeta:this.form.get('tipoTarjeta').value,
      fecha: this.form.get('fecha').value,
      montoDisponible: this.form.get('montoDisponible').value,
      cvv:this.form.get('cvv').value,
      
    }
    this.idTarjeta+1;
    this.tarjetaService.actualizarTarjeta(this.idTarjeta,tarjeta).subscribe(data=>{
    this.toastr.info('Actualizada', 'Exitosamente');
    this.tarjetaService.obtenerTarjetas();
    this.form.reset(); 
    });
    
  }
  
  
}
