import React, { useEffect, useContext } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";
import { UserContext } from "../../context/AuthContext";

import { Button, Input } from "../FormComponents/FormComponents";
import "./Modal.css";

const Modal = ({
  modalTitle = "Feedback",
  comentaryText = "Não informado. Não informado. Não informado.",
  userId = null,
  idEvento = null,
  showHideModal = false,
  fnPost = null,
  fnGet = null,
  fnDelete = null

}) => {

  // recupera os dados globais do usuário
  const { userData } = useContext(UserContext);
  useEffect(() =>{   
      fnGet(userId, idEvento);
  },[])

  return (
    <div className="modal">
      <article className="modal__box">
        
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={()=> showHideModal(true)}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={() =>{
              fnDelete()
            }}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          additionalClass="comentary__entry"
        />

        <Button
          textButton="Comentar"
          additionalClass="comentary__button"
          manipulationFunction={ () =>{
            fnPost({
              //idUsuario: userData.idUsuario,
              //idEvento: idEvento
            })
          }}
        />
      </article>
    </div>
  );
};

export default Modal;
