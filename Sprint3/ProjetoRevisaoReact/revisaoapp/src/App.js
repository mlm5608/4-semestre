import { useEffect, useState } from 'react';
import './App.css';
import { Modal } from './Components/Modal';
function App() {

  const [openModal, setOpenModal] = useState(false)
  const [listatarefas, setListatarefas] = useState([]);

  const dataAtualExtenso = new Date().toLocaleString("pt-BR", {
    weekday: "long",
    day: "numeric",
    month: "long",
  });

  const dataAtualFormatada = dataAtualExtenso.split(" ").map((word) =>
      word.length > 2 ? word.charAt(0).toUpperCase() + word.slice(1) : word
    ).join(" ");

  useEffect(() => {
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <div className='Content-Box'>
          <h1 className='title'>{dataAtualFormatada}</h1>
          <div className='InputBox'>
            {/* <Input/> */}
          </div>

        </div>
        <button className='buttonOpenModal' onClick={() => setOpenModal(true)}>Nova Tarefa</button>
        <Modal openModal={openModal} setOpenModal={setOpenModal} list={listatarefas} setListatarefas={setListatarefas}/>
      </header>
    </div>
  );

}

export default App;
