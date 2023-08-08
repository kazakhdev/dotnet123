import React from 'react';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';
import Header from '../components/Header';
import AddData from '../components/AddData';
import DataList from '../components/DataList';
import useLocalStorage from '../hooks/useLocalStorage';
import EditData from '../components/EditData';
import BooksContext from '../context/DataContext';

const AppRouter = () => {
  const [datas, setDatas] = useLocalStorage('datas', []);

  return (
    <BrowserRouter>
      <div>
        <Header />
        <div className="main-content">
          <BooksContext.Provider value={{ datas, setDatas }}>
            <Switch>
              <Route component={DataList} path="/" exact={true} />
              <Route component={AddData} path="/add" />
              <Route component={EditData} path="/edit/:id" />
              <Route component={() => <Redirect to="/" />} />
            </Switch>
          </BooksContext.Provider>
        </div>
      </div>
    </BrowserRouter>
  );
};

export default AppRouter;
