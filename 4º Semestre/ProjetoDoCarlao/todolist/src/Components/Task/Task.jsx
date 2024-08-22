import check from "../../Assets/Icons/check.svg"
import checkVazio from "../../Assets/Icons/check-vazio.svg"

import putWhite from "../../Assets/Icons/editWhite.svg"
import putBlack from "../../Assets/Icons/editBlack.svg"
import deleleWhite from "../../Assets/Icons/deleteWhite.svg"
import deleleBlack from "../../Assets/Icons/deleteBlack.svg"
import { useState } from "react"

const Task = ({
    statusCheck1,
    nomeAtividade,
    // toggleStatusCheck
}) => {
    const [statusCheck, setStatusCheck] = useState(statusCheck1);

    const toggleStatusCheck = () => {
        setStatusCheck(!statusCheck);
    };
    return (
        <article className="task" style={statusCheck ? { backgroundColor: "#6C45CE", color: "#fff" } : { backgroundColor: "#fff", color: "#25282C" }}>
            <div className="icon-check">
                {/* <img src={statusCheck ? check : checkVazio} alt="icon" /> */}
                <input
                    type="checkbox"
                    checked={statusCheck}
                    onChange={toggleStatusCheck}
                />
                <p>{nomeAtividade}</p>
            </div>

            <div className="icon-del-upt">
                <button style={{backgroundColor: "transparent", border: "none"}}>
                    <img src={statusCheck ? deleleWhite : deleleBlack} alt="" />
                </button>
                <button style={{backgroundColor: "transparent", border: "none"}}>
                    <img src={statusCheck ? putWhite : putBlack} alt="" />
                </button>
                
            </div>
        </article>
    )
}

export default Task;