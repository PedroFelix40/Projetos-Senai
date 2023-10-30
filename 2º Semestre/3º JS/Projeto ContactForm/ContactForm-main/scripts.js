urlLocal = "http://localhost:3000/contatos"

async function cadastrar(e) {
    e.preventDefault()

    let nome = document.getElementById("nome").value;
    let sobrenome = document.getElementById("sobrenome").value;
    let email = document.getElementById("email").value;
    let pais = document.getElementById("pais").value;
    let ddd = document.getElementById("ddd").value;
    let telefone = document.getElementById("telefone").value;
    let cep = document.getElementById("cep").value;
    let rua = document.getElementById("rua").value;
    let numero = document.getElementById("numero").value;
    let complemento = document.getElementById("complemento").value;
    let bairro = document.getElementById("bairro").value;
    let cidade = document.getElementById("cidade").value;
    let UF = document.getElementById("UF").value;
    let anotacoes = document.getElementById("anotacoes").value;

    const objPessoa = {
        nome,
        sobrenome,
        email,
        pais,
        ddd,
        telefone,
        cep,
        rua,
        numero,
        complemento,
        bairro,
        cidade,
        UF,
        anotacoes
    }

    try {
        const promise = await fetch(urlLocal, {
            //Tranforma o objeto em JSON
            body: JSON.stringify(objPessoa),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });

        const retorno = promise.json(); // pega o retorno da api

        console.log(retorno);
    } catch (error) {
        alert("Deu ruim: " + error)
    }

}

async function chamarApi(event) {
    const cep = document.getElementById("cep").value
    const url = `https://viacep.com.br/ws/${cep}/json/`;

    try {
        const promise = await fetch(url);
        const endereco = await promise.json();

        //exibir dados no formulário
        exibirEndereco(endereco);
    } catch (error) {// Rejeitada
        console.log("Deu ruim na API");
    }
}

//função 
function exibirEndereco(endereco) {
    //Exibir os dados
    document.getElementById("rua").value = endereco.logradouro
    document.getElementById("cidade").value = endereco.localidade
    document.getElementById("bairro").value = endereco.bairro
    document.getElementById("UF").value = endereco.uf
}
function limparEndereco() {
    //Exibir os dados
    document.getElementById("endereco").value = "";
    document.getElementById("cidade").value = "";
    document.getElementById("bairro").value = "";
    document.getElementById("estado").value = "";
}