import React, { Component } from 'react';
import Game from '../components/Game';
import Grid from '@material-ui/core/Grid';

class Home extends Component {

  render () {
    return (
      <div style={{textAlign:"center"}}>
        <h1>Donuts and Coffees</h1>
        <Grid container justify="center">
          <Game />
        </Grid>
      </div>
    );
  }
}

export default Home;
