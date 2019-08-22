import React, { Component } from 'react';
import Square from './Square';
import Grid from '@material-ui/core/Grid';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';


export default class Board extends Component {
    renderSquare(){
        return [...Array(9)].map((position, index) => 
            <GridListTile key={index}>
              <Square value={this.props.moves[position] || ""}/>
            </GridListTile>
        )  
    }
    
    render(){
        return(
            <Grid style={{width:600}}>
                <GridList cols={3} justify="Center">
                        {this.renderSquare()}
                </GridList>
            </Grid>
        )
    }
}
