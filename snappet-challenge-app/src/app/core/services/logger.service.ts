import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {
  logError(message: string) {
    console.error('LoggingService: ' + message);
  }
}
