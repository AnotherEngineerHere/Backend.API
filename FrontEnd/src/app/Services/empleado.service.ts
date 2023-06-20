import { Empleado } from './../Interfaces/empleado';
import { environment } from './../../environments/environment.development';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  private endpoint:string = environment.endPoint;
  private apiUrl:string = this.endpoint+'Empleado'
  constructor(private http:HttpClient) { }

  getEmpleado(id:number):Observable<Empleado> {
    return this.http.get<Empleado>('${this.apiUrl/${id}}');
  }
  getList():Observable<Empleado> {
    return this.http.get<Empleado>(this.apiUrl);
  }
  add(modelo:Empleado):Observable<Empleado> {
    return this.http.post<Empleado>(this.apiUrl,modelo);
  }
  update(id:number,modelo:Empleado):Observable<Empleado> {
    return this.http.put<Empleado>('${this.apiUrl/${id}}',modelo);
  }
  delete(id:number):Observable<void> {
    return this.http.delete<void>('${this.apiUrl/${id}}');
  }

}
