import React, { Component } from "react";
import Board from "../components/Board";
import helpers from "../utils/helpers";
import Constants from "../utils/constants";

class Game extends Component {

  constructor(props){
    super(props);
    this.state = {
      moves:[],
      disabledButtons:[],
      error:""
    }
  }

  componentDidMount(){
    helpers.startNewGame().then(data => {
      this.setState({
        moves: data.board.spaces,
        disabledButtons: new Array(data["board"].spaces.length).fill(false)
      })
    }).catch((error) => {
      this.setState({
        error: Constants.LOADING_ERROR
      })
    });
  }
  
  selectSquare(cellPosition){
    return this.postNewMark(cellPosition);
  }
  

  postNewMark(requestedMove) {
    const newDisabledButtons = this.state["disabledButtons"];
    newDisabledButtons[requestedMove]=true;
    
    helpers.makeBoardMarkRequest(requestedMove)
      .then((response) => {
        this.setState({
            moves: response["board"].spaces,
            disabledButtons: Object.assign(this.state["disabledButtons"], newDisabledButtons)
        })
      }).catch(error => {
        this.setState({
          error: Constants.LOADING_ERROR
        })
    });
  }
  
  render() {
    const { moves, disabledButtons } = this.state;

    return(
      <div>
        <Board
          disabledButtons={disabledButtons}
          moves={moves} 
          selectSquare={(cellPosition) => this.selectSquare(cellPosition)}
        />
      </div>
    )
  }
}

export default Game;
