import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import { v4 as uuidv4 } from 'uuid';

const DataForm = (props) => {
  const [data, setData] = useState(() => {
    return {
      Id: props.data ? props.data.Id : '',
      Description: props.data ? props.data.Description : '',
      Module: props.data ? props.data.Module : '',
      Priority: props.data ? props.data.Priority : '',
      RequestedPerson: props.data ? props.data.RequestedPerson : '',
      System: props.data ? props.data.System : '',
      Requesttype: props.data ? props.data.Requesttype : ''
    };
  });

  const [errorMsg, setErrorMsg] = useState('');
  const { Id, Description, System, Requesttype, Module, RequestedPerson, Priority } = data;

  const handleOnSubmit = (event) => {
    event.preventDefault();
    const values = [Id, Description, System, Requesttype, Module, RequestedPerson, Priority];
    let errorMsg = '';

    const allFieldsFilled = values.every((field) => {
      const value = `${field}`.trim();
      return value !== '' && value !== '0';
    });

    if (allFieldsFilled) {
      const data = {
        id: uuidv4(),
        Id, Description, System, Requesttype, Module, RequestedPerson, Priority,
        date: new Date()
      };
      props.handleOnSubmit(data);
    } else {
      errorMsg = 'Please fill out all the fields.';
    }
    setErrorMsg(errorMsg);
  };

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    switch (name) {
      case 'System':
        if (value === '' || parseInt(value) === +value) {
          setData((prevState) => ({
            ...prevState,
            [name]: value
          }));
        }
        break;
      case 'Priority':
        if (value === '') {
          setData((prevState) => ({
            ...prevState,
            [name]: value
          }));
        }
        break;
      default:
        setData((prevState) => ({
          ...prevState,
          [name]: value
        }));
    }
  };

  return (
    <div className="main-form">
      {errorMsg && <p className="errorMsg">{errorMsg}</p>}
      <Form onSubmit={handleOnSubmit}>
        <Form.Group controlId="name">
          <Form.Label>Наименование</Form.Label>
          <Form.Control
            className="input-control"
            type="text"
            name="Id"
            value={Id}
            placeholder="Enter name of book"
            onChange={handleInputChange}
          />
        </Form.Group>
        <Form.Group controlId="Description">
          <Form.Label>Описание</Form.Label>
          <Form.Control
            className="input-control"
            type="text"
            name="Description"
            value={Description}
            placeholder="Enter name of author"
            onChange={handleInputChange}
          />
        </Form.Group>
        <Form.Group controlId="Module">
          <Form.Label>Модуль</Form.Label>
          <Form.Control
            className="input-control"
            type="number"
            name="Module"
            value={Module}
            placeholder="Enter available quantity"
            onChange={handleInputChange}
          />
        </Form.Group>
        <Form.Group controlId="Priority">
          <Form.Label>Приоритет</Form.Label>
          <Form.Control
            className="input-control"
            type="text"
            name="Priority"
            value={Priority}
            placeholder="Enter price of book"
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
