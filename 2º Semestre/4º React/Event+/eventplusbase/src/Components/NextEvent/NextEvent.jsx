import React from "react";
import { dateFormatDbToView } from "../../Utils/stringFunctions";
import "./NextEvent.css";
import { Tooltip } from "react-tooltip";
import { Link } from "react-router-dom";

const NextEvent = ({ idEvento, title, description, eventDate }) => {
  function conectar(idEvento) {
    alert(`Conectando ao evento: ${idEvento}`);
  }

  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>

      <p
        className="event-card__description"
        data-tooltip-id={idEvento}
        data-tooltip-content={description}
        data-tooltip-place="top"
      >
        <Tooltip id={idEvento} />
        {description.substr(0, 16)}...
      </p>

      <p className="event-card__description">{dateFormatDbToView(eventDate)}</p>

      <Link className="event-card__connect-link" to={`/detalhes-evento/${idEvento}`}>
        <a>Detalhes</a>
      </Link>
    </article>
  );
};

export default NextEvent;
