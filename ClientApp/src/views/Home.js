import React, { Component } from 'react';
import Board from '../components/Board';
import Grid from '@material-ui/core/Grid';

export class Home extends Component {
    static displayName = Home.name;

    render () {
        return (
            <div style={{textAlign:"center"}}>
                <h1>Donuts and Coffees</h1>
                <Grid container justify="center">
                    <Board />
                </Grid>
            </div>
        );
    }
}