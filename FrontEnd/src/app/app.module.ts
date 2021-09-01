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

@NgModule({
  declarations: [
    AppComponent,
    RolesComponent,
    ClientsComponent,
    AccountsComponent,
    NavigationbarComponent,
    LoginComponent,
    TarjetasComponent
  ],
  imports: [
    BrowserModule,
    //AppRoutingModule
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      {path: 'tarjetas', component: TarjetasComponent},
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
