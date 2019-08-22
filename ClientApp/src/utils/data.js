import axios from 'axios';

const data = {
    startNewGame(){
        return axios.get('/api/GetNewGameSession').then(response => {
            return response.data
        })
    }
};

export default data;