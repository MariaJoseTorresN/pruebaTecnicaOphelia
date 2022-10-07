import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Producto } from '../interface/producto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  private myAppUrl: string = environment.endpoint;
  private myProductApi: string = 'api/Producto/';
  
  constructor(private http: HttpClient) { }

  getProductos(): Observable<Producto[]>{
    return this.http.get<Producto[]>(this.myAppUrl + this.myProductApi);
  }

  getProducto(id:number): Observable<Producto>{
    return this.http.get<Producto>(this.myAppUrl + this.myProductApi + id);
  }

  deleteProducto(id: number): Observable<void>{
    return this.http.delete<void>(this.myAppUrl + this.myProductApi+id);
  }

  addProducto(producto: Producto):Observable<Producto> {
    return this.http.post<Producto>(this.myAppUrl + this.myProductApi, producto);
  }

  updateProducto(id: number, producto: Producto):Observable<void> {
    return this.http.put<void>(this.myAppUrl + this.myProductApi +id, producto);
  }
}
