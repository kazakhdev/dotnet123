import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import { v4 as uuidv4 } from 'uuid';
import axios from 'axios';
const DataForm = (props) => {
  
  const [data, setData] = useState(() => {
    return {
      Description: props.data ? props.data.Description : '',
      Module: props.data ? props.data.Module : '',
      Priority: props.data ?  props.data.Priority : '',
      RequestedPerson: props.data ? props.data.RequestedPerson : '',
    };
  });

  const [errorMsg, setErrorMsg] = useState('');
  const { Description, Module, Priority, RequestedPerson} = data;

  const handleOnSubmit = async (event) => {
    event.preventDefault();
    const values = [Description, Module, Priority, RequestedPerson];
    let errorMsg = '';

    const allFieldsFilled = values.every((field) => field.trim() !== '' && field !== '0');

    if (allFieldsFilled) {
      const data = {
        id: uuidv4(),
        Description,
        Priority,
        Module,
        date: new Date(),
      };

      try {
        const response = await axios.post('https://localhost:5001/Todo/', data, {
          headers: {
            'Content-Type': 'application/json',
          },
        });

        if (response.status === 200) {
          // Handle successful response
        } else {
          // Handle error response
        }
      } catch (error) {
        // Handle error
      }

      props.handleOnSubmit(data);
    } else {
      errorMsg = 'Please fill out all the fields.';
    }
    setErrorMsg(errorMsg);
  };


  const handleInputChange = (event) => {
    const { name, value } = event.target;
    switch (name) {
      case 'quantity':
        if (value === '' || parseInt(value) === +value) {
          setData((prevState) => ({
            ...prevState,
            [name]: value
          }));
        }
        break;
      case 'price':
        if (value === '' || value.match(/^\d{1,}(\.\d{0,2})?$/)) {
          setData((prevState) => ({
            ...prevState,
            [name]: value
          }));
        }
        break;
      case 'Description':
      case 'Module':
      case 'Priority':
      case 'RequestedPerson':
        setData((prevState) => ({
          ...prevState,
          [name]: value
        }));
        break;
      default:
        break;
    }
  };
  return (
    <div className="main-form">
      {errorMsg && <p className="errorMsg">{errorMsg}</p>}
      <Form onSubmit={handleOnSubmit}>
        <Form.Group controlId="RequestedPerson">
          <Form.Label>Проблема</Form.Label>
          <Form.Control
            className="input-control"
            type="string"
            name="RequestedPerson"
            value={RequestedPerson}
            placeholder="Имя"
            onChange={handleInputChange}
          />
        </Form.Group> 
        <Form.Group controlId="Module">
          <Form.Label>Модуль</Form.Label>
          <Form.Control
            className="input-control"
            type="string"
            name="Module"
            value={Module}
            placeholder="Модуль | ICC | Панель"
            onChange={handleInputChange}
            />
        </Form.Group>
     
        <Form.Group controlId="Description">
          <Form.Label>Описание</Form.Label>
          <Form.Control
            className="input-control"
            type="string"
            name="Description"
            value={Description}
            placeholder="Описание"
            onChange={handleInputChange}
          />
        </Form.Group>
   
        <Form.Group controlId="Priority">
          <Form.Label>Приоритет</Form.Label>
          <Form.Control
            className="input-control"
            type="string"
            name="Priority"
            value={Priority}
            placeholder="Приоритет"
            onChange={handleInputChange}
          />
        </Form.Group>
       
        <Button variant="primary" type="submit" className="submit-btn">
          Отправить
        </Button>
      </Form>
    </div>
  );
};

export default DataForm;
