import { Component, OnInit } from '@angular/core';
import { EventoService } from 'src/app/services/evento.service';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
import { Evento } from 'src/app/models/Evento';
import { ActivatedRoute, Router } from '@angular/router';
import { Lote } from 'src/app/models/Lote';
import { RedeSocial } from 'src/app/models/RedeSocial';
import { formatErrorResponse } from '../../utils/Functions';

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-evento-edit',
  templateUrl: './evento-edit.component.html',
  styleUrls: ['./evento-edit.component.css']
})
export class EventoEditComponent implements OnInit {

  titulo = 'Editar Evento';
  evento: Evento = {} as Evento;
  registerForm: FormGroup;
  imagemUrl = 'assets/img/upload_img.png';
  dataEvento: Date;
  fileNameToUpdate: string;
  dataAtual: string;
  file: File;
  eventoId: number;
  url: string;

  get lotes(): FormArray {
    return this.registerForm.get('lotes') as FormArray;
  }

  get redesSociais(): FormArray {
    return this.registerForm.get('redesSociais') as FormArray;
  }

  constructor(private eventoService: EventoService,
              private formBuilder: FormBuilder,
              private localeService: BsLocaleService,
              private toastService: ToastrService,
              private router: Router,
              private activateRoute: ActivatedRoute) {
              this.localeService.use('pt-br');
    }

  ngOnInit(): void {
    this.carregaEvento();
    this.validation();
  }

  carregaEvento(): void {
    this.eventoId = Number(this.activateRoute.snapshot.paramMap.get('id'));
    this.eventoService.obterEventoPorId(this.eventoId).subscribe(
      (evento: Evento) => {
        this.evento = Object.assign({}, evento);
        this.fileNameToUpdate = evento.imagemUrl.toString();
        this.dataAtual = new Date().getMilliseconds().toString();
        this.imagemUrl = `https://localhost:5001/resources/images/${this.evento.imagemUrl}?_ts=${this.dataAtual}`;
        this.evento.imagemUrl = '';
        this.evento.lotes.forEach(lote => {
          this.lotes.push(this.criaLote(lote));
        });
        this.evento.redesSociais.forEach(redeSocial => {
          this.redesSociais.push(this.criaRedeSocial(redeSocial));
        });
        this.registerForm.patchValue(this.evento);
      }
    );
  }

  validation(): void {
    this.registerForm = this.formBuilder.group({
      id: [this.eventoId],
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      imagemUrl: [''],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      lotes: this.formBuilder.array([]),
      redesSociais: this.formBuilder.array([])
    });
  }

  criaLote(lote: Lote): FormGroup {
    return this.formBuilder.group({
      id: [lote.id || 0],
      nome: [lote.nome, Validators.required] ,
      quantidade: [lote.quantidade, Validators.required] ,
      preco: [lote.preco, Validators.required] ,
      dataInicio: [lote.dataInicio] ,
      dataFim: [lote.dataFim] ,
    });
  }

  criaRedeSocial(redeSocial: RedeSocial): FormGroup {
    return this.formBuilder.group({
      id: [redeSocial.id || 0],
      nome: [redeSocial.nome, Validators.required],
      url: [redeSocial.url, Validators.required]
    });
  }

  adicionarLote(): void {
    this.lotes.push(this.criaLote({} as Lote));
  }

  removerLote(id: number): void {
    this.lotes.removeAt(id);
  }

  adicionarRedeSocial(): void {
    this.redesSociais.push(this.criaRedeSocial({} as RedeSocial));
  }

  removerRedeSocial(id: number): void {
    this.redesSociais.removeAt(id);
  }

  onFileChange(event: any): void {
    this.file = event.target.files[0];
    const reader = new FileReader();
    // desestruturando objeto event
    reader.onload = ({target}: any) => this.imagemUrl = target.result;
    reader.readAsDataURL(this.file);
  }

  salvarEvento(): void {
    this.evento = Object.assign({}, this.registerForm.value);
    this.evento.imagemUrl = this.fileNameToUpdate;
    this.uploadImagem();
    this.eventoService.editarEvento(this.evento).subscribe((response) => {
        this.toastService.success(response.messages[0]);
        this.router.navigate(['/eventos']);
      }, errorResponse => {
        this.getErrorResponse(errorResponse);
      }
      );
    }

    getErrorResponse(errorResponse: any): void {
      const message = formatErrorResponse(errorResponse);
      this.toastService.error(message, null, {
          closeButton: true,
          disableTimeOut: true,
        });
    }

    uploadImagem(): void {
      if (this.registerForm.get('imagemUrl').value !== '' && !!this.file)
      {
        this.eventoService.efetuarUpload(this.file, this.fileNameToUpdate).subscribe(() => {
            this.dataAtual = new Date().getMilliseconds().toString();
            this.imagemUrl = `https://localhost:5001/resources/images/${this.evento.imagemUrl}?_ts=${this.dataAtual}`;
        });
      }
    }
}
