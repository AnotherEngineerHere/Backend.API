import { environment } from './../../environments/environment.development';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../Interfaces/cliente';
@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint+'Cliente'
  constructor(private http:HttpClient) { }

  getCliente(id:number):Observable<Cliente> {
    return this.http.get<Cliente>('${this.apiUrl/${id}}');
  }
  getList():Observable<Cliente> {
    return this.http.get<Cliente>(this.apiUrl);
  }
  add(modelo:Cliente):Observable<Cliente> {
    return this.http.post<Cliente>(this.apiUrl,modelo);
  }
  update(id:number,modelo:Cliente):Observable<Cliente> {
    return this.http.put<Cliente>('${this.apiUrl/${id}}',modelo);
  }
  delete(id:number):Observable<void> {
    return this.http.delete<void>('${this.apiUrl/${id}}');
  }
}
