import React, { Component } from 'react';
import {HorizontalBar} from 'react-chartjs-2';

export class BarChartContainer extends Component{
    constructor(props){
        super(props);
        this.state={
            name:'bar chart',
            chartData:{},
            loading: true
        }
    }

    static defaultProps={
        displayTitle:true,
        displayLegend:true,
        legendPosition:'right',
        measurement:'CPU'
    }

    componentDidMount(){
        this.chartID = setInterval(
            () => this.tick(),
            10000
        );
    }

    componentWillUnmount(){
        clearInterval(this.chartID)
    }

    tick(){
        fetch('https://localhost:44395/api/influx/databases/telegraf?field='+this.props.measurement+'&limit=20',  {method: 'GET'})
            .then(res => res.json())
            .then(json => {
                let dateLabels = [];
                let values = [];
                json[0].values.forEach(record =>{
                    dateLabels.push(record[0].slice(-9, -1));
                    values.push(record[1]);
                })
                this.setState({
                name: this.props.simpleTitle,
                chartData: {
                    labels: dateLabels.reverse(),
                    datasets: [{
                        label: json[0].columns[1] + ' usage [%]',
                        data: values.reverse(),
                        backgroundColor:"#70CAD1",
                    }]
                },
                loading: false,
                });
            });
    }

    render(){
        return (
            <div className="chart">
                <HorizontalBar
                    data={this.state.chartData}
                    options={{
                      title:{
                        display:this.props.displayTitle,
                        text:this.state.name,
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

export default BarChartContainer;