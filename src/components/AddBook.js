import React, { useContext } from 'react';
import BookForm from './BookForm';
import DataContext from '../context/BooksContext';

const AddBook = ({ history }) => {
  const { datas, setDatas } = useContext(DataContext);

  const handleOnSubmit = (data) => {
    setDatas([datas, ...datas]);
    history.push('/');
  };

  return (
    <React.Fragment>
      <BookForm handleOnSubmit={handleOnSubmit} />
    </React.Fragment>
  );
};

export default AddBook;
