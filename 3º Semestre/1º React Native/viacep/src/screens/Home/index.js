import { useState } from "react";
import { BoxInput } from "../../Components/BoxInput";
import { ContainerForm, ContainerInput, ScrollForm } from "./style";
import { IMaskInput } from "react-imask";

export function Home() {
    // states - variáveis
    const [cep, setCep] = useState('765757575');
    const [logradouro, setLogradouro] = useState("eee");
    const [bairro, setBairro] = useState("eee");
    const [cidade, setCidade] = useState("eee");
    const [estado, setEstado] = useState("eee");
    const [uf, setUf] = useState("eee");


    // useEffect - funções

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
                    onChangeText={tx => setCep(tx)}
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