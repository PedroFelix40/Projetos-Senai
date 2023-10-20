// //Filter

// const numeros = [1,2,5,10,300];

// //ele retorna apenas elementos que atenderam a uma condição
// const maior10 = numeros.filter ((e) => {
//     return e >= 10;
// })

// console.log(numeros);
// console.log(maior10);

const comentarios = [
    {comentario: "bla bla bla", exibe: true},
    {comentario: "Evento foi uma merdaaa", exibe: false},
    {comentario: "hehe, nice", exibe: true}
];

const comentariosOk = comentarios.filter(c => c.exibe)

comentariosOk.forEach( c  => {
    console.log(`${c.comentario}`)
});