import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Factura } from '../interface/factura';

@Injectable({
  providedIn: 'root'
})
export class FacturaService {
  private myAppUrl: string = environment.endpoint;
  private myFacturaApi: string = 'api/Factura/'

  constructor(private http: HttpClient) { }

  getFacturas():Observable<Factura[]>{
    return this.http.get<Factura[]>(this.myAppUrl+this.myFacturaApi);
  }
}
