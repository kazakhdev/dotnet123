import React, { useContext } from 'react';
import _ from 'lodash';
import Data from './Data';
import DataContext from '../context/DataContext';

const DataList = () => {
  const { datas, setDatas } = useContext(DataContext);

  const handleRemoveBook = (id) => {
    setDatas(datas.filter((data) => data.id !== id));
  };

  return (
    <React.Fragment>
      <div className="book-list">
        {!_.isEmpty(datas) ? (
          datas.map((data) => 
          (<Data key={data.id} {...data} handleRemoveBook={handleRemoveBook} />))) 
          :(
          <p className="message">No books available. Please add some books.</p>
          )}
      </div>
    </React.Fragment>
  );
};

export default DataList;
