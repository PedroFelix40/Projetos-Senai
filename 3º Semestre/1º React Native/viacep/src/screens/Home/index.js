// Import dos Hooks
import { useEffect, useState } from "react";

// Import dos components
import { BoxInput } from "../../Components/BoxInput";
import { ContainerForm, ContainerInput, ScrollForm } from "./style";

// import da API
import api from "../../services/Services";

export function Home() {
    // states - variáveis
    const [cep, setCep] = useState();

    // Aqui foi feito um state para cada dado
    // const [logradouro, setLogradouro] = useState("");
    // const [bairro, setBairro] = useState("");
    // const [cidade, setCidade] = useState("");
    // const [estado, setEstado] = useState("");
    // const [uf, setUf] = useState("");

    // Neste caso, criamos um objeto
    const [ dados, setDados ] = useState({
        street: '',
        district: '',
        city: '',
        state: '',
        stateShortname: ''
    })

    // useEffect - funções

    async function mostrarEndereco() {
        const promise = await api.get(`${cep}`)

        // setLogradouro(promise.data.result.street); 
        // setBairro(promise.data.result.district);
        // setCidade(promise.data.result.city)
        // setEstado(promise.data.result.state)
        // setUf(promise.data.result.stateShortname)

        setDados(promise.data.result);
    }

    useEffect( () => {
        mostrarEndereco()
    }, [cep])

    return (
        <ScrollForm>
            <ContainerForm>
                <BoxInput
                    textLabel='Informar cep'
                    editable={true}
                    placeholder='Cep...'
                    keyType="numeric"
                    maxLength={9}
                    fieldValue={cep}
                    onChangeText={(tx => setCep(tx))}
                />

                <BoxInput
                    fieldValue={dados.street}
                    textLabel='Logradouro'
                    placeholder='Logradouro...'
                />

                <BoxInput
                    fieldValue={dados.district}
                    textLabel='Bairro'
                    placeholder='Bairro...'
                />

                <BoxInput
                    fieldValue={dados.city}
                    textLabel='Cidade'
                    placeholder='Cidade...'
                />

                <ContainerInput>
                    <BoxInput
                        fieldValue={dados.state}
                        fieldWidth={67}
                        textLabel='Estado'
                        placeholder='Estado...'
                    />
                    <BoxInput
                        fieldValue={dados.stateShortname}
                        textLabel='UF'
                        placeholder='UF'
                        fieldWidth={23}
                    />
                </ContainerInput>


            </ContainerForm>
        </ScrollForm>
    )
}