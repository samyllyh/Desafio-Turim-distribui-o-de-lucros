import './App.css';
import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';

function App() {

  const baseUrl = "https://localhost:7192/api/AllFuncionarios";

  const [data, setData] = useState([]);
  const [modalAdicionar, setModalAdicionar]=useState(false);

  const [funcionarioSelecionado, setFuncioanrioSelecionado] = useState({
    MatriculaId: '',
    Nome:'',
    Area: '',
    Cargo:'',
    Salario: '',
    DataAdmissao:''
  })

  const abrirFecharModalAdicionar=()=>{
    setModalAdicionar(!modalAdicionar);
  }

  const handleChange = e=>{
    const {name, value} = e.target;
    setFuncioanrioSelecionado({
      ...funcionarioSelecionado,[name]:value
    });
    console.log(funcionarioSelecionado);
  }

  const pedidoGet = async() =>{
    await axios.get(baseUrl)
    .then(response =>{
      setData(response.data);
    }).catch(error =>{
      console.log(error);
    })
  }

  const pedidoPost = async() =>{
    delete funcionarioSelecionado.MatriculaId;
    funcionarioSelecionado.Area= ParseInt(funcionarioSelecionado.Nome);
    funcionarioSelecionado.Cargo= ParseInt(funcionarioSelecionado.Cargo);
    funcionarioSelecionado.Salario= ParseInt(funcionarioSelecionado.Salario);
    funcionarioSelecionado.DataAdmissao= ParseInt(funcionarioSelecionado.DataAdmissao);
    await axios.get(baseUrl, funcionarioSelecionado)
    .then(response =>{
      setData(data.concat(response.data));
      abrirFecharModalAdicionar();
    }).catch(error =>{
      console.log(error);
    })
  }

  const pedidoPut = async() =>{
    funcionarioSelecionado.Area= ParseInt(funcionarioSelecionado.Nome);
    funcionarioSelecionado.Cargo= ParseInt(funcionarioSelecionado.Cargo);
    funcionarioSelecionado.Salario= ParseInt(funcionarioSelecionado.Salario);
    funcionarioSelecionado.DataAdmissao= ParseInt(funcionarioSelecionado.DataAdmissao);
    await axios.get(baseUrl+"/"+funcionarioSelecionado.MatriculaId, funcionarioSelecionado)
    .then(response =>{
      var resposta=response.data;
      var dadosAuxiliar = data;
      dadosAuxiliar.map(funcionarios=>{
        if(funcionarios.MatriculaId === funcionarioSelecionado.MatriculaId){
          funcionarios.Nome = resposta.Nome;
          funcionarios.Area = resposta.Area;
          funcionarios.Cargo = resposta.Cargo;
          funcionarios.Salario = resposta.Salario;
          funcionarios.DataAdmissao = resposta.DataAdmissao;
        }
      });
      abrirFecharModalEditar();
    }).catch(error =>{
      console.log(error);
    })

  useEffect(()=>{
    pedidoGet();
  })
  return (
    <div className="funcionario-container">
      <br/>
      <h3>Cadastro Funcionarios</h3>
      <header className="App-header">
        <button className="btn btn -success" onClick={()=>abrirFecharModalAdicionar()}> Incluir novo funcionario</button>
      </header>

      <table> className = "table table-bordered"
        <thead>
          <tr>
            <th> MatriculaId</th>
            <th>Nome</th>
            <th>Area</th>
            <th>Cargo</th>
            <th>Salario</th>
            <th>DataAdmissao</th>
          </tr>
        </thead>
        <tbody>
          {data.map(funcionarios=>(
            <tr>key={funcionarios.MatriculaId}
            <td>{funcionarios.Nome}</td>
            <td>{funcionarios.Area}</td>
            <td>{funcionarios.Cargo}</td>
            <td>{funcionarios.Salario}</td>
            <td>{DataAdmissao}</td>
            <td>
              <button className="btn btn-primary">Editar</button> {"   "}
              <button className="btn btn-danger">Exclir</button>
            </td>
            </tr>
            ))}
        </tbody>
      </table>

      <Modal isOpen={modalAdicionar}/>
      <Modal>
        <ModalHeader>Adicionar Funcionario</ModalHeader>
        <ModalBody>
          <div className='form-gruop'>
            <br />
            <label>Nome: </label>
            <input type="text" className='form-control' name = 'Nome' onChange={handleChange}/>
            <br />
            <label>Area: </label>
            <input type="text" className='form-control'name = 'Area' onChange={handleChange}/>
            <br />
            <label>Cargo: </label>
            <input type="text" className='form-control' name = 'Cargo' onChange={handleChange}/>
            <br />
            <label>Salario: </label>
            <input type="text" className='form-control'name = 'Salario' onChange={handleChange}/>
            <br />
            <label>DataAdmissao: </label>
            <input type="text" className='form-control' name = 'DataAdmissao' onChange={handleChange}/>
          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={()=>pedidoPost()}> Adicionar</button> {"   "}
          <button className='btn btn-danger' onClick={()=>abrirFecharModalAdicionar()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal>
        <ModalHeader>Editar Funcionario</ModalHeader>
        <ModalBody>
          <div className='form-gruop'>
            <label>MatriculaId: </label>
            <br/> readOnly value={funcionarioSelecionado && funcionarioSelecionado.MatriculaId}
            <br />
            <label>Nome: </label>
            <input type="text" className='form-control' name = 'Nome' onChange={handleChange}/>
            value = {funcionarioSelecionado && funcionarioSelecionado.Nome} <br />
            <label>Area: </label>
            <input type="text" className='form-control'name = 'Area' onChange={handleChange}/>
            value = {funcionarioSelecionado && funcionarioSelecionado.Area}<br />
            <label>Cargo: </label>
            <input type="text" className='form-control' name = 'Cargo' onChange={handleChange}/>
            value = {funcionarioSelecionado && funcionarioSelecionado.Cargo}<br />
            <label>Salario: </label>
            <input type="text" className='form-control'name = 'Salario' onChange={handleChange}/>
            value = {funcionarioSelecionado && funcionarioSelecionado.Salario}<br />
            <label>DataAdmissao: </label>
            <input type="text" className='form-control' name = 'DataAdmissao' onChange={handleChange}/>
            value = {funcionarioSelecionado && funcionarioSelecionado.DataAdmissao}
          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={()=>pedidoPost()}> Adicionar</button> {"   "}
          <button className='btn btn-danger' onClick={()=>abrirFecharModalAdicionar()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal>

      </Modal>
    </div>
  );
}
}

export default App;
