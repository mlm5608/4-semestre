import { useEffect, useState } from 'react';
import './App.css';
import { Card } from './Components/Card/Card';
import { Modal } from './Components/Modal/Modal';
import { IoMdSearch } from "react-icons/io";
function App() {

  const [openModal, setOpenModal] = useState(false)
  const [listatarefas, setListatarefas] = useState([]);
  const [textoBusca, setTextoBusca] = useState("")

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
            <IoMdSearch  fill='#fcfcfc' height={"18px"} width={"18px"}/>
            <input className='inputHome' placeholder='Procurar Tarefa' style={{color: "#fcfcfc"}} onChange={(t) => setTextoBusca(t.target.value)}></input>
          </div>

          <div className={"list"}>
            {listatarefas.length === 0 ? (
              <p>Nenhuma tarefa encontrada</p>
            ) : (
              listatarefas
                .filter((item) =>
                  item.title.toLowerCase().includes(textoBusca.toLowerCase())
                )
                .map((item) => (
                  <Card
                    key={item.id}
                    id={item.id}
                    title={item.title}
                    lista={listatarefas}
                    setlista={setListatarefas}
                  />
                ))
            )}
          </div>
        </div>
        <button className='buttonOpenModal' onClick={() => setOpenModal(true)}>Nova Tarefa</button>
        <Modal openModal={openModal} setOpenModal={setOpenModal} list={listatarefas} setListatarefas={setListatarefas} />
      </header>
    </div>
  );

}

export default App;
