import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Compra } from '../interface/compra';

@Injectable({
  providedIn: 'root'
})
export class CompraService {
  private myAppUrl: string = environment.endpoint;
  private myCompraApi: string = 'api/Compra/';

  constructor(private http: HttpClient) { }

  getCompras(): Observable<Compra[]>{
    return this.http.get<Compra[]>(this.myAppUrl + this.myCompraApi);
  }

  getCompra(id: number): Observable<Compra> {
    return this.http.get<Compra>(this.myAppUrl + this.myCompraApi+id);
  }

  deleteCompra(id: number): Observable<void>{
    return this.http.delete<void>(this.myAppUrl + this.myCompraApi+id);
  }

  addCompra(compra: Compra):Observable<Compra> {
    return this.http.post<Compra>(`${this.myAppUrl}${this.myCompraApi}`, compra);
  }

  updateCompra(id: number, compra: Compra): Observable<void> {
    return this.http.put<void>(this.myAppUrl + this.myCompraApi+id, compra);
  }
}
