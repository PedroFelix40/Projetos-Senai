function calcular() {
    event.preventDefault(); //Para o submit

    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let res; //undefined
    let op = document.getElementById("operacao").value;

    //Validação para ver se é realmente um número
    //NaN(Not a Number )
    if(isNaN(n1) || isNaN(n1)) { 
        alert("Preencha todos os campos corretamente!")
        return;
    }

    switch (op) {
        case "+":
            res = somar(n1, n2);
            break;

        case "-":
            res = subtrair(n1, n2);
            break;

        case "*":
            res = multiplicar(n1, n2);
            break;

        case "/":
            res = dividir(n1, n2);
            break;

        default:
            res = `Operação inválida!!!!!!`;
            break;
    }

    console.log(`Resultado: ${res}`)
    document.getElementById('resultado').innerText = res;

}//Fim da função calcular

function somar(x, y) {
    return (x + y).toFixed(2);
}

function subtrair(x, y) {
    return (x - y).toFixed(2);
}

function multiplicar(x, y) {
    return (x * y).toFixed(2);
}

function dividir(x, y) {
    if (y == 0) {
        return "Não é possível dividir por zero"
    } else {
        return (x / y).toFixed(2);
    }
}
