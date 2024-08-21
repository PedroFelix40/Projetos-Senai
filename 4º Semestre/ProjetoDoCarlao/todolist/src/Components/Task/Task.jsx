import check from "../../Assets/Icons/check.svg"
import checkVazio from "../../Assets/Icons/check-vazio.svg"

import put from "../../Assets/Icons/edit_square_33dp_FCFCFC_FILL0_wght400_GRAD0_opsz40.svg"
import del from "../../Assets/Icons/delete_forever_33dp_FCFCFC_FILL0_wght400_GRAD0_opsz40.svg"

const Task = ({
    statusCheck,
    nomeAtividade,
    handleOnChange
}) => {
   
    return (
        <article className="task" style={statusCheck ? { backgroundColor: "#6C45CE", color: "#fff" } : { backgroundColor: "#fff", color: "#25282C" }}>
            <div className="icon-check">
                {/* <img src={statusCheck ? check : checkVazio} alt="icon" /> */}
                <input
                    type="checkbox"
                    checked={statusCheck}
                    onChange={handleOnChange}
                />
                <p>{nomeAtividade}</p>
            </div>

            <div className="icon-del-upt">
                <button style={{backgroundColor: "transparent", border: "none"}}>
                    <img style={{fill:"#000"}} src={del} alt="" />
                </button>
                <button style={{backgroundColor: "transparent", border: "none"}}>
                    <img src={put} alt="" />
                </button>
                
            </div>
        </article>
    )
}

export default Task;