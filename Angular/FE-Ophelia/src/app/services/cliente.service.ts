import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cliente } from '../interface/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private myAppUrl: string = environment.endpoint;
  private myClientApi: string = 'api/Cliente/';

  constructor(private http: HttpClient) { }

  getClientes(): Observable<Cliente[]>{
    return this.http.get<Cliente[]>(this.myAppUrl + this.myClientApi);
  }

  getCliente(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(this.myAppUrl + this.myClientApi+id);
  }

  deleteCliente(id: number): Observable<void>{
    return this.http.delete<void>(this.myAppUrl + this.myClientApi+id);
  }

  addCliente(cliente: Cliente):Observable<Cliente> {
    return this.http.post<Cliente>(`${this.myAppUrl}${this.myClientApi}`, cliente);
  }

  updateCliente(id: number, cliente: Cliente): Observable<void> {
    return this.http.put<void>(this.myAppUrl + this.myClientApi+id, cliente);
  }
}
