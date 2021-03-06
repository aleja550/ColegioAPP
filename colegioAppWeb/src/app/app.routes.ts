import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { EstudianteComponent } from './components/estudiante/estudiante.component';
import { SearchComponent } from './components/search/search.component';

const APP_ROUTES: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'estudiante', component: EstudianteComponent },
  { path: 'buscar/:termino', component: SearchComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);
