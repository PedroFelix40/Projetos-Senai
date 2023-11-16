import React, { useEffect, useState } from "react";
import "./TipoEventosPage.css";
import Title from "../../Components/Title/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import api from '../../Services/Service';
import TableTp from "./TableTp/TableTp";

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState('');

  const [tipoEventos, setTipoEventos] = useState([]); //Array

  console.log(tipoEventos);

  useEffect(() => {
    async function getNextEvents() {
      try {
        const promisse = await api.get("/TiposEvento")

        console.log(promisse.data);
        setTipoEventos(promisse.data)
      } catch (error) {
        console.log(error);
      }
    }
    getNextEvents()
  },[tipoEventos])

  async function handleSubmit(e) {
    //para o submit
    e.preventDefault()

    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      alert('O titulo deve conter no mínimo 3 caracteres')
      return
    }

    // chamar api
    try {
      const retorno = await api.post("/TiposEvento", {titulo: titulo})

      alert('Tipo de evento cadastrado')
      console.log(retorno.data);
      setTitulo(""); // limpa a variavel
    } catch (error) {
      console.log('Deu ruim na api');
      console.log(error);
    }
  }

  {/****** EDITAR CADASTRO ******/}

  // Atualização dos dados
  function showUpdateForm() {
    alert('Mostrando a tela de update')
  }
  
  function handleUpdate() {
    alert("Bora atualizar");
  }
  
  // Cancela a tela de edição de dados
  function editActionAbort() {
    alert("Cancelar alteração");
  }

 
  function handleDelete() {
    alert('Bora lá apagar api')
  }

  return (
    <MainContent>

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

              {!frmEdit ? 
              // Cadastrar
              (
                <>
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Titulo"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={
                      (e) => setTitulo(e.target.value)
                    }
                  />
                  {titulo}
                    <Button 
                      type={"submit"} 
                      name={"cadastrar"} 
                      id={"cadastrar"} 
                      textButton={"Cadastrar"}/>  
                </>
              ) 
              : 
              (
                <p>Tela de Edição</p>
              )
              }

            </form>
          </div>
        </Container>
      </section>

      {/* LISTAGEM DE TIPO DE EVENTOS */}

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Tipo de Eventos"} color="white"/>

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
