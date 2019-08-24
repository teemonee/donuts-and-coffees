import axios from 'axios';
import Constants from './constants'

const helpers = { 
    startNewGame(){
        return axios.get(Constants.NEW_GAME_URL).then(response => {
            return response.data;
        }).catch((error) => {
            throw new Error(Constants.GAME_FETCH_ERROR);
        })
    }
};

export default helpers;