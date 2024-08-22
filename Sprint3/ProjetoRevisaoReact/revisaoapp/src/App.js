import { useEffect, useState } from 'react';
import './App.css';
import { Card } from './Components/Card/Card';
import { Modal } from './Components/Modal/Modal';
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
            <input className='inputHome' onChange={(t) => setTextoBusca(t.target.value)}></input>
          </div>

          <div className={`flex flex-col w-[500px] gap-4 max-h-[176px] scroll-smooth overflow-auto scrollbar-none`}>
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
                    setItems={setListatarefas}
                    item={listatarefas}
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
