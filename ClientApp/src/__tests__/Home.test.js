import React from 'react';
import { shallow } from 'enzyme';
import { Home } from '../views/Home';
import Board from '../components/Board'

describe('Home Component', () => {
    it('renders without crashing', () => {
        shallow(<Home />);
    });
    
    it('renders board component', () => {
        const wrapper = shallow(<Home />);
        
        expect(wrapper.find(Board)).toHaveLength(1);
    })
});


