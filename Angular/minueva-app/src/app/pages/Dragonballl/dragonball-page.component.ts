import {Component, signal} from '@angular/core';
//import {NgClass} from '@angular/common';

interface Character{
  id: number;
  name: string;
  power: number;
}

@Component({
  templateUrl: "dragonball-page.component.html",
  selector: `dragonball`
})

export class DragonballPageComponent{
  characters = signal<Character[]> ([
    {id: 1, name: "Goku", power: 9001},
  ]);

  name = signal("");
  power = signal(0);

  addCharacter(){
    if(!this.name || !this.power() || this.power() < 0){
      return;
    }

    const newCharacter : Character = {
      id: this.characters.length + 1,
      name: this.name(),
      power: this.power(),
    };

    //actyalizar lista a todas las señales
    this.characters.update(
      (list) => [... list, newCharacter]
    )

    this.resetData();
  }

  resetData(){
    this.name.set("");
    this.power.set(0);
  }
  /*powerClass = computed( () => {
    return {
      "text-danger": true,
    }
  })
  */
}
