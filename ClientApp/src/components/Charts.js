import React, { Component } from 'react';
import {Line} from 'react-chartjs-2';
import {ChartContainer} from '../Containers/ChartContainer';
import {LineChartContainer} from '../Containers/LineChartContainer';


export class Charts extends Component {
  static displayName = Charts.name;

  constructor(props) {
    super(props);
    this.state = { name: 'visualize', chartData:{dpcData:{}, idleData:{}, interruptData:{}, privilegedData:{}, procData:{}, userData:{}}, loading: true };
  }

  // componentDidMount() {
  //   fetch('https://localhost:44395/api/influx/databases/telegrafAllData',  {method: 'GET'})
  //     .then(res => res.json())
  //     .then(json => {
  //       console.log(json);
  //       let currentData = json[0].values;
  //       let dateLabels = [];
  //       let percent_dpc_time = [];
  //       let percent_idle_time = [];
  //       let percent_interrupt_time = [];
  //       let percent_privileged_time = [];
  //       let percent_proc_time = [];
  //       let percent_user_time = [];
  //       currentData.forEach(record => {
  //         dateLabels.push(record[0]);
  //         percent_dpc_time.push(record[1])
  //         percent_idle_time.push(record[2])
  //         percent_interrupt_time.push(record[3])
  //         percent_privileged_time.push(record[4])
  //         percent_proc_time.push(record[5])
  //         percent_user_time.push(record[6])
  //       });
  //       console.log(dateLabels)
  //       console.log(percent_dpc_time)
  //       this.setState({
  //         loading: false,
  //         name: json[0].name,
  //         chartData:{
  //           dpcData:{
  //           labels: dateLabels,
  //           datasets:[
  //             {
  //               label: 'Dpc usage [%]',
  //               data: percent_dpc_time,
  //             }
  //           ]},
  //           idleData:{
  //             labels: dateLabels,
  //             datasets:[
  //               {
  //                 label: 'Idle  [%]',
  //                 data: percent_idle_time,
  //               }
  //             ]},
  //           interruptData:{
  //           labels: dateLabels,
  //           datasets:[
  //             {
  //               label: 'interrupt [%]',
  //               data: percent_interrupt_time,
  //             }
  //           ]},
  //           privilegedData:{
  //             labels: dateLabels,
  //             datasets:[
  //               {
  //                 label: 'privileged [%]',
  //                 data: percent_privileged_time,
  //               }
  //             ]},
  //           procData:{
  //           labels: dateLabels,
  //           datasets:[
  //             {
  //               label: 'proc [%]',
  //               data: percent_proc_time,
  //             }
  //           ]},
  //           userData:{
  //             labels: dateLabels,
  //             datasets:[
  //               {
  //                 label: 'user [%]',
  //                 data: percent_user_time,
  //               }
  //             ]},
  //         }
  //       })
  //     });
  // }

  render() {
    return (
    <div>
      {/* <Line
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
      <ChartContainer specificChartData={this.state.chartData.idleData} measurement="percent idle / time"/> */}
      <LineChartContainer measurement="Percent_DPC_Time"/>
      <LineChartContainer measurement="Percent_Idle_Time"/>
      <LineChartContainer measurement="Percent_Interrupt_Time"/>
      <LineChartContainer measurement="Percent_Privileged_Time"/>
      <LineChartContainer measurement="Percent_Processor_Time"/>
      <LineChartContainer measurement="Percent_User_Time"/>

      <div id='lineChart'></div>
    </div>
      )
  }
}


export default Charts;