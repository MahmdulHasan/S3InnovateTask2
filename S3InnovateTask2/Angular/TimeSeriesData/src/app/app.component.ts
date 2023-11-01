import { Component, OnInit  } from '@angular/core';
import { DataService } from './data.service';
import { Building, Object, DataField, Reading } from './shared-models';
import 'chartjs-adapter-moment';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  buildings: Building[] = [];
  objects: Object[] = [];
  dataFields: DataField[] = [];
  selectedBuilding: Building | null = null;
  selectedObject: Object | null = null;
  selectedDataField: DataField | null = null;
  startDate: Date | null = new Date('2022-11-01');
  endDate: Date | null = new Date('2022-11-01');


  lineChartData: any[]  = [{ data: [], label: 'Value' }];
  lineChartLabels: string[] = [];


  chartOptions: any = {
    scales: {
      x: {
        type: 'timeseries',
        time: {
          unit: 'hour',
          stepSize: 1,
          displayFormats: {
            hour: 'HH:mm',
          },
        },
      },
      y: {
        beginAtZero: false, 
        suggestedMax: 50, 
      
      },
    },
  };

  constructor(private dataService: DataService) {
  }
  ngAfterViewInit() {
    this.dataService.getBuildings().subscribe((buildings) => (this.buildings = buildings));
    this.dataService.getObjects().subscribe((objects) => (this.objects = objects));
    this.dataService.getDataFields().subscribe((dataFields) => (this.dataFields = dataFields));
    this.fetchData();
  }

  fetchData() {
    this.dataService
    .getTimeSeriesData(
      this.selectedBuilding != null ? this.selectedBuilding.id : 0,
      this.selectedObject != null ? this.selectedObject.id : 0,
      this.selectedDataField != null ? this.selectedDataField.id : 0,
      this.startDate,
      this.endDate
    )
    .subscribe((data) => {
      this.lineChartData[0].data = [];
      this.data.forEach((item) => {
        this.lineChartData[0].data.push(item.value);
        const timestamp = new Date(item.timestamp);
        const label = `${timestamp.getHours().toString().padStart(2, '0')}:00`;
        this.lineChartLabels.push(label);
      });
      console.log('lineChartData:', this.lineChartData);
      console.log('lineChartLabels:', this.lineChartLabels);
    });
  }



  data = [
    {
      "value": 88.9,
      "timestamp": "2021-10-29T00:21:28.76"
    },
    {
      "value": 74.91,
      "timestamp": "2021-10-29T02:21:28.76"
    },
    {
      "value": 2.49,
      "timestamp": "2021-10-29T03:21:28.76"
    },
    {
      "value": 2.4901,
      "timestamp": "2021-10-29T04:21:28.76"
    },
    {
      "value": 51.91,
      "timestamp": "2021-10-29T05:21:28.76"
    },
    {
      "value": 53.62,
      "timestamp": "2021-10-29T06:21:28.76"
    },
    {
      "value": 8.9,
      "timestamp": "2021-10-29T23:21:28.76"
    },
    {
      "value": 47.47,
      "timestamp": "2021-10-29T23:21:28.76"
    },
    {
      "value": 37.72,
      "timestamp": "2021-10-29T23:21:28.76"
    },
    {
      "value": 57.81,
      "timestamp": "2021-10-29T23:21:28.76"
    },
    {
      "value": 91.43,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 11.22,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 43.2,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 36.4,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 7.57,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 71.48,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 79.21,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 13.52,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 38.65,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 63.46,
      "timestamp": "2021-10-29T23:22:28.7666667"
    },
    {
      "value": 78.8,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 69.98,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 11.57,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 27.84,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 45.77,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 14.89,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 26.02,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 95.76,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 54.06,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 87.29,
      "timestamp": "2021-10-29T23:23:28.77"
    },
    {
      "value": 15.75,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 58.92,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 84.41,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 85.69,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 52.69,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 1.11,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 69.91,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 92.13,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 26.12,
      "timestamp": "2021-10-29T23:24:28.7733333"
    },
    {
      "value": 34.4,
      "timestamp": "2021-10-29T23:24:28.7733333"
    }
  ];
	

}

