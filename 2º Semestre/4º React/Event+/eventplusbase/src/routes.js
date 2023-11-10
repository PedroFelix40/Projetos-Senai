import React from 'react';

//import dos componentes de rota
import { BrowserRouter, Routes, Route } from 'react-router-dom';

//import dos componentes da página
import HomePage from './Pages/HomePage/HomePage';
import LoginPage from './Pages/LoginPage/LoginPage';
import EventosPage from './Pages/EventosPage/EventosPage';
import TipoEventosPage from './Pages/TipoEventosPage/TipoEventosPage';
import TestePage from './Pages/TestePage/TestePage';

import Header from './Components/Header/Header';
import Footer from './Components/Footer/Footer';
const Rotas = () => {
    return (
      // criar a estrutura de rotas
      <BrowserRouter>
      <Header/>
        <Routes>
            <Route element={<HomePage />} path="/" exact/>
            <Route element={<LoginPage />} path="/login" />
            <Route element={<EventosPage />} path="/eventos" />
            <Route element={<TipoEventosPage />} path="/tipo-eventos" />
            <Route element={<TestePage />} path="/testes" />
        </Routes>
        <Footer/>
      </BrowserRouter>
    );
};

export default Rotas;