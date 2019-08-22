import axios from 'axios';
import Constants from './constants'

const helpers = {
    startNewGame(){
        return axios.get(Constants.NEW_GAME_URL).then(response => {
            return response.data[0];
        }).catch((error) => {
            throw new Error(Constants.Game_Fetch_Error);
        })
    }
};

export default helpers;