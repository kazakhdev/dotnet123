import React, { useContext } from 'react';
import DataForm from './DataForm';
import { useParams } from 'react-router-dom';
import DataContext from '../context/DataContext';

const EditData = ({ history }) => {
  const { datas, setDatas } = useContext(DataContext);
  const { id } = useParams();
  const dataToEdit = datas.find((data) => data.id === id);

  const handleOnSubmit = (data) => {
    const filteredData = datas.filter((data) => data.id !== id);
    setDatas([data, ...filteredData]);
    history.push('/');
  };

  return (
    <div>
      <DataForm data={dataToEdit} handleOnSubmit={handleOnSubmit} />
    </div>
  );
};

export default EditData;
