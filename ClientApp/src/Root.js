import React, { Component } from 'react';
import { BrowserRouter } from 'react-router-dom';
import { Route } from 'react-router-dom';
import Home from './views/Home';
import Layout from './components/Layout';

class Root extends Component {
  render () {
    return (
      <BrowserRouter>
        <Layout>
          <Route exact path='/' component={Home} />
        </Layout>
      </BrowserRouter>
    );
  }
}

export default Root;

