const numeros = [1,2,5,10,300];

const soma = numeros.reduce( (vlIncicial, n) => {
    return vlIncicial + n
}, 0)

console.log(soma);