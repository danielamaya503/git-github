import { Component, Input, input } from '@angular/core';
import type { Character } from "../../../interfaces/character";

@Component({
  selector: 'dragonball-component-list',
  templateUrl: './character-list.html',
})
export class CharacterList {
    //characters: input.required<Character[]>()
  @Input() xejemplo: string = '';
}
