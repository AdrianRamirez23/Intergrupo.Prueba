import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmpleadosInterface } from 'src/app/models/empleados-interface';
import { AuthService } from 'src/app/services/auth.service';
import { DataAPIService } from 'src/app/services/data-api.service';
import { isNullOrUndefined } from 'util';


@Component({
  selector: 'app-listar-empleados',
  templateUrl: './listar-empleados.component.html',
  styleUrls: ['./listar-empleados.component.css']
})
export class ListarEmpleadosComponent implements OnInit {

  constructor(private dataApi: DataAPIService, private authoservice:AuthService, private router: Router) { }

  employes: EmpleadosInterface;

  ngOnInit(): void {
    this.getEmployes();

    let token=this.authoservice.getToke();
    if(isNullOrUndefined(token)){
      this.router.navigate(["/"]);
    }
  }
  getEmployes():void{
    this.dataApi.getAllEmployes().subscribe(data=>{this.employes=data}, err=>{
      console.log(err.error)
    });
  }
  onDeleteEmploy(id: string):void{
   this.dataApi.Delete(id).subscribe(data=>{ 
    if(isNullOrUndefined(data)){
      alert("Empleado Eliminado Correctamente")
    }
    }, err=>{
     alert(err.error)
   })
  }
  


}
