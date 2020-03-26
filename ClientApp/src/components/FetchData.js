import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { name: 'init', columns:[], values: [], loading: true };
  }

  componentDidMount() {
    fetch('https://localhost:44395/api/influx/databases/telegraf',  {method: 'GET'})
      .then(res => res.json())
      .then(json => {
        this.setState({
          loading: false,
          name: json[0].name,
          columns: json[0].columns,
          values: json[0].values,
        })
      });
  }

  static renderData(columns, values) {
    return (
      // do przejrzenia: react-table, react-table component
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            {/* <th>{columns[0]}</th> */}
            <th>{columns[1]}</th>
            <th>{columns[2]}</th>
            <th>{columns[3]}</th>
            <th>{columns[4]}</th>
            <th>{columns[5]}</th>
            <th>{columns[6]}</th>
            <th>{columns[7]}</th>
            <th>{columns[8]}</th>
            <th>{columns[9]}</th>
          </tr>
        </thead>
        <tbody>
          {values.map(values =>
            <tr key={values[0]}>
              {/* <td>{convertDateSimple(values[0])}</td> */}
              <td>{values[1]}</td>
              <td>{values[2]}</td>
              <td>{values[3]}</td>
              <td>{values[4]}</td>
              <td>{values[5]}</td>
              <td>{values[6]}</td>
              <td>{values[7]}</td>
              <td>{values[8]}</td>
              <td>{values[9]}</td>
            </tr>
          )}
        </tbody>
      </table>
      
    );
  }

  render() {
    var {loading, name, columns, values} = this.state;
    let contents = loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderData(columns, values);

    return (
      <div>
        <h1 id="tabelLabel" >Influx {name}</h1>
        <p>Data fetched from server.</p>
        {contents}
      </div>
    );
  }

  convertDateSimple(timesTamp) {
    let myDate = new Date(timesTamp*1000);
    let months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'];
    let month = months[myDate.getMonth()];
    let date = myDate.getDate();
    let hour = myDate.getHours();
    let min = myDate.getMinutes();
    if (min<10){
        min = '0'+min;
    }
    let outPut = date + ' ' + month + ' ' + hour + ':' + min;
    return outPut;
  }
}
