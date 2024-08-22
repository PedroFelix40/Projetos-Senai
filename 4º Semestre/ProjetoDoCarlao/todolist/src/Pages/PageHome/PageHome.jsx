import "./PageHome.css"

import iconLupa from "../../Assets/Icons/icon-lupa.svg"
import checkVazio from "../../Assets/Icons/check-vazio.svg"
import check from "../../Assets/Icons/check.svg"
import { useEffect, useState } from "react"
import Task from "../../Components/Task/Task"
import Modal from "../../Components/Modal/Modal"



const PageHome = () => {

    const [task, setTask] = useState([
        {
            id: 1,
            statusCheck: true,
            nomeAtividade: "Fazer licao"
        },
        {
            id: 2,
            statusCheck: true,
            nomeAtividade: "oi a atividade ae"
        },
        {
            id: 3,
            statusCheck: false,
            nomeAtividade: "Fazer comida"
        },
        {
            id: 4,
            statusCheck: true,
            nomeAtividade: "Comece a atividade ae"
        },
        {
            id: 5,
            statusCheck: false,
            nomeAtividade: "Fazer suco"
        },
        {
            id: 6,
            statusCheck: true,
            nomeAtividade: "Comece a atividade ae"
        }

    ])

    useEffect(() => {
        console.log(task);
      }, [task]);


    const [nomeAtividade, setNomeAtividade] = useState();

    const taskFilter = task.filter(task => task.nomeAtividade === nomeAtividade);


    const timeElapsed = Date.now();
    const today = new Date(timeElapsed);

    function mesAtual() {
        var mesAtuals;
        switch (today.getMonth() + 1) {
            case 1:
                mesAtuals = "Janeiro"
                break;
            case 2:
                mesAtuals = "Fevereiro"
                break;
            case 3:
                mesAtuals = "Março"
                break;
            case 4:
                mesAtuals = "Abril"
                break;
            case 5:
                mesAtuals = "Maio"
                break;
            case 6:
                mesAtuals = "Junho"
                break;
            case 7:
                mesAtuals = "Julho"
                break;
            case 8:
                mesAtuals = "Agosto"
                break;
            case 9:
                mesAtuals = "Setembro"
                break;
            case 10:
                mesAtuals = "Outubro"
                break;
            case 11:
                mesAtuals = "Novembro"
                break;
            case 12:
                mesAtuals = "Dezembro"
                break;
            default:
                break;
        }

        return mesAtuals;
    }

    function diaSemana() {
        var diaAtual
        switch (today.getDay()) {
            case 1:
                diaAtual = "Segunda-Feira"
                break;
            case 2:
                diaAtual = "Terça-Feira"
                break;
            case 3:
                diaAtual = "Quarta-Feira"
                break;
            case 4:
                diaAtual = "Quinta-Feira"
                break;
            case 5:
                diaAtual = "Sexta-Feira"
                break;
            case 6:
                diaAtual = "Sabado-Feira"
                break;
            case 7:
                diaAtual = "Domingo-Feira"
                break;

            default:
                break;
        }

        return diaAtual;
    }

    const addTask = (nomeAtividade) => {

        if (!nomeAtividade || nomeAtividade.trim() === '') {
          alert('Descrição da tarefa não pode ser vazia.');
          return;
        }
    
        const newTask = { id: task.length + 1, nomeAtividade };
        setTask(newTask);
    
        //setExibir(false);
      };

    return (
        <body className="main-content">
            <section className="section-menu">

                <div className="dia-sem-task">
                    <p id="data">{diaSemana()}, <span id="color-dia">{today.getDate()}</span> de {mesAtual()}</p>
                    {/* id="icon-lupa" */}
                    <div className="input-task">
                        <img src={iconLupa} alt="" />
                        <input
                            id="input-text"
                            type="text"
                            value={nomeAtividade}
                            onChange={event => setNomeAtividade(event.target.value)}
                        />
                        <p >Procurar Tarefa</p>
                    </div>
                </div>

                <div className="list-task">

                    {
                        nomeAtividade == "" || nomeAtividade == null ?
                            (
                                task.map((e) => {
                                    return (
                                        <Task
                                            statusCheck1={e.statusCheck}
                                            nomeAtividade={e.nomeAtividade}
                                        />
                                    );
                                })
                            ) :
                            (
                                taskFilter.map((e) => {
                                    return (
                                        <Task
                                            statusCheck1={e.statusCheck}
                                            nomeAtividade={e.nomeAtividade}
                                        />
                                    );
                                })
                            )
                    }
                </div>
            </section>

            <button id="button-new-task">Nova tarefa</button>

        </body>
    )
}

export default PageHome;