import React, { useEffect, useState } from "react";
import Container from "../../Components/Container/Container";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import eventImage from "../../assets/images/evento.svg";
import TableEv from "./TableEv/TableEv";
import { Input } from "../../Components/FormComponents/FormComponents";
import { Button } from "../../Components/FormComponents/FormComponents";

import api from "../../Services/Service";

const EventosPage = () => {
  const [eventos, setEventos] = useState([]);
  const [nomeEvento, setNomeEvento] = useState("");
  const [descricao, setDescricao] = useState("");
  const [dataEvento, setDataEvento] = useState("");
  const [tiposEvento, setTiposEvento] = useState("");
  const [instituicao, setInstituicao] = useState("Senai Informática");
  const [frmEdit, setFrmEdit] = useState(false);

  useEffect(() => {
    async function getNextEvents() {
      try {
        const promisse = await api.get(`/Evento`);

        setEventos(promisse.data);
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

      const retorno = await api.post("/Evento", { nomeEvento: nomeEvento , dataEvento: dataEvento , tiposEvento: tiposEvento });

      getNextEvents();
    } catch (error) {}
  }

  //____________________________________________________________

  // Funções de UpDate

  async function showUpdateForm(idElemento) {}

  async function handleUpdate(e) {}

  //____________________________________________________________

  // Cancela a tela de edição de dados
  function editActionAbort() {}

  //____________________________________________________________

  //FUNÇÃO DE DELETAR
  async function handleDelete(id) {}

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
                    
                   <select name="tiposEvento" id="tiposEvento">
                    
                   </select>
                    {/* Input tipo evento continuar amnhaaaaaaaaaaaaaaaaaaaaaaaaaaa */}
                  <Input
          
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Tipo Evento"}
                    required={"required"}
                    value={tiposEvento}
                    manipulationFunction={(e) => setTiposEvento(e.target.value)}
                  />
                    {/* Input data */}
                  <Input
                    type={"date"}
                    id={"dataEvento"}
                    name={"dataEvento"}
                    placeholder={"dd/mm/aaaa"}
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
                  <Input
                    id={"titulo"}
                    placeholder={"Título"}
                    name={"titulo"}
                    type={"text"}
                    required={"required"}
                    value={nomeEvento}
                    manipulationFunction={(e) => setNomeEvento(e.target.value)}
                  />

                  <div className="buttons-editbox">
                    <Button
                      textButton={"Atualizar"}
                      id={"atualizar"}
                      name={"atualizar"}
                      type={"submit"}
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

          <TableEv dados={eventos} />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
