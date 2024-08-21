import { useEffect } from "react"
import "./Modal.css"

export function Modal({ openModal, setModal }) {

    function closeModal() {
        const myElement = document.getElementById("modal")

        myElement.classList.replace("opaco", "translucido")

    }
    return (
        <div className="modalBack translucido" id="modal">
            <div className={"modalBox"}>
                <h1>Descreva Sua Tarefa</h1>
                <input placeholder="Exemplo de descrição" />

                <button onClick={() => closeModal()}>Confirmar tarefa</button>
            </div>
        </div>
    )
}