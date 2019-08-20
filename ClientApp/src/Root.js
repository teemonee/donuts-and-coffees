import React, { Component } from 'react';
import { BrowserRouter } from 'react-router-dom';
import { Route } from 'react-router-dom';
import { Home } from './components/Home';
import { Values } from './components/Values';
import { Layout } from './components/Layout';

class Root extends Component {
  render () {
    return (
      <BrowserRouter>
        <Layout>
          <Route exact path='/' component={Home} />
          <Route path='/valued-data' component={Values} />
        </Layout>
      </BrowserRouter>
    );
  }
}

export default Root;
