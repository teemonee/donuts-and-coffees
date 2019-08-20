import React, { Component } from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import { Values } from './components/Values';
import { Layout } from './components/Layout'

class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/valued-data' component={Values} />
      </Layout>
    );
  }
}

export default App;