import "./PageHome.css"

import iconLupa from "../../Assets/Icons/icon-lupa.svg"
import checkVazio from "../../Assets/Icons/check-vazio.svg"
import check from "../../Assets/Icons/check.svg"
import { useState } from "react"
import Task from "../../Components/Task/Task"



const PageHome = () => {

    const [task, setTask] = useState([
        {
            statusCheck: true,
            nomeAtividade: "Fazer licao"
        },
        {
            statusCheck: true,
            nomeAtividade: "oi a atividade ae"
        },
        {
            statusCheck: false,
            nomeAtividade: "Fazer comida"
        },
        {
            statusCheck: true,
            nomeAtividade: "Comece a atividade ae"
        },
        {
            statusCheck: false,
            nomeAtividade: "Fazer suco"
        },
        {
            statusCheck: true,
            nomeAtividade: "Comece a atividade ae"
        }

    ])

    const [nomeAtividade, setNomeAtividade] = useState();

    const taskFilter = task.filter(task => task.nomeAtividade == nomeAtividade);

    return (
        <body className="main-content">
            <section className="section-menu">

                <div className="dia-sem-task">
                    <p id="data">Terça-Feira, <span id="color-dia">20</span> de Agosto</p>
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
                                            statusCheck={e.statusCheck}
                                            nomeAtividade={e.nomeAtividade}
                                        />
                                    );
                                })
                            ) :
                            (
                                taskFilter.map((e) => {
                                    return (
                                        <Task
                                            statusCheck={e.statusCheck}
                                            nomeAtividade={e.nomeAtividade}
                                        />
                                    );
                                })
                            )
                    }
                </div>
            </section>
        </body>
    )
}

export default PageHome;