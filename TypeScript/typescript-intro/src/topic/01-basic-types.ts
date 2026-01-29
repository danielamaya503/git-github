
// Tipos básicos (primitivos) en TypeScript
const name : string = `Alejandro`;
let points: number | "100" = 100;
//podremos cambiar el tipo de dato a un string colocando los tipos con |
const isAlive : Boolean = true;

console.log({name, points, isAlive});

//hace que este archivo sea un modulo
export {};