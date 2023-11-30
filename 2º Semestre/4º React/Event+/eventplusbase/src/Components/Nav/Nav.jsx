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
                <Link className='navbar__items-box__link' to="/">Home</Link>
                <Link className='navbar__items-box__link' to="/tipo-eventos">Tipo Eventos</Link>
                <Link className='navbar__items-box__link' to="/eventos">Eventos</Link>
            </div>
        </nav>
    );
};

export default Nav;