import React from 'react';
import { Button, Card } from 'react-bootstrap';
import { useHistory } from 'react-router-dom';

const Book = ({
  Id,
  Description,
  IsCompleted,
  System,
  Priority,
  DateTime,
  IsResponsible,
  Requesttype,
  handleRemoveBook,
  RequestedPerson
}) => {
  const history = useHistory();

  return (
    <Card style={{ width: '18rem' }} className="book">
      <Card.Body>
        <Card.Title className="book-title">{Id}</Card.Title>
        <div className="book-details">
          <div>Description: {Description}</div>
          <div>System: {System} </div>
          <div>Priority: {Priority} </div>
          <div>Date: {new Date(DateTime).toDateString()}</div>
        </div>
        <Button variant="primary" onClick={() => history.push(`/edit/${Id}`)}>
          Edit
        </Button>{' '}
        <Button variant="danger" onClick={() => handleRemoveBook(Id)}>
          Delete
        </Button>
      </Card.Body>
    </Card>
  );
};

export default Book;
