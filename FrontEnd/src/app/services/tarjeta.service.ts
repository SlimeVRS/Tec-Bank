import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TarjetaCredito } from '../models/tarjetaCredito';
import { BehaviorSubject, Observable } from 'rxjs';
import { data } from 'jquery';

@Injectable({

  providedIn: 'root'
})
export class TarjetaService {
  myAppUrl: 'http://localhost:50394/api/TarjetaCredito';
  list: TarjetaCredito[];
  private actualizarForm = new BehaviorSubject<TarjetaCredito>({} as any);

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
  actualizar(tarjeta){
    this.actualizarForm.next(tarjeta);
  }
   actualizarTarjeta(id:string , tarjeta: TarjetaCredito): Observable<TarjetaCredito>{
     return this.http.put<TarjetaCredito>('http://localhost:50394/api/TarjetaCredito/'+id,tarjeta);
   }
  obtenerTarjeta(): Observable<TarjetaCredito>{
    return this.actualizarForm.asObservable();
  }

  eliminarTarjeta(id: number): Observable<TarjetaCredito>{
    return this.http.delete<TarjetaCredito>('http://localhost:50394/api/TarjetaCredito'+ id);
  }
}
