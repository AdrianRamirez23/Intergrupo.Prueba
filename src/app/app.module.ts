import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListarEmpleadosComponent } from './components/listar-empleados/listar-empleados.component';
import { EditarEmpleadosComponent } from './components/editar-empleados/editar-empleados.component';
import { CrearEmpleadosComponent } from './components/crear-empleados/crear-empleados.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { Page404Component } from './components/page404/page404.component';
import { DataAPIService } from './services/data-api.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ListarEmpleadosComponent,
    EditarEmpleadosComponent,
    CrearEmpleadosComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    Page404Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [DataAPIService],
  bootstrap: [AppComponent]
})
export class AppModule { }
