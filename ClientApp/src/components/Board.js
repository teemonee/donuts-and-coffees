import React, { Component } from 'react';
import Square from './Square';
import Grid from '@material-ui/core/Grid';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';

export default class Board extends Component {
    renderSquare(list){
        return list.map(i => <GridListTile><Square key={i} value={i}/></GridListTile>)
    }
    
    render(){
        const list = [1,2,3,4,5,6,7,8,9];
        
        return(
            <Grid style={{width:600}}>
                <GridList cols={3} justify="Center">
                        {this.renderSquare(list)}
                </GridList>
            </Grid>
        )
    }
}