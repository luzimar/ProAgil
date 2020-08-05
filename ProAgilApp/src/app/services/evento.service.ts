import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from '../models/Evento';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  baseURL = 'https://localhost:5001/api/eventos';

  constructor(private http: HttpClient) { }

  obterEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  obterEventoPorId(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }

  obterEventosPorTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/obterPorTema/${tema}`);
  }

  cadastrarEvento(evento: Evento): any {
    return this.http.post(this.baseURL, evento);
  }

  editarEvento(evento: Evento): any {
    return this.http.put(this.baseURL, evento);
  }

  excluirEvento(id: number): any {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
