import "./PageHome.css"

import iconLupa from "../../Assets/Icons/icon-lupa.svg"
import checkVazio from "../../Assets/Icons/check-vazio.svg"
import check from "../../Assets/Icons/check.svg"
import { useEffect, useState } from "react"
import Task from "../../Components/Task/Task"
import Modal from "../../Components/Modal/Modal"



const PageHome = () => {

    const [task, setTask] = useState([])

    useEffect(() => {
        console.log(task);
    }, [task]);


    // Função para filtar por nome
    const [nomeAtividade, setNomeAtividade] = useState();
    const taskFilter = task.filter(task => task.nomeAtividade === nomeAtividade);


    // Pegando a data atual *************
    const timeElapsed = Date.now();
    const today = new Date(timeElapsed);

    const mesAtual = () => {
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

    const diaSemana = () => {
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

    const addTask = (nomeAtividadeAdd,e) => {
        // e.prevent

        if (!nomeAtividadeAdd || nomeAtividadeAdd.trim() === '') {
            alert('Descrição da tarefa não pode ser vazia.');
            return;
        }

        const newTask = { id: task.length + 1, statusCheck: false, nomeAtividadeAdd };
        setTask([...task, newTask]);


        setExibirModalState(false);
        setNomeAtividade("")
    };

    // Logica do modal
    const [exibirModalState, setExibirModalState] = useState(false);

    const ExibirModal = () => {
        setExibirModalState(!exibirModalState);
        console.log(exibirModalState);
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
                        nomeAtividade === "" || nomeAtividade == null ?
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

            <button id="button-new-task" onClick={ExibirModal}>Nova tarefa</button>

            <Modal
                visible={exibirModalState}
                addTask={addTask}
                nomeAtividade={nomeAtividade}
            />

        </body>
    )
}

export default PageHome;