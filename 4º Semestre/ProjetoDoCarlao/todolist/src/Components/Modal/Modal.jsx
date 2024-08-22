import { useState } from "react";

const Modal = ({
    visible
}) => {
    const [isModalVisible, setIsModalVisible] = useState(visible);
    return (
        <>
        {
            isModalVisible && (
            <div style={{ display: "none" }} className="modal">
                <h1>Descreva sua tarefa</h1>

                <input type="text" placeholder="Exemplo de descrição" />

                <button type="submit">Confirmar tarefa</button>
            </div>
        )
        }
        </>

    )
}
export default Modal;