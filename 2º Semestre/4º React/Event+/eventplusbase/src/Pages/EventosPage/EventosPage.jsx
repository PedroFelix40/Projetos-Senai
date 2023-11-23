import React, { useEffect, useState } from "react";
import Container from "../../Components/Container/Container";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import eventImage from "../../assets/images/evento.svg";
import TableEv from "./TableEv/TableEv";
import {
  Input,
  Button,
  Select,
} from "../../Components/FormComponents/FormComponents";
import { dateFormatViewToDb } from "../../Utils/stringFunctions";
import api from "../../Services/Service";

const EventosPage = () => {
  const [eventos, setEventos] = useState([]);
  const [idEventos, setIdEventos] = useState("");
  const [nomeEvento, setNomeEvento] = useState("");
  const [descricao, setDescricao] = useState("");
  const [dataEvento, setDataEvento] = useState("");
  const [tiposEvento, setTiposEvento] = useState([]);
  const [idTiposEvento, setIdTiposEvento] = useState("");
  const [instituicao, setInstituicao] = useState(
    "d091baf1-ae72-439e-a59f-04993ed02c2d"
  );
  const [frmEdit, setFrmEdit] = useState(false);

  useEffect(() => {
    async function getNextEvents() {
      try {
        const promisse = await api.get(`/Evento`);

        setEventos(promisse.data);

        const retorno = await api.get(`/tiposEvento`);

        setTiposEvento(retorno.data);
      } catch (error) {
        console.log(error);
      }
    }
    getNextEvents();
  }, []);

  // Função de Listar os Eventos
  async function getNextEvents() {
    try {
      const promisse = await api.get(`/Evento`);

      setEventos(promisse.data);
    } catch (error) {
      console.log(error);
    }
  }

  // Função de Cadastrar
  async function handleSubmit(e) {
    e.preventDefault();

    try {
      // validar pelo menos 3 caracteres
      if (nomeEvento.trim().length < 3) {
        alert("O nome do evento deve conter no mínimo 3 caracteres");
        return;
      }

      const retorno = await api.post("/Evento", {
        dataEvento: dataEvento,
        nomeEvento: nomeEvento,
        descricao: descricao,
        idTipoEvento: idTiposEvento,
        idInstituicao: instituicao,
      });

      getNextEvents();
    } catch (error) {
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

  //____________________________________________________________

  // Funções de UpDate

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);
    // fazer um getById

    try {
      const retorno = await api.get(`/Evento/${idElemento}`);

      const { idEvento, dataEvento, nomeEvento, descricao, idTipoEvento } =
        await retorno.data;

      setIdEventos(idEvento);
      setDataEvento(dateFormatViewToDb(dataEvento));
      setNomeEvento(nomeEvento);
      setDescricao(descricao);
      setIdTiposEvento(idTipoEvento);
    } catch (error) {
      console.log("Não foi possível mostrar a tela de edição. Tente novamente");
    }
  }

  async function handleUpdate(e) {
    e.preventDefault();

    // validar pelo menos 3 caracteres
    if (nomeEvento.trim().length < 3) {
      alert("O nome do evento deve conter no mínimo 3 caracteres");
      return;
    }

    // chamar api
    try {
      const retorno = await api.put(`/Evento/${idEventos}`, {
        dataEvento: dataEvento,
        nomeEvento: nomeEvento,
        descricao: descricao,
        idTipoEvento: idTiposEvento,
      });

      editActionAbort();

      getNextEvents();
    } catch (error) {
      console.log(error);
    }
  }

  //____________________________________________________________

  // Cancela a tela de edição de dados
  function editActionAbort() {
    setFrmEdit(false);
    setDataEvento("");
    setNomeEvento("");
    setDescricao("");
    setIdEventos(null);
  }

  //____________________________________________________________

  //FUNÇÃO DE DELETAR
  async function handleDelete(id) {
    try {
      const retorno = await api.delete(`/Evento/${id}`);

      getNextEvents();
    } catch (error) {}
  }

  //____________________________________________________________

  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Eventos"} />
            <ImageIllustrator alterText={"??????"} imageRender={eventImage} />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                // Tela de Cadastro
                <>
                  {/* Input Nome */}
                  <Input
                    type={"text"}
                    id={"nome"}
                    name={"nome"}
                    placeholder={"Nome"}
                    required={"required"}
                    value={nomeEvento}
                    manipulationFunction={(e) => setNomeEvento(e.target.value)}
                  />
                  {/* Input Descrição */}
                  <Input
                    type={"text"}
                    id={"descricao"}
                    name={"descricao"}
                    placeholder={"Descrição"}
                    required={"required"}
                    value={descricao}
                    manipulationFunction={(e) => setDescricao(e.target.value)}
                  />

                  {/* Select */}
                  <Select
                    dados={tiposEvento}
                    id={"tiposEvento"}
                    name={"tiposEvento"}
                    required={"required"}
                    manipulationFunction={(e) =>
                      setIdTiposEvento(e.target.value)
                    }
                    selectValue={idTiposEvento}
                  />

                  {/* Input data */}
                  <Input
                    type={"date"}
                    id={"dataEvento"}
                    name={"dataEvento"}
                    required={"required"}
                    value={dataEvento}
                    manipulationFunction={(e) => setDataEvento(e.target.value)}
                  />

                  <Button
                    type={"submit"}
                    name={"cadastrar"}
                    id={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                // Tela de Edição
                <>
                  {/* Input Nome */}
                  <Input
                    type={"text"}
                    id={"nome"}
                    name={"nome"}
                    placeholder={"Nome"}
                    required={"required"}
                    value={nomeEvento}
                    manipulationFunction={(e) => setNomeEvento(e.target.value)}
                  />
                  {/* Input Descrição */}
                  <Input
                    type={"text"}
                    id={"descricao"}
                    name={"descricao"}
                    placeholder={"Descrição"}
                    required={"required"}
                    value={descricao}
                    manipulationFunction={(e) => setDescricao(e.target.value)}
                  />

                  {/* Select */}
                  <Select
                    dados={tiposEvento}
                    id={"tiposEvento"}
                    name={"tiposEvento"}
                    required={"required"}
                    manipulationFunction={(e) =>
                      setIdTiposEvento(e.target.value)
                    }
                    selectValue={idTiposEvento}
                  />

                  {/* Input data */}
                  <Input
                    type={"date"}
                    id={"dataEvento"}
                    name={"dataEvento"}
                    required={"required"}
                    value={dataEvento}
                    manipulationFunction={(e) => setDataEvento(e.target.value)}
                  />

                  <div className="buttons-editbox">
                    <Button
                      type={"submit"}
                      name={"atualizar"}
                      id={"atualizar"}
                      textButton={"Atualizar"}
                      additionalClass={"button-component--middle"}
                    />

                    <Button
                      textButton={"Cancelar"}
                      id={"cancelar"}
                      name={"cancelar"}
                      type={"button"}
                      manipulationFunction={editActionAbort}
                      additionalClass={"button-component--middle"}
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Eventos"} color="white" />

          <TableEv
            dados={eventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
