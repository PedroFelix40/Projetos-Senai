import React from 'react';

//import dos componentes de rota
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import ProdutoPage from './pages/ProdutoPage/ProdutoPage';

const Rotas = () => {
    return (
      // criar a estrutura de rotas
      <BrowserRouter>
        <Routes>
            <Route element={<HomePage />} path="/" exact/>
            <Route element={<LoginPage />} path="/login" />
            <Route element={<ProdutoPage />} path="/produtos" />
        </Routes>
      </BrowserRouter>
    );
};

export default Rotas;