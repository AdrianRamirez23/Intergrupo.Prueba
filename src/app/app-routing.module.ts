import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrearEmpleadosComponent } from './components/crear-empleados/crear-empleados.component';
import { EditarEmpleadosComponent } from './components/editar-empleados/editar-empleados.component';
import { ListarEmpleadosComponent } from './components/listar-empleados/listar-empleados.component';
import { LoginComponent } from './components/login/login.component';
import { Page404Component } from './components/page404/page404.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
{path:'',component:LoginComponent},
{path:'register',component:RegisterComponent},
{path:'employed',component:ListarEmpleadosComponent, canActivate: [AuthGuard]},
{path:'create-employed',component:CrearEmpleadosComponent, canActivate: [AuthGuard]},
{path:'edit_employed/:id',component:EditarEmpleadosComponent, canActivate: [AuthGuard]},
{path:'**',component:Page404Component}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
