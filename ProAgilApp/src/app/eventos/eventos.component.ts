import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Evento from './evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: Evento[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.obterEventos();
  }

  obterEventos(){
    this.http.get<Evento[]>('https://localhost:5001/api/eventos').subscribe(response => {
      this.eventos = response;
    }, error => console.log(error));
  }
}
