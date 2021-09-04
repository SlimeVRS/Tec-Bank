import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//import { AppRoutingModule } from './app-routing.module';
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
    //AppRoutingModule
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      {path: 'tarjetas', component: TarjetasComponent},
      {path: 'cuentas', component: AccountsComponent},
    ]),
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
