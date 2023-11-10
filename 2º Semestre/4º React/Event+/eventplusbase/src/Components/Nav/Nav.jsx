import React from 'react';
import './Nav.css'
import logoDesktop from '../../assets/images/logo-pink.svg'
import logoMobile from '../../assets/images/logo-white.svg'
import { Link } from 'react-router-dom'

const Nav = ({setExibeNavbar, exibeNavbar}) => {
    return (
        <nav className= {`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
            <span className='navbar__close' onClick={() => {setExibeNavbar(false)}}>x</span>

            <Link to="/">
                <img 
                className='eventlogo__logo-image' 
                src={window.innerWidth >= 992 ? logoDesktop : logoMobile} 
                alt="Event Plus Logo" />
            </Link>

            <div className='navbar__items-box'>
                <Link to="/">Home</Link>
                <Link to="/tipo-eventos">Tipo Eventos</Link>
                <Link to="/eventos">Eventos</Link>
                <Link to="/login">Login</Link>
                <Link to="/testes">Teste</Link>
            </div>
        </nav>
    );
};

export default Nav;