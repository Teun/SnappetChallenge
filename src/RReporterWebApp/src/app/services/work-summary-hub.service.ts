import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";

@Injectable({
  providedIn: 'root'
})
export class WorkSummaryHubService {

  constructor() { }

  public data: any;

  private hubConnection: signalR.HubConnection
  private listenerList = [];
  private connectedPromise : Promise<any>;

  public startConnection = () => {
    
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/hub')
      .build();

    this.connectedPromise = this.hubConnection.start();
    this.connectedPromise
      .then(() => {
        console.log('Connection started');
        this.hubConnection.on('learningObjectiveSummaryUpdate', (data) => {
          this.listenerList.forEach(l => l(data));
          console.log(data);
        });
      })
      .catch(err => console.log('Error while starting connection: ' + err))

    
  }

  public async getWorkSummary(classId: number) : Promise<any> {
    await this.connectedPromise;
    return await this.hubConnection.invoke("GetWorkSummary", classId);
  }

  public addLearningObjectiveSummaryListener = (listener) => {
    this.listenerList.push(listener);
  }

  public removeLearningObjectiveSummaryListener = (listener) => {
    this.listenerList.splice(this.listenerList.findIndex(listener), 1);
  }

}
