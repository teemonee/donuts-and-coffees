import React, { Component } from 'react';
import Board from '../components/Board';
import helpers from "../utils/helpers";

class Game extends Component {

  constructor(props){
    super(props);
    this.state = {
      moves:[],
      error:""
    }
  }

  componentDidMount(){
    this.getNewGame().then(data => {
      this.setState({
        moves: data.board.spaces,
      })
    }).catch((error) => {
      this.setState({
        error: "Cannot set board"
      })
    })
  }

  getNewGame(){
    return helpers.startNewGame();
  }

  selectSquare(index){
    console.log(index);
  }
  
  render() {
    const { moves } = this.state;

    return(
      <div>
        <Board 
          moves={moves} 
          selectSquare={(index) => this.selectSquare(index)}
        />
      </div>
    )
  }
}

export default Game;
