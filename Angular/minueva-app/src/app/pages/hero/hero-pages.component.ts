import {ChangeDetectionStrategy, Component, computed, signal} from "@angular/core";
import {UpperCasePipe} from '@angular/common';

@Component({
  templateUrl : "./hero-pages.component.html",
  changeDetection : ChangeDetectionStrategy.OnPush,
  imports: [UpperCasePipe]
})


export class HeroPageComponent{

  name = signal("Ironman");
  age = signal(45);

  heroDescripction = computed( () => {
    const description = `${this.name()} - ${this.age()}`;
    return description;
  })

  capitalizeName = computed(() => {
    const name = this.name().toUpperCase();
    return name;
  })


  changeHero(){
    this.name.set("Spiderman");
    this.age.set(22);
  }

  resetForm(){
    this.name.set("Ironman");
    this.age.set(45);
  }

  changeAge(){
    this.age.set(60);
  }

}
