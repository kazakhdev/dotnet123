import React, { useContext } from 'react';
import BookForm from './BookForm';
import { useParams } from 'react-router-dom';
import DataContext from '../context/BooksContext';

const EditBook = ({ history }) => {
  const { datas, setDatas } = useContext(DataContext);
  const { Id } = useParams();
  const dataToEdit = datas.find((data) => data.Id === Id);

  const handleOnSubmit = (data) => {
    const filteredData = datas.filter((book) => book.Id !== Id);
    setDatas([data, ...filteredData]);
    history.push('/');
  };

  return (
    <div>
      <BookForm data={dataToEdit} handleOnSubmit={handleOnSubmit} />
    </div>
  );
};

export default EditBook;
