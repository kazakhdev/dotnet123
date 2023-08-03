import React, { useContext } from 'react';
import _ from 'lodash';
import Book from './Book';
import DataContext from '../context/BooksContext';

const BooksList = () => {
  const { datas, setDatas } = useContext(DataContext);

  const handleRemoveBook = (Id) => {
    setDatas(datas.filter((data) => data.Id !== Id));
  };

  return (
    <React.Fragment>
      <div className="book-list">
        {!_.isEmpty(datas) ? (
          datas.map((data) => (
            <Book key={data.id} {...data} handleRemoveBook={handleRemoveBook} />
          ))
        ) : (
          <p className="message">No books available. Please add some books.</p>
        )}
      </div>
    </React.Fragment>
  );
};

export default BooksList;
