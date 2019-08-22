import React from 'react';
import { shallow } from 'enzyme';
import Board from '../components/Board';
import Square from '../components/Square';
import axios from 'axios';

jest.mock('axios');

describe('board component', () => {
    it('renders nine square components', () => {
        const wrapper = shallow(<Board/>);
        expect(wrapper.find(Square)).toHaveLength(9);
    });
});