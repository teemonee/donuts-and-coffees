import axios from 'axios';

const helpers = {
    startNewGame(){
        return axios.get('/api/GetNewGameSession').then(response => {
            return response.data
        })
    }
};

export default helpers;