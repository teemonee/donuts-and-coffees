import axios from 'axios';

const helpers = {
    startNewGame(){
        return axios.get('/api/Game/GetNewGameSession').then(response => {
            return response.data[0];
        })
    }
};

export default helpers;