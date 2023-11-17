import React, { useEffect, useState } from "react";
import "./TipoEventosPage.css";
import Title from "../../Components/Title/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import api from "../../Services/Service";
import TableTp from "./TableTp/TableTp";

import Notification from "../../Components/Notification/Notification";

const TipoEventosPage = () => {
  //state do componente Notification
  const [notifyUser, setNotifyUser] = useState({});

  const [frmEdit, setFrmEdit] = useState(false);

  const [titulo, setTitulo] = useState("");

  const [tipoEventos, setTipoEventos] = useState([]); //Array

  useEffect(() => {
    async function getNextEvents() {
      try {
        const promisse = await api.get(`/TiposEvento`);

        setTipoEventos(promisse.data);
      } catch (error) {
        console.log(error);
      }
    }
    getNextEvents();
  }, []);

  async function handleSubmit(e) {
    //para o submit
    e.preventDefault();

    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      alert("O titulo deve conter no mínimo 3 caracteres");
      return;
    }

    // chamar api
    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      }); 

      console.log(retorno.data);
      setTitulo(""); // limpa a variavel

      const promisse = await api.get(`/TiposEvento`);

      setTipoEventos(promisse.data);

    } catch (error) {
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

  {
    /****** EDITAR CADASTRO ******/
  }

  // Atualização dos dados
  function showUpdateForm() {
    alert("Mostrando a tela de update");
  }

  function handleUpdate() {
    alert("Bora atualizar");
  }

  // Cancela a tela de edição de dados
  function editActionAbort() {
    alert("Cancelar alteração");
  }

  //FUNÇÃO DE DELETAR
  async function handleDelete(id) {
    try {
      const retorno = await api.delete(`/TiposEvento/${id}`);

      alert("Registro apagado com sucesso");

      const promisse = await api.get(`/TiposEvento`);

      setTipoEventos(promisse.data);
    } catch (error) {}
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {/* CADASTRO DE TIPO DE EVENTOS */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página de Tipos de Eventos"} />
            <ImageIllustrator
              alterText={"??????"}
              imageRender={eventTypeImage}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              <p>Componentes de Fomulário</p>

              {!frmEdit ? (
                // Cadastrar
                <>
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Titulo"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={(e) => setTitulo(e.target.value)}
                  />
                  {titulo}
                  <Button
                    type={"submit"}
                    name={"cadastrar"}
                    id={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                <p>Tela de Edição</p>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/* LISTAGEM DE TIPO DE EVENTOS */}

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Tipo de Eventos"} color="white" />

          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
