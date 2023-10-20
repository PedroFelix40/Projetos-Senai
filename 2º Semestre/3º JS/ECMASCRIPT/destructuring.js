const camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: 399.99,
    cor: "Azul",
    promo: false
}

//const descricao = camisaLacoste.descricao;
//const preco = camisaLacoste.preco;

const { descricao, preco, promo, ...resto} = camisaLacoste;

console.log(resto);

console.log(`
    Produto: ${descricao},
    Preco: ${preco},
    Preco: ${promo ? 'Sim' : 'Não'}
    ${resto}
`);

/* Cire um objeto evento com as seguintes propriedades
    * dataEvento
    * descricaoEvento
    * titulo
    * comentario
    
    * Crie uma destructuring das propriedades do objeto evento e as exiba no console.

    * Obs: Para a presença deve-se exibir "Sim" ou "Não"
*/

// const evento = {
//     dataEvento: new Date("1995-12-17"),
//     descricaoEvento: "Nasciemnto do Pedro",
//     titulo: "Pedro",
//     comentario: "O melhor evento que já aconteceu!!!",
//     presenca: true
// }

// // desestruturação
// const { dataEvento, descricaoEvento, titulo, comentario, presenca} = evento;

// console.log(`
//     Titulo: ${titulo}
//     Descrição: ${descricaoEvento}
//     Data do evento: ${dataEvento}
//     Comentários: ${comentario}
//     Você vai estar presente: ${presenca ? "Sim" : "Nao"} //if ternário
// `);