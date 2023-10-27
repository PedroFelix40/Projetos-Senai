import './App.css';
import CardEvento from './componentes/CardEvento/CardEvento';
import Titulo from './componentes/Titulo/Tituto';

function App() {
// CRIAR O COMPONENTE CardEvento

// CRIAR O CSS do componente

// EXIBIR O COMPONENTE NO APP.JS

// ALTERAR O COMPONENTE PARA RECEBER AS PROPS: titulo, texto, textoLink

// EXIBIR 3 COMPONENTES DO CardEvento

  return (
    <div className="App">
      <h1 className='titulo'>Hello React</h1>

      <Titulo texto="Eduardo"/>
      <Titulo texto="Pedro"/>
      <Titulo texto="Murilo"/>
      <Titulo texto="John"/>

      <CardEvento titulo='Titulo do Evento' descricao='Breve descrição do evento, pode ser um paragrafo pequenoBreve descrição do evento, pode ser um paragrafo pequeno.Breve descrição do evento, pode ser um paragrafo pequeno.' disabled={false}/>
      <CardEvento titulo='Titulo do Evento' descricao='Breve descrição do evento, pode ser um paragrafo pequenoBreve descrição do evento, pode ser um paragrafo pequeno.Breve descrição do evento, pode ser um paragrafo pequeno.' disabled={true}/>
    </div>
  );
}

export default App;
