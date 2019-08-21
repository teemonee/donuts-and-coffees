import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Root from './Root';
import * as serviceWorker from './serviceWorker';

const App = {
    run(){
        const rootElement = document.getElementById('root');
        ReactDOM.render(<Root />, rootElement)
    }
};

App.run();
serviceWorker.unregister();