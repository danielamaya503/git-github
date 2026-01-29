
// Tipos de objetos e interfaces en TypeScript
let skill: string[] = ["bash", "counter", "healing"];

//Interface para definir la forma de un objeto
interface Character{
    name: string;
    hp: number;
    skills: string[];
    hometown?: string; //el ? indica que es opcional
}

//Objeto que cumple con la interface Character
const strider : Character= {
    name: "Strider",
    hp: 100,
    skills: ["BASH", "COUNTER"],
};

strider.hometown = "Rivendell";

//Imprimir en consola tabla
console.table(strider);

//hace que este archivo sea un modulo
export {};