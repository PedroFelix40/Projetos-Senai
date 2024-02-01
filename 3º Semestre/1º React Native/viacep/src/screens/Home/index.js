import { BoxInput } from "../../Components/BoxInput/Index";
import { ContainerForm, ScrollForm } from "./style";

export function Home() {
    return(
            <ScrollForm>
                <ContainerForm>
                    <BoxInput
                    textLabel='informar cep'
                    placeholder='cep...'
                    key='numeric'
                    maxLength={9}
                    />
                </ContainerForm>
            </ScrollForm>
    )
}