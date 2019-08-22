import React from 'react';
import ReactDOM from 'react-dom';
import { shallow, mount } from 'enzyme';
import Board from '../components/Board';
import Square from '../components/Square';
import axios from 'axios';

jest.mock('axios');

describe('board component', () => {
    let boardComponent;
    const mockResults = {board:[]};
    const mockItems = mockResults.data.board;
    beforeEach(() => {
        boardComponent = mount(<Board />);
    });
    
    it('renders nine square components', () => {
        expect(boardComponent.find(Square)).toHaveLength(9);
    });
    
    it('fetches new game', () => {
        axios.get.mockResolvedValueOnce(mockResults);
        return boardComponent.instance().getNewGame().then(response => {
            expect(response).toEqual(mockResults);
            expect(boardComponent.state('moves')).toEqual(mockItems);
        });
    });
});