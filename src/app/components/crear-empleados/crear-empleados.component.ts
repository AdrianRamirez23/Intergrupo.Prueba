import { Component, OnInit } from '@angular/core';
import { EmpleadosInterface } from 'src/app/models/empleados-interface';
import { isNullOrUndefined } from 'util';
import { DataAPIService } from 'src/app/services/data-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crear-empleados',
  templateUrl: './crear-empleados.component.html',
  styleUrls: ['./crear-empleados.component.css']
})
export class CrearEmpleadosComponent implements OnInit {

  constructor(private dataApiServices: DataAPIService, private router: Router ) { }
  public empleado: EmpleadosInterface={
    idEmpleado:0,
    nombreEmpleado:"",
    apellidoEmpleado:"",
    email:"",
    docIdent:"",
    cargo:"",
    estado:true
  }

  ngOnInit(): void {
  }

  CreateEmployed():void{
     this.dataApiServices.CreateEmployed(this.empleado.nombreEmpleado, this.empleado.apellidoEmpleado, this.empleado.email, this.empleado.docIdent, this.empleado.cargo, this.empleado.estado).subscribe(data => {
      if(!isNullOrUndefined(data)){
        alert("Empleado Creado Correctamente");
        this.router.navigate(["/employed"]);
      }
     }, err=>{
      console.log(err.error)
    });
  }

}
