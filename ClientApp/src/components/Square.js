import * as React from 'react';
import Button from '@material-ui/core/Button';

const Square = (props) => (
    <Button
        style={{minWidth: "150px", minHeight: '150px'}}
        variant="contained"
        color="primary"
        onClick={props.onClick}
        disabled={props.disabled}
    >
        {props.value}
    </Button>
);


export default Square;
