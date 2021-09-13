import { Component, OnInit } from '@angular/core';
import { AccountsComponent } from '../accounts/accounts.component';
import { CuentaModel } from '../models/cuentasM';

@Component({
  selector: 'app-listacuentas',
  templateUrl: './listacuentas.component.html',
  styleUrls: ['./listacuentas.component.css']
})
export class ListacuentasComponent implements OnInit {

  constructor(public cuenta:AccountsComponent) { }

  ngOnInit(): void {
    this.cuenta.data;
  }
  eliminarCuenta(numeroCuenta){
    const index = this.cuenta.data.indexOf(numeroCuenta);
    this.cuenta.data.splice(index,1);
  }

}
