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
    helpers.startNewGame().then(data => {
      this.setState({
        moves: data.board.spaces,
      })
    }).catch((error) => {
      this.setState({
        error: "Uh oh, something went wrong..."
      })
    });
  }
  
  selectSquare(cellPosition){
    console.log(cellPosition);
    return this.postNewMark(cellPosition);
  }
  

  postNewMark(requestedMove) {
    helpers.makeBoardMarkRequest(requestedMove)
      .then((response) => {
        console.log(response);
      }).catch(error => {
        console.log(error);
    });
  }
  
  render() {
    const { moves } = this.state;

    return(
      <div>
        <Board 
          moves={moves} 
          selectSquare={(cellPosition) => this.selectSquare(cellPosition)}
        />
      </div>
    )
  }
}

export default Game;
