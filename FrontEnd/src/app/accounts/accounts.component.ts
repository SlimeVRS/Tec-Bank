import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CuentaModel } from '../models/cuentasM';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})
export class AccountsComponent implements OnInit {
  form: FormGroup;
  data: CuentaModel[] =[];
  counter: number = 0;
  constructor(private formBuilder: FormBuilder, private toastr: ToastrService) {
    this.form = this.formBuilder.group({
      id: 0,
      numeroCuenta: ['', [Validators.required]],
      descripcionCuenta: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(0)]],
      cliente: ['', [Validators.required, Validators.maxLength(16)]],
      tipoCuenta: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(0)]],
      moneda: ['', [Validators.required, Validators.maxLength(16)]],
      montoDisponible: ['', [Validators.required, Validators.maxLength(16)]],
    })
  }
  

  ngOnInit(): void {
  }
  guardarDatos() {
    const cuenta: CuentaModel = {
      id:this.counter,
      numeroCuenta: this.form.get('numeroCuenta').value,
      descripcionCuenta: this.form.get('descripcionCuenta').value,
      cliente:this.form.get('cliente').value,
      tipoCuenta: this.form.get('tipoCuenta').value,
      moneda: this.form.get('moneda').value,
      montoDisponible: this.form.get('montoDisponible').value,
    }
  
    this.data.push(cuenta);
    this.counter+1;
    console.log(this.data);
    console.log("Esta mierda tira aca");
    console.log(this.form);
    console.log(cuenta);
    this.toastr.success('Cuenta Guardada', 'Agregada Exitosamente');
    this.form.reset();
  }

}
