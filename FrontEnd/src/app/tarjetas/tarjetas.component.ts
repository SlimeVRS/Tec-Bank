import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TarjetaCredito } from '../models/tarjetaCredito';
import { TarjetaService } from '../tarjeta.service';


@Component({
  selector: 'app-tarjetas',
  templateUrl: './tarjetas.component.html',
  styleUrls: ['./tarjetas.component.css']
})
export class TarjetasComponent implements OnInit {
  form: FormGroup;
  list: TarjetaCredito[];
  

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
  }
  guardarTarjeta() {
    const tarjeta: TarjetaCredito = {
      nombre: this.form.get('nombre').value,
      numeroTarjeta: this.form.get('numeroTarjeta').value,
      tipoTarjeta:this.form.get('tipoTarjeta').value,
      fecha: this.form.get('fecha').value,
      montoDisponible: this.form.get('montoDisponible').value,
      cvv:this.form.get('cvv').value,
      
    }
    this.tarjetaService.guardarTarjeta(tarjeta).subscribe(data =>{
      this.toastr.success('Tarjeta Guardada', 'Agregada Exitosamente');
      this.form.reset();
    });
    
    // this.data.push(tarjeta);
    //console.log(this.data);
    // console.log("Esta mierda tira aca");
    // console.log(tarjeta.cvv);
  
   
    console.log(this.form);
    console.log(tarjeta);
    
  }
  
  
}
