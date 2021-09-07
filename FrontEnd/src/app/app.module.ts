import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { RolesComponent } from './roles/roles.component';
import { ClientsComponent } from './clients/clients.component';
import { AccountsComponent } from './accounts/accounts.component';
import { NavigationbarComponent } from './navigationbar/navigationbar.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { TarjetasComponent } from './tarjetas/tarjetas.component';
import { MonedaComponent } from './moneda/moneda.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSelectModule} from '@angular/material/select';
import { ListaTarjetasComponent } from './lista-tarjetas/lista-tarjetas.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';

import { HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    RolesComponent,
    ClientsComponent,
    AccountsComponent,
    NavigationbarComponent,
    LoginComponent,
    TarjetasComponent,
    MonedaComponent,
    ListaTarjetasComponent
    
  ],
  imports: [
    BrowserModule,
    MatSelectModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    //AppRoutingModule
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      {path: 'tarjetas', component: TarjetasComponent},
      {path: 'cuentas', component: AccountsComponent},
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
