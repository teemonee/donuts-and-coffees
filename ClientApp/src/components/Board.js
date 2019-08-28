import React, { Component } from 'react';
import Square from './Square';
import Grid from '@material-ui/core/Grid';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';

class Board extends Component {
  
  render(){
    let moves = this.props["moves"] || [];
    let selectSquare = this.props["selectSquare"];
    let disabledButtons = this.props["disabledButtons"];
    
    let renderSquare = 
      moves.map((move, key) => (
        <GridListTile key={key}>
          <Square
            value={move}
            onClick={() => selectSquare(move)}
            disabled={disabledButtons[move]}
          />
        </GridListTile>
      ))
    
    return(
      <div>
        <Grid style={{width:600}}>
          <GridList cols={3} justify="Center">
            {renderSquare}
          </GridList>
        </Grid>
      </div>
    )
  }
}

export default Board;