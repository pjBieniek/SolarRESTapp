import React, { Component } from 'react';
import {Doughnut} from 'react-chartjs-2';

export class DoughnutContainer extends Component{
    constructor(props){
        super(props);
        this.state={
            name:'doughnut chart',
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
        fetch('https://localhost:44395/api/influx/databases/telegrafAllData?limit=1',  {method: 'GET'})
            .then(res => res.json())
            .then(json => {
                let dateLabels = json[0].columns.slice(1,7);
                let values = json[0].values[0].slice(1,7);
                // console.log(json[0]);
                this.setState({
                name: this.props.simpleTitle,
                chartData: {
                    labels: dateLabels,
                    datasets: [{
                        label:'usage [%]',
                        data: values,
                        backgroundColor:[
                            'rgba(255, 99, 132, 0.6)',
                            'rgba(54, 162, 235, 0.6)',
                            'rgba(255, 206, 86, 0.6)',
                            'rgba(75, 192, 192, 0.6)',
                            'rgba(153, 102, 255, 0.6)',
                            'rgba(255, 159, 64, 0.6)'
                          ]
                    }]
                },
                loading: false,
                });
            });
    }

    render(){
        return (
            <div className="chart">
                <Doughnut
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

export default DoughnutContainer;