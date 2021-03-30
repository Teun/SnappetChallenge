import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { from, Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  constructor(private http: HttpClient, private snack: MatSnackBar) {}

  getStudentsOverview(): Observable<any> {
    const url = environment.apiBaseUrl + '/api/students/overview';

    return this.http.get<any>(url).pipe(tap(), catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }

    this.snack.open(errorMessage, 'Ok', { duration: 4000 });

    console.log(errorMessage);
    console.log(err.error);
    return throwError(err.error);
  }
}
