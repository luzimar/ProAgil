import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale  } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { formatErrorResponse } from '../utils/Functions';

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  titulo = 'Eventos';
  eventos: Evento[] = [];
  evento: Evento = {} as Evento;
  eventosFiltrados: Evento[] = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  registerForm: FormGroup;
  operacao: string;
  loading = false;
  bodyExcluirEvento = '';
  dataEvento: any;
  file: File;
  fileNameToUpdate: string;
  dataAtual: string;

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
              private formBuilder: FormBuilder,
              private localeService: BsLocaleService,
              private toastService: ToastrService) {
      this.localeService.use('pt-br');
    }

    openModal(template: any): void {
      this.registerForm.reset();
      template.show();
    }

    abrirFormularioCadastro(template: any): void {
      this.operacao = 'cadastro';
      this.openModal(template);
    }

    abrirFormularioEdicao(template: any, evento: Evento): void {
        this.operacao = 'edicao';
        this.openModal(template);
        this.evento = Object.assign({}, evento);
        this.fileNameToUpdate = evento.imagemUrl.toString();
        this.evento.imagemUrl = '';
        this.dataEvento = this.evento.dataEvento;
        this.registerForm.patchValue(this.evento);
      }

      ngOnInit(): void {
        this.validation();
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
        this.registerForm = this.formBuilder.group({
          tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
          local: ['', Validators.required],
          dataEvento: ['', Validators.required],
          imagemUrl: ['', Validators.required],
          qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
          telefone: ['', Validators.required],
          email: ['', [Validators.required, Validators.email]]
        });
      }
      onFileChange(event: any): void {
        if (event.target.files && event.target.files.length){
           this.file = event.target.files[0];
        }
      }
      salvarAlteracao(template: any): void {
        if (this.registerForm.valid) {
          this.operacao === 'edicao' ? this.editarEvento(template) : this.cadastrarEvento(template);
        }
      }
      cadastrarEvento(template: any): void {
        this.evento = Object.assign({}, this.registerForm.value);
        this.uploadImagem();
        this.eventoService.cadastrarEvento(this.evento).subscribe((response) => {
            template.hide();
            this.obterEventos();
            this.toastService.success(response.messages[0]);
          }, errorResponse => {
            this.getErrorResponse(errorResponse);
          }
          );
        }
        editarEvento(template: any): void {
          this.evento = Object.assign({id: this.evento.id}, this.registerForm.value);
          this.uploadImagem();
          this.eventoService.editarEvento(this.evento).subscribe((response) => {
              template.hide();
              this.obterEventos();
              this.toastService.success(response.messages[0]);
            }, errorResponse => {
              this.getErrorResponse(errorResponse);
            }
            );
        }
        excluirEvento(evento: Evento, template: any): void {
          this.openModal(template);
          this.evento = evento;
          this.bodyExcluirEvento = `Tem certeza que deseja excluir o Evento: ${evento.tema}, Código: ${evento.id}`;
        }
        confirmarExclusao(template: any): void {
          this.eventoService.excluirEvento(this.evento.id).subscribe((response) => {
            template.hide();
            this.obterEventos();
            this.toastService.success(response.messages[0]);
          }, errorResponse => {
            this.getErrorResponse(errorResponse);
          }
          );
        }

        uploadImagem(): void {
          if (this.operacao === 'cadastro')
          {
            const nomeArquivo = this.evento.imagemUrl.split('\\', 3);
            this.evento.imagemUrl = nomeArquivo[2];
            this.eventoService.efetuarUpload(this.file, nomeArquivo[2]).subscribe(() => {
              this.dataAtual = new Date().getMilliseconds().toString();
              this.obterEventos();
            });
          }else{
            this.evento.imagemUrl = this.fileNameToUpdate;
            this.eventoService.efetuarUpload(this.file, this.fileNameToUpdate).subscribe(() => {
              this.dataAtual = new Date().getMilliseconds().toString();
              this.obterEventos();
            });
          }
        }

        obterEventos(): void {
            this.dataAtual = new Date().getMilliseconds().toString();
            this.loading = true;
            // tslint:disable-next-line:variable-name
            this.eventoService.obterEventos().subscribe((_eventos: Evento[]) => {
              this.eventos = _eventos;
              this.eventosFiltrados = this.eventos;
              this.loading = false;
            }, error => {
              this.toastService.error('Erro ao carregar eventos!');
              this.loading = false;
            });
        }

        getErrorResponse(errorResponse: any): void {
            const message = formatErrorResponse(errorResponse);
            this.toastService.error(message, null, {
                closeButton: true,
                disableTimeOut: true,
              });
        }
        }
