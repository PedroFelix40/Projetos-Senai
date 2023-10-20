const somar = (x,y) => {
    return x + y
}
// arrow function 
const dobro = x => x * 2

console.log(dobro(50));

const convidados = [
    {nome: "Carlos", idade: 36},
    {nome: "Lucas", idade: 36},
    {nome: "Neymar", idade: 36},
    {nome: "Guilherme", idade: 36},
]

convidados.forEach( (pessoas,inc) => {
    console.log(`Convidado ${inc+1}, nome: ${pessoas.nome}, idade: ${pessoas.idade}`);
});

