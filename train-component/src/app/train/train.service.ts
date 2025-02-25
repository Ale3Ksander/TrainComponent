import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TrainComponent } from './types/types';

@Injectable({
  providedIn: 'root',
})
export class TrainComponentService {
  private apiUrl = 'http://localhost:5001/train-component';

  constructor(private http: HttpClient) {}

  getComponents(page: number, search?: string): Observable<TrainComponent[]> {
    let url = `${this.apiUrl}?page=${page}`;

    if (search) url += `&search=${search}`;

    return this.http.get<TrainComponent[]>(url, {
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS"
      }
    });
  }

  createComponent(component: TrainComponent): Observable<string> {
    return this.http.post(this.apiUrl, component, { responseType: 'text' });
  }

  updateComponent(component: TrainComponent): Observable<string> {
    return this.http.put(`${this.apiUrl}/${component.id}`, component, { responseType: 'text' });
  }

  updateQuantity(id: number, quantity: number): Observable<string> {
    return this.http.patch(`${this.apiUrl}/${id}/quantity`, quantity, { responseType: 'text' });
  }
}
