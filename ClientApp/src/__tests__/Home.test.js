import React from 'react';
import { shallow } from 'enzyme';
import Home from '../views/Home';
import Game from '../components/Game'

describe('Home Component', () => {
    it('renders without crashing', () => {
        shallow(<Home />);
    });
    
    it('renders board component', () => {
        const wrapper = shallow(<Home />);
        
        expect(wrapper.find(Game)).toHaveLength(1);
    });
});


