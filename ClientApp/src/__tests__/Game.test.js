import React from 'react';
import { shallow, mount} from 'enzyme';
import Game  from '../components/Game';
import Board from '../components/Board';
import axios from "axios"

jest.mock('axios');

describe('Game Component', () => {
  it('renders without crashing', () => {
      shallow(<Game />);
  });

  it('renders board component', () => {
      const wrapper = shallow(<Game />);

      expect(wrapper.find(Board)).toHaveLength(1);
  });

  let gameComponent;
  const mockResults = {data:{board:["X","O"]}};
  const mockItems = mockResults.data.board.spaces;
  
  it('fetches new game', async () => {
    gameComponent = mount(<Game />);
    axios.get.mockResolvedValueOnce(mockResults);
    
    expect(gameComponent.state.moves).toEqual(mockItems);
  });
});