import React, { Component } from 'react';
import Square from './Square';
import Grid from '@material-ui/core/Grid';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import helpers from '../utils/helpers';

export default class Board extends Component {
    constructor(props){
        super(props);
        this.state = {
            moves:[]
        }
    }
    
    getNewGame(){
        return helpers.startNewGame();
    }
    
    componentDidMount(){
        this.getNewGame().then(data => {
            if(data.board.spaces){
                this.setState({
                    moves: data.board.spaces
                });
            }
        });
    }

    renderSquare(){
        return [...Array(9)].map((position, index) => 
            <GridListTile key={index}>
              <Square value={this.state.moves[position] || ""}/>
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