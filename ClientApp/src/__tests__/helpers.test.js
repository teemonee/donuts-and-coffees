import React from 'react';
import axios from 'axios';
import helpers from '../utils/helpers'

jest.mock('axios');

describe('api calls', () => {
    
    it('fetches board data', () => {
        axios.get.mockResolvedValueOnce({data: {board: ["X","O"]}});
        return helpers.startNewGame().then(response => {
            expect(response).toEqual({board: ["X","O"]});
        });
    });
    
    it('makes post request to update game session items', () => {
        axios.post.mockResolvedValueOnce({data: {requestedCellPosition:5}});
        
        return helpers.makeBoardMarkRequest(5).then(response => {
            expect(response).toEqual({requestedCellPosition:5});
        })
    });
});