import axios from 'axios';
import Constants from './constants'

const helpers = { 
    startNewGame(){
        return axios.get(Constants.GAME_SESSION_URL).then(response => {
            return response.data;
        }).catch((error) => {
            throw new Error(Constants.GAME_FETCH_ERROR);
        });
    },

    makeBoardMarkRequest(requestedMove) {
        const baseURL = Constants.CREATE_MOVE_URL;
        
        const data = {
            RequestedCellPosition: requestedMove
        };
        
        const headers = Constants.AXIOS_JSON_HEADERS;

        return axios.post(baseURL, data, headers).then((response) => {
            return response.data;
        }).catch((error) => {
            throw new Error(Constants.BOARD_MARK_REQUEST_ERROR);
        });
    }
};






export default helpers;