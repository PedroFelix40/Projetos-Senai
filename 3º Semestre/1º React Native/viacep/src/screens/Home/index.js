// Import dos Hooks
import { useEffect, useState } from "react";

// Import dos components
import { BoxInput } from "../../Components/BoxInput";
import { ContainerForm, ContainerInput, ScrollForm } from "./style";

// import da API
import api from "../../Services/Services";

export function Home() {
    // states - variáveis
    const [cep, setCep] = useState();
    const [logradouro, setLogradouro] = useState("");
    const [bairro, setBairro] = useState("");
    const [cidade, setCidade] = useState("");
    const [estado, setEstado] = useState("");
    const [uf, setUf] = useState("");


    // useEffect - funções

    async function mostrarEndereco() {
        const promise = await api.get(`${cep}`)

        setLogradouro(promise.data.result.street); 
        setBairro(promise.data.result.district);
        setCidade(promise.data.result.city)
        setEstado(promise.data.result.state)
        setUf(promise.data.result.stateShortname)
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
                    fieldValue={logradouro}
                    textLabel='Logradouro'
                    placeholder='Logradouro...'
                />

                <BoxInput
                    fieldValue={bairro}
                    textLabel='Bairro'
                    placeholder='Bairro...'
                />

                <BoxInput
                    fieldValue={cidade}
                    textLabel='Cidade'
                    placeholder='Cidade...'
                />

                <ContainerInput>
                    <BoxInput
                        fieldValue={estado}
                        fieldWidth={67}
                        textLabel='Estado'
                        placeholder='Estado...'
                    />
                    <BoxInput
                        fieldValue={uf}
                        textLabel='UF'
                        placeholder='UF'
                        fieldWidth={23}
                    />
                </ContainerInput>


            </ContainerForm>
        </ScrollForm>
    )
}