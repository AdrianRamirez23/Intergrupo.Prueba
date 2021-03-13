import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { UsuariosInterface } from '../models/usuarios-interface';




@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }
  headers: HttpHeaders= new HttpHeaders({
   "Content-Type":"application/json"
  });

  registerUser(usuario: string, contrasena: string, tipoUsuario: string, estado: boolean){
    const url_api="https://localhost:44379/Usuarios";
    return this.http.post<UsuariosInterface>(url_api, {usuario, contrasena, tipoUsuario, estado}, {headers: this.headers}).pipe(map(data=> data));
  }
  loginUser(usuario: string, contrasena: string):Observable<any>{
    const url_api="https://localhost:44379/Login";
    return this.http.post<string>(url_api, {usuario, contrasena}, {headers: this.headers}).pipe(map(data=>data));
  }
 
  setToken(token):void{
    localStorage.setItem("accessToken", token);
  }
  getToke(){
    return localStorage.getItem("accessToken");
  }
  
  logoutUser(){
    localStorage.removeItem("accessToken");
  }
}