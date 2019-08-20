
import React, { Component } from 'react';

export class Values extends Component {
  static displayName = Values.name;

  constructor (props) {
    super(props);
    this.state = { values: [], loading: true };

    fetch('api/Values/Get')
        .then(response => response.json())
        .then(data => {
          console.log(data);
          this.setState({ values: data, loading: false });
      });
  }

  static renderValueTable (values) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Lines Below</th>
          </tr>
        </thead>
        <tbody>
          {values.map(value =>
            <tr key={value.id}>
              <td>{value.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Values.renderValueTable(this.state.values);

    return (
      <div>
        <h1>Just some strings here</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
