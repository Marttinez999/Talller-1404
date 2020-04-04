import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, } from '@angular/common/http';

import { AppComponent } from './app.component';
import { APP_ROUTING } from './app.routes';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { FormularioComponent } from './components/formulario/formulario.component';
import { ConsultaComponent } from './components/consulta/consulta.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FormularioComponent,
    ConsultaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    APP_ROUTING
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
