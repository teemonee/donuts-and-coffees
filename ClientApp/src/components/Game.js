import React, { Component } from 'react';
import Board from '../components/Board';
import helpers from "../utils/helpers";

export class Game extends Component {
  static displayName = Game.name;

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
  
  render() {
    const { moves } = this.state;
    
    return(
      <Board moves={moves}/>
    )
  }
}
