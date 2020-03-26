import React, { Component } from 'react';
import {Line} from 'react-chartjs-2';
import {ChartContainer} from './ChartContainer';


export class Charts extends Component {
  static displayName = Charts.name;

  constructor(props) {
    super(props);
    this.state = { name: 'visualize', chartData:{dpcData:{}, idleData:{}, interruptData:{}, privilegedData:{}, procData:{}, userData:{}}, loading: true };
  }

  componentDidMount() {
    fetch('https://localhost:44395/api/influx/databases/telegraf',  {method: 'GET'})
      .then(res => res.json())
      .then(json => {
        console.log(json);
        let currentData = json[0].values;
        let dateLabels = [];
        let percent_dpc_time = [];
        let percent_idle_time = [];
        let percent_interrupt_time = [];
        let percent_privileged_time = [];
        let percent_proc_time = [];
        let percent_user_time = [];
        currentData.forEach(record => {
          dateLabels.push(record[0]);
          percent_dpc_time.push(record[1])
          percent_idle_time.push(record[2])
          percent_interrupt_time.push(record[3])
          percent_privileged_time.push(record[4])
          percent_proc_time.push(record[5])
          percent_user_time.push(record[6])
        });
        console.log(dateLabels)
        console.log(percent_dpc_time)
        this.setState({
          loading: false,
          name: json[0].name,
          chartData:{
            dpcData:{
            labels: dateLabels.slice(-100),
            datasets:[
              {
                label: 'Dpc usage [%]',
                data: percent_dpc_time.slice(-100),
              }
            ]},
            idleData:{
              labels: dateLabels.slice(-100),
              datasets:[
                {
                  label: 'Idle  [%]',
                  data: percent_idle_time.slice(-100),
                }
              ]},
            interruptData:{
            labels: dateLabels.slice(-100),
            datasets:[
              {
                label: 'interrupt [%]',
                data: percent_interrupt_time.slice(-100),
              }
            ]},
            privilegedData:{
              labels: dateLabels.slice(-100),
              datasets:[
                {
                  label: 'privileged [%]',
                  data: percent_privileged_time.slice(-100),
                }
              ]},
            procData:{
            labels: dateLabels.slice(-100),
            datasets:[
              {
                label: 'proc [%]',
                data: percent_proc_time.slice(-100),
              }
            ]},
            userData:{
              labels: dateLabels.slice(-100),
              datasets:[
                {
                  label: 'user [%]',
                  data: percent_user_time.slice(-100),
                }
              ]},
          }
        })
      });
  }

  render() {
    return (
    <div>
      <Line
        data={this.state.chartData.dpcData}
        options={{
          title:{
            display:true,
            text:'percent dpc / time ',
            fontSize:25
          },
          legend:{
            display:true,
            position:'right'
          }
        }}
      />
      <ChartContainer specificChartData={this.state.chartData.idleData} measurement="percent idle / time"/>
      <Line
        data={this.state.chartData.idleData}
        options={{
          title:{
            display:true,
            text:'percent idle / time ',
            fontSize:25
          },
          legend:{
            display:true,
            position:'right'
          }
        }}
      />
    </div>
      )
  }
}


export default Charts;