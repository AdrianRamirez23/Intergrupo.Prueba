import { Component, OnInit } from '@angular/core';
import { UsuariosInterface } from 'src/app/models/usuarios-interface';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router ) { }
  public usuario: UsuariosInterface={
    usuario:"",
    contrasena:"",
    tipoUsuario:"",
    estado:true,
  };

  ngOnInit(): void {
  }

  OnRegister():void{
    this.authService.registerUser(this.usuario.usuario, this.usuario.contrasena, this.usuario.tipoUsuario, this.usuario.estado).subscribe(user=>{console.log(user);
    this.router.navigate(["/"])}, err=>{
      alert( JSON.stringify(err.error));
    });
  }

}
