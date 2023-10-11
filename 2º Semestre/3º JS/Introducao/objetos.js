/*
Java
Script
Object
Notation
*/

// Criamos o objeto eduardo
let eduardo = {
    nome : 'Eduardo',
    idade: 41,
    altura: 1.67
};

//adiciona um atributo ao objeto eduardo
eduardo.peso = 90;

//Há outra forma de criar um objeto, sendo ela
let carlos = new Object();
//Adiciona os atributos
carlos.nome = 'Carlos';
carlos.idade = 36;
carlos.sobrenome = 'Roque'

//Exibir no console
// console.log(eduardo);
// console.log(carlos);

//Criar aqui um array
let pessoas = [];

//Inserir os objetos no array
pessoas.push(eduardo)
pessoas.push(carlos)

//console.log(pessoas);

//exibir os nome utilizando foreach
//pessoas.forEach(function (p,i) {
//    console.log(`${i+1}º ${p.nome}, ${p.idade}`);
//});

//Foreach expressão lambda
pessoas.forEach((i, p) => {
    console.log(`${i+1}º ${p.nome}, ${p.idade}`);
});