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
    
});