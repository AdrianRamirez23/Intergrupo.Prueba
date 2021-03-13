import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { LoginInterface } from 'src/app/models/login-interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router ) { }
  public usuario: LoginInterface={
    usuario:"",
    contrasena:""
  }

  ngOnInit(): void {
    
  }
  OnLogin(){
    return this.authService.loginUser(this.usuario.usuario,this.usuario.contrasena)
    .subscribe(data=>{
      this.authService.setToken(data);
      this.router.navigate(["/employed"]);
    },err=>
    alert("Revise las credenciales de acceso, no coiciden")
    );
  }


}
