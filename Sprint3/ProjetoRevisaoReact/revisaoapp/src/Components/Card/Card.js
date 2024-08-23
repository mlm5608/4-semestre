import './Card.css';
import { RiPencilFill } from "react-icons/ri";
import { IoCheckmark, IoCloseSharp } from "react-icons/io5";
import { useState } from 'react';

export function Card({ id, title, lista, setlista }) {
    const [done, setDone] = useState(false);
    const [edit, setEdit] = useState(false);
    const [editedTitle, setEditedTitle] = useState(title);

    const handleEditClick = () => setEdit(true);
    const handleConfirmClick = () => {
        setEdit(false);
        const listaUpdate = lista.map((item) =>
            item.id === id ? { ...item, title: editedTitle } : item
        );
        setlista(listaUpdate);
    };

    return (
        <div className={done ? "cardChecked" : "card"}>
            {done ? (
                <>
                    <button className="buttonChecked" onClick={() => setDone(false)}>
                        <IoCheckmark className='check' width={"23px"} height={"23px"} />
                    </button>

                    <p className={`cardDescriptionChecked ${edit ? "invisible" : "visible"}`}> {title}</p>

                    <input className={`inputEditChecked ${edit ? "visible" : "invisible"}`}
                        value={editedTitle}
                        onChange={(t) => setEditedTitle(t.target.value)} />

                    <div className='buttons-box'>
                        <button className={`buttonFunctChecked ${edit ? "invisible" : "visible"}`}
                            onClick={() => setlista(lista.filter((item) => item.id !== id))}>
                            <IoCloseSharp className='iconChecked' width={"23px"} height={"23px"} />
                        </button>

                        <button className={`buttonFunctChecked ${edit ? "invisible" : "visible"}`}
                            onClick={handleEditClick}>
                            <RiPencilFill className='iconChecked' width={"23px"} height={"23px"} />
                        </button>

                        <button className={`buttonFunctChecked ${edit ? "visible" : "invisible"}`}
                            onClick={handleConfirmClick}>
                            <IoCheckmark className='iconChecked' width={"23px"} height={"23px"} />
                        </button>
                    </div>
                </>
            ) : (
                <>
                    <button className="buttonCheck" onClick={() => setDone(true)}> </button>

                    <p className={`cardDescription ${edit ? "invisible" : "visible"}`}>{title}</p>

                    <input className={`inputEdit ${edit ? "visible" : "invisible"}`}
                        value={editedTitle}
                        onChange={(t) => setEditedTitle(t.target.value)} />

                    <div className='buttons-box'>
                        <button className={`buttonFunct ${edit ? "invisible" : "visible"}`}
                            onClick={() => setlista(lista.filter((item) => item.id !== id))}>
                            <IoCloseSharp className='icon' />
                        </button>

                        <button className={`buttonFunct ${edit ? "invisible" : "visible"}`}
                            onClick={handleEditClick}>
                            <RiPencilFill className='icon' />
                        </button>

                        <button className={`buttonFunct ${edit ? "visible" : "invisible"}`}
                            onClick={handleConfirmClick}>
                            <IoCheckmark className='icon' />
                        </button>
                    </div>
                </>
            )}
        </div>
    );
}