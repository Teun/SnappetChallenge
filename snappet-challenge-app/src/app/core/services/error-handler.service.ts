import {ErrorHandler, Injectable, Injector} from '@angular/core';
import {HttpErrorResponse} from "@angular/common/http";
import {NotificationService} from "@core/services/notification.service";
import {LoggerService} from "@core/services/logger.service";

@Injectable()
export class ErrorHandlerService implements ErrorHandler{

  constructor(private injector: Injector) { }

  handleError(error: Error | HttpErrorResponse) {
    if (error instanceof HttpErrorResponse){
      const notificationService = this.injector.get(NotificationService);
      const loggerService = this.injector.get(LoggerService);
      loggerService.logError(error.message);
      const messageToShow = error.error instanceof ProgressEvent ? error.message : error.error;
      notificationService.showError(messageToShow);
    }
  }
}
