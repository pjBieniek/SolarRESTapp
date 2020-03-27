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
      <LineChartContainer measurement="Percent_DPC_Time"/>
      <BarChartContainer measurement="Percent_DPC_Time"/>
      <LineChartContainer measurement="Percent_Idle_Time "/>
      <BarChartContainer measurement="Percent_Idle_Time "/>
      <LineChartContainer measurement="Percent_Interrupt_Time"/>
      <BarChartContainer measurement="Percent_Interrupt_Time"/>
      <LineChartContainer measurement="Percent_Privileged_Time"/>
      <BarChartContainer measurement="Percent_Privileged_Time"/>
      <LineChartContainer measurement="Percent_Processor_Time"/>
      <BarChartContainer measurement="Percent_Processor_Time"/>
      <LineChartContainer measurement="Percent_User_Time"/>
      <BarChartContainer measurement="Percent_User_Time"/>

      <DoughnutContainer/>

      <PolarContainer/>

      <div id='lineChart'></div>
    </div>
      )
  }
}


export default Charts;