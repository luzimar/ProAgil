import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: Evento[] = [];
  eventosFiltrados: Evento[] = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  modalRef: BsModalRef;
  registerForm: FormGroup;

  // tslint:disable-next-line:variable-name
  _filtroLista: string;
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  constructor(private eventoService: EventoService,
              private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>): void {
     this.modalRef = this.modalService.show(template);
  }

  ngOnInit(): void {
    this.obterEventos();
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1);
  }
  alternarImagem(): void {
    this.mostrarImagem = !this.mostrarImagem;
  }

  validation(): void {
      this.registerForm = new FormGroup({
        tema: new FormControl(),
        local: new FormControl(),
        dataEvento: new FormControl(),
        qtdPessoas: new FormControl(),
        telefone: new FormControl(),
        email: new FormControl()
      });
  }

  salvarAlteracao(): void {

  }

  obterEventos(): void {
    // tslint:disable-next-line:variable-name
    this.eventoService.obterEventos().subscribe((_eventos: Evento[]) => {
    this.eventos = _eventos;
    this.eventosFiltrados = this.eventos;
  }, error => console.log(error));
}
}
