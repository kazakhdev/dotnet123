import React, { useContext } from 'react';
import DataForm from './DataForm';
import DataContext from '../context/DataContext';

const AddData = ({ history }) => {
  const { datas, setDatas } = useContext(DataContext);

  const handleOnSubmit = (data) => {
    setDatas([data, ...datas]);
    history.push('/');
  };

  return (
    <React.Fragment>
      <DataForm handleOnSubmit={handleOnSubmit} />
    </React.Fragment>
  );
};

export default AddData;
