import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmpleadosInterface } from 'src/app/models/empleados-interface';
import { DataAPIService } from 'src/app/services/data-api.service';
import { isNullOrUndefined } from 'util';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editar-empleados',
  templateUrl: './editar-empleados.component.html',
  styleUrls: ['./editar-empleados.component.css']
})
export class EditarEmpleadosComponent implements OnInit {

  constructor(private activeRoute: ActivatedRoute, private dataApiService: DataAPIService, private router: Router) { }

  public Empleado: EmpleadosInterface={
    idEmpleado:0,
    nombreEmpleado:"",
    apellidoEmpleado:"",
    email:"",
    docIdent:"",
    cargo:"",
    estado:true
  }

  ngOnInit(): void {
    this.getEmployById();
  }

  getEmployById():void{
   this.activeRoute.params.subscribe(
     e=>{
       let id=e['id'];
       if(id){
         this.dataApiService.getEmployedByID(id).subscribe(data=>{
           this.Empleado=data
         });
       }
     }
   )
  }
  editEmploy():void{
    this.dataApiService.updateEmployed(this.Empleado.nombreEmpleado, this.Empleado.apellidoEmpleado, this.Empleado.email, this.Empleado.docIdent, this.Empleado.cargo, this.Empleado.estado).subscribe(data => {
     if(isNullOrUndefined(data)){
       alert("Empleado Editado Correctamente");
       this.router.navigate(["/employed"]);
     }
    }, err=>{
     console.log(err.error)
   });
 }

}
