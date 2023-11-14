import React, { useState } from "react";
import "./TipoEventosPage.css";
import Title from "../../Components/Title/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import api from '../../Services/Service';

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState('');

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

  function handleUpdate() {
    alert("Bora atualizar");
  }

  return (
    <MainContent>
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
    </MainContent>
  );
};

export default TipoEventosPage;
