import React, { useContext, useEffect, useState } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import loginImage from "../../assets/images/login.svg";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Service";

import "./LoginPage.css";
import { UserContext, UserDecodeToken } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  // Este user serve para trabalharmos com os dados recebidos através do form
  const [user, setUser] = useState({ email: "", senha: "" });

  // Nesta parte instanciamos o Context, para que a sessão LoginPage tenha acesso aos dados
  const { userData, setUserData } = useContext(UserContext);

  const navigate = useNavigate();

  useEffect(()=>{
    if(userData.name) {
      navigate("/")
    }
  },[userData])

  async function handSubmit(e) {
    e.preventDefault();

    if (user.email.length >= 3 && user.senha.length > 3) {
      try {
        // Ao fazer o login, precisamos passar a rota e o objeto: (`\rota`, {objeto})
        const promisse = await api.post(`/Login`, {
          email: user.email,
          senha: user.senha,
        });

        const userFullToken = UserDecodeToken(promisse.data.token);
        setUserData(userFullToken); // Guarda os dados decodificados da payload

        localStorage.setItem("token", JSON.stringify(userFullToken)); // Guarda os dados do token no localStorage(é necessário transformar o objeto em string)

        navigate("/"); // Manda o usuário para a Home
      } catch (error) {
        alert("Usuário ou senha inválida");
      }
    } else {
      alert("Preencha os dados corretamente");
    }
  }

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={loginImage}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                setUser({
                  ...user,
                  email: e.target.value.trim(),
                });
              }}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {
                setUser({
                  ...user,
                  senha: e.target.value,
                });
              }}
              placeholder="****"
            />

            <a href="https://dontpad.com" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton={"Login"}
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
