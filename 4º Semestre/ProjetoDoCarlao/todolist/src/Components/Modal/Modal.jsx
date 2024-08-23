import { useState } from "react";

import "./Modal.css"

const Modal = ({
    visible,
    addTask,
    // nomeAtividade
}) => {
    const [nomeAtividade, setNomeAtividade] = useState();
    // Função para lidar com mudanças no input
    const handleInputChange = (event) => {
        setNomeAtividade(event.target.value); // Atualiza o estado com o novo valor do input
    };
    return (
        <>
            {
                visible && (
                    <div className="modalEdit">
                        <h1>Descreva sua tarefa</h1>

                        <input
                            type="text"
                            placeholder="Exemplo de descrição"
                            value={nomeAtividade}
                            onChange={handleInputChange}
                        />

                        <button type="button" onClick={() => addTask(nomeAtividade)}>Confirmar tarefa</button>
                    </div>
                )
            }
        </>

    )
}
export default Modal;