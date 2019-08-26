import React, { Component } from "react";
import Board from "../components/Board";
import helpers from "../utils/helpers";
import Constants from "../utils/constants";

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
        error: Constants.LOADING_ERROR
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
        this.setState({
          moves: response.board.spaces
        })
      }).catch(error => {
        this.setState({
          error: Constants.LOADING_ERROR
        })
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
