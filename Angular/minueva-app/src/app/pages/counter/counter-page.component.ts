import { ChangeDetectionStrategy, Component, signal } from "@angular/core";


@Component({
  templateUrl: './counter-pages.component.html',
  styles: `
    button{
      padding: 10px;
      font-size: 20px;
      margin-right: 5px;
    }
  `,
  changeDetection: ChangeDetectionStrategy.OnPush

})
export class CounterPageComponent {
  counter = 10;
  //signal es para crear un estado reactivo
  //estado reactivo es un estado que cuando cambia notifica a quien lo este usando
  counterSignal = signal(10);

  constructor(){
    /*setInterval(() => {
      this,this.counterSignal.update(current => current + 1);
      console.log('Tivk');

    }, 2000);*/
  }

  increaseBy(value: number) {
    this.counter += value;
    this.counterSignal.update(current => current + value);
  }
  desenaseBy(value: number) {
    this.counter -= value;
    this.counterSignal.update(current => current - value);
  }

  reset(){
    this.counter = 10;
    this.counterSignal.set(10);
  }
}
