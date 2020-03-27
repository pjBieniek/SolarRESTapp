import React, { Component } from 'react';
import {LineChartContainer} from '../Containers/LineChartContainer';
import {BarChartContainer} from '../Containers/BarChartContainer';
import { DoughnutContainer } from '../Containers/DoughnutContainer';
import PolarContainer from '../Containers/PolarContainer';


export class Charts extends Component {
  static displayName = Charts.name;

  constructor(props) {
    super(props);
    this.state = { name: 'visualize', loading: true };
  }


  render() {
    return (
    <div>
      <LineChartContainer measurement="Percent_DPC_Time" simpleTitle="DPC"/>
      <BarChartContainer measurement="Percent_DPC_Time" simpleTitle="DPC"/>
      <LineChartContainer measurement="Percent_Idle_Time" simpleTitle="Idle"/>
      <BarChartContainer measurement="Percent_Idle_Time" simpleTitle="Idle"/>
      <LineChartContainer measurement="Percent_Interrupt_Time" simpleTitle="Interrupt"/>
      <BarChartContainer measurement="Percent_Interrupt_Time" simpleTitle="Interrupt"/>
      <LineChartContainer measurement="Percent_Privileged_Time" simpleTitle="Privileged"/>
      <BarChartContainer measurement="Percent_Privileged_Time" simpleTitle="Privileged"/>
      <LineChartContainer measurement="Percent_Processor_Time" simpleTitle="Processor"/>
      <BarChartContainer measurement="Percent_Processor_Time" simpleTitle="Processor"/>
      <LineChartContainer measurement="Percent_User_Time" simpleTitle="User"/>
      <BarChartContainer measurement="Percent_User_Time" simpleTitle="User"/>

      <DoughnutContainer/>

      <PolarContainer/>

      <div id='lineChart'></div>
    </div>
      )
  }
}


export default Charts;