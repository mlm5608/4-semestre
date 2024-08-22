import { useEffect, useState } from "react"
import "./Modal.css"

export function Modal({ openModal, setOpenModal, list, setListatarefas }) {

    const [text, setText] = useState("")

    useEffect(() => {
        if (openModal) {
            document.getElementById("modal").classList.replace("translucido", "opaco")
        } else {
            document.getElementById("modal").classList.replace("opaco", "translucido")
        }

    }, [openModal])

    function addFunction() {
        // Exemplo de adicionar uma nova tarefa
        list.push({
          id: list.length + 1,
          title: text
        });
        setListatarefas([...list]); // Atualize o estado com a nova lista
        setText("")
        setOpenModal(false)
    }
    return (
        <div className="modalBack translucido" id="modal">
            <div className={"modalBox"}>
                <h1 className="title">Descreva Sua Tarefa</h1>
                <input placeholder="Exemplo de descrição" value={text} onChange={(e) => setText(e.target.value)} className="inputBox"/>

                <button onClick={addFunction} className="button">Confirmar tarefa</button>
            </div>
        </div>
    )
}