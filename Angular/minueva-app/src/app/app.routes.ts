import { Routes } from '@angular/router';
import { CounterPageComponent } from './pages/counter/counter-page.component';
import {HeroPageComponent} from './pages/hero/hero-pages.component';
import {DragonballPageComponent} from './pages/Dragonballl/dragonball-page.component';
import {DragonballSuperPageComponent} from './pages/Dragonballl-super/dragonball-super-page.component';

export const routes: Routes = [

  //aqui referenciaremos nuestros componentes para las rutas
  {
    path: "",
    component: CounterPageComponent,
  },
  {
    //colocarle al URL que entre con hero
    path: 'hero',
    component: HeroPageComponent,
  },
  {
    path: "dragonball",
    component: DragonballPageComponent,
  },
  {
    path: "dragonball-super",
    component: DragonballSuperPageComponent,
  }
  ,
  //redirigir cuando una pagina no exista
  {
    path: "**",
    redirectTo: "",
  }
];
