import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TarjetaCredito } from './models/tarjetaCredito';
import { Observable } from 'rxjs';
import { data } from 'jquery';

@Injectable({

  providedIn: 'root'
})
export class TarjetaService {
  myAppUrl: 'http://localhost:50394/api/TarjetaCredito';
  list: TarjetaCredito[];

  constructor(private http: HttpClient) { }

  guardarTarjeta(tarjeta: TarjetaCredito): Observable<TarjetaCredito> {
    return this.http.post<TarjetaCredito>('http://localhost:50394/api/TarjetaCredito', tarjeta);

  }
  obtenerTarjetas() {
    this.http.get('http://localhost:50394/api/TarjetaCredito').toPromise().then(data => {
      this.list = data as TarjetaCredito[];
    }
    );
  }
}
