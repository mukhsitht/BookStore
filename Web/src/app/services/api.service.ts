import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:7218';
  constructor(private http: HttpClient) { }

  getData<T>(path: string): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}/${path}`).pipe(catchError(this.handleError));
  }

  post<T>(path: string, jsonData: any): Observable<T> {
    return this.http.post<T>(`${this.apiUrl}/${path}`, jsonData).pipe(catchError(this.handleError));
  }

  put<T>(path: string, jsonData: any): Observable<T> {
    return this.http.put<T>(`${this.apiUrl}/${path}`, jsonData).pipe(catchError(this.handleError));
  }

  delete<T>(path: string): Observable<T> {
    return this.http.delete<T>(`${this.apiUrl}/${path}`).pipe(catchError(this.handleError));
  }

  private handleError(error: any) {
    console.error('An error occurred:', error);
    return throwError("Something went wrong. Please try again later");
  }
}
