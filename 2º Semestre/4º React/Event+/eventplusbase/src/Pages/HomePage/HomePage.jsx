import React, { useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import ContactSection from "../../Components/ContactSection/ContactSection";
import NextEvent from "../../Components/NextEvent/NextEvent";
import Container from "../../Components/Container/Container";
import "./HomePage.css";
import api from '../../Services/Service'

const HomePage = () => {
  const [nextEvents, setNextEvents] = useState([]);


  useEffect(() => {
    async function getProximosEventos() {
      try {
        // chamar api
        const promisse = await api.get(
          "/Evento/ListarProximos"
        );

        console.log(promisse.data);
        setNextEvents(promisse.data);
      } catch (error) {
        console.log("Deu ruim na API");
      }
    }
    getProximosEventos();
  }, [nextEvents]);



  return (
    <MainContent>
      <Banner />

      {/* PRÓXIMOS EVENTOS*/}
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />
          <div className="events-box">
            {nextEvents.map((e) => {
              return (
                <NextEvent
                  idEvento={e.idEvento}
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                />
              );
            })}
          </div>
        </Container>
      </section>

      <VisionSection />

      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
