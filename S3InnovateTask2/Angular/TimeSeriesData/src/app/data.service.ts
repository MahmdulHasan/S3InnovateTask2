import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Building, Object, DataField, Reading } from './shared-models';

@Injectable()
export class DataService {
  constructor(private http: HttpClient) {}

  getBuildings(): Observable<Building[]> {
    return this.http.get<Building[]>('https://localhost:7244/api/Building');
  }

  getObjects(): Observable<Object[]> {
    return this.http.get<Object[]>('https://localhost:7244/api/Object');
  }

  getDataFields(): Observable<DataField[]> {
    return this.http.get<DataField[]>('https://localhost:7244/api/DataField');
  }

  getTimeSeriesData(buildingId: number  , objectId: number, dataFieldId: number, startDate: Date | null, endDate: Date | null): Observable<Reading[]> {
    let url = 'https://localhost:7244/api/Reading?';

  if (buildingId !== null) {
    url += `buildingId=${buildingId}&`;
  }

  if (objectId !== null) {
    url += `objectId=${objectId}&`;
  }

  if (dataFieldId !== null) {
    url += `dataFieldId=${dataFieldId}&`;
  }

  if (startDate !== null) {
    url += `startDate=${new Date(startDate).toISOString()}&`;
  }

  if (endDate !== null) {
    url += `endDate=${new Date(endDate).toISOString()}&`;
  }

  if (url.endsWith('&')) {
    url = url.slice(0, -1);
  }
  return this.http.get<Reading[]>(url);
  }
}

