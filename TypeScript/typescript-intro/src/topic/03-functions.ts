
// Funciones en TypeScript con tipado de parámetros y valor de retorno
function addNumbers(a: number, b: number){
    return a + b;
}

//Función flecha con tipado
const addNumbersArrow = (a: number, b: number) : string=> {
    // especificando que el valor de retorno es un string
    return `${a + b}`;
}

function multiply(firtsNumber:number, SecondNumber:number, base: number = 2){
    return firtsNumber * SecondNumber;
}

//llamando a la función y almacenando el resultado
const result : number = addNumbers(1, 2);
const resultArrow : string = addNumbersArrow(1, 2);
const multiplyResult : number = multiply(2, 4);

console.log({result, resultArrow, multiplyResult});

//hace que este archivo sea un modulo
export {};