import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { EmpleadosInterface } from '../models/empleados-interface';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class DataAPIService {
  
  
  constructor(private http: HttpClient, private auth: AuthService ) {}
  headers: HttpHeaders= new HttpHeaders({
    "Content-Type":"application/json",
    "Authorization":"Bearer "+this.auth.getToke()
  });

  getAllEmployes(){
    const url_api="https://localhost:44379/Empleados";
    return this.http.get<EmpleadosInterface>(url_api, {headers: this.headers}).pipe(map(data=> data));
  }
  Delete(id:string){
    const url_api="https://localhost:44379/Empleados/"+id;
    return this.http.delete(url_api, {headers: this.headers}).pipe(map(data=> data));
  }

  getEmployedByID(id:string){
    const url_api="https://localhost:44379/Empleados/"+id;
    return this.http.get<EmpleadosInterface>(url_api, {headers: this.headers}).pipe(map(data=> data));
  }
  CreateEmployed(nombreEmpleado: string, apellidoEmpleado: string, email: string, docIdent: string, cargo: string, estado: boolean){
    const url_api="https://localhost:44379/Empleados/";
    return this.http.post(url_api, {nombreEmpleado, apellidoEmpleado, email, docIdent, cargo, estado}, {headers: this.headers}).pipe(map(data=> data));
  }
  updateEmployed(nombreEmpleado: string, apellidoEmpleado: string, email: string, docIdent: string, cargo: string, estado: boolean){
    const url_api="https://localhost:44379/Empleados/"+docIdent;
    return this.http.put(url_api, {nombreEmpleado, apellidoEmpleado, email, docIdent, cargo, estado}, {headers: this.headers}).pipe(map(data=> data));
  }
}
