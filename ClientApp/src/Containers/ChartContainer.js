import React, { Component } from 'react';
import {Line} from 'react-chartjs-2';

export class ChartContainer extends Component{
    constructor(props){
        super(props);
        this.state={
            specificChartData: props.specificChartData
            
        }
        console.log(this.state.specificChartData)
    }

    static defaultProps={
        displayTitle:true,
        displayLegend:true,
        legendPosition:'right',
        measurement:'CPU'
    }

    render(){
        return (
            <div className="chart">
                <Line 
                    data={this.props.specificChartData}
                    options={{
                      title:{
                        display:this.props.displayTitle,
                        text:this.props.measurement,
                        fontSize:25
                      },
                      legend:{
                        display:this.props.displayLegend,
                        position:'right'
                      }
                    }}
                />
            </div>
        )
    }
}

export default ChartContainer;
