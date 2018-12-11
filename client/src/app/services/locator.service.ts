import { Injectable } from '@angular/core';
import { Config } from '../models/config';

@Injectable({
  providedIn: 'root'
})
export class LocatorService {

  initialAPI = '/RESTAPI/';

  config: Config;
  constructor() {
    this.config = new Config();
    this.config.GetReport = this.initialAPI + 'GetReport';
    this.config.GetStudentDetails = this.initialAPI + 'GetStudentDetails';
   }
}
