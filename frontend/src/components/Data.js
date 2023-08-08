import React from 'react';
import { Button, Card } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';

const Data = ({
  id,
  Module,
  Description,
  System,
  Priority,
  RequestedPerson,
  handleRemoveBook,
}) => {
  const history = useHistory();

  return (
    <Card style={{ width: '18rem' }} className="book">
      <Card.Body>
       
        <div className="book-details">
          <div>Description: {Description}</div>
          <div>Priority: {Priority} </div>
          <div>Модуль: {Module} </div>
          <div>RequestedPerson: {RequestedPerson} </div>
          <div>Date: {new Date().toDateString()}</div>
        </div>
        <Button variant="primary" onClick={() => history.push(`/edit/${id}`)}>
          Edit
        </Button>{' '}
        <Button variant="danger" onClick={() => handleRemoveBook(id)}>
          Delete
        </Button>
      </Card.Body>
    </Card>
  );
};

export default Data;
