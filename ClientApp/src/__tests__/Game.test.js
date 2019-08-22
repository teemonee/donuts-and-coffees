import React from 'react';
import { shallow, mount } from 'enzyme';
import { Game } from '../components/Game';
import Board from '../components/Board';
import axios from 'axios';

describe('Game Component', () => {
  it('renders without crashing', () => {
      shallow(<Game />);
  });

  it('renders board component', () => {
      const wrapper = shallow(<Game />);

      expect(wrapper.find(Board)).toHaveLength(1);
  })

  let gameComponent;
  const mockResults = {board:[]};
  const mockItems = mockResults.data.board;
  beforeEach(() => {
    gameComponent = mount(<Game />);
  });
  
  it('fetches new game', () => {
    axios.get.mockResolvedValueOnce(mockResults);
    return gameComponent.instance().getNewGame().then(response => {
      expect(response).toEqual(mockResults);
      expect(gameComponent.state('moves')).toEqual(mockItems);
    });
  });
});