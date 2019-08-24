import React, { Component } from 'react';
import Board from '../components/Board';
import helpers from "../utils/helpers";

export class Game extends Component {
  static displayName = Game.name;

  constructor(props){
    super(props);
    this.state = {
      moves:[],
      greeting:[]
    }
  }

  getNewGame(){
    return helpers.startNewGame();
  }

  componentDidMount(){
    this.getNewGame().then(data => {
      this.setState({
        moves: data.board.spaces || null,
      });
    });
  }
  
  render() {
    const { moves } = this.state;

    return(
      <div>
        <Board moves={moves} />
      </div>
    )
  }
}
