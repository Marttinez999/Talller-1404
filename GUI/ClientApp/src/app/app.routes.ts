import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ConsultaComponent } from './components/consulta/consulta.component';
import { FormularioComponent } from './components/formulario/formulario.component';

const ROUTES: Routes = [
   { path: 'home', component: HomeComponent },
   { path: 'consulta', component: ConsultaComponent },
   { path: 'formulario', component: FormularioComponent },
   { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(ROUTES);
