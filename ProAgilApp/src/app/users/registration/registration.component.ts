import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from '../../models/User';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;
  user: User;

  constructor(private authService: AuthService,
              private router: Router,
              public fb: FormBuilder,
              private toastService: ToastrService) { }

    ngOnInit(): void {
      if (localStorage.getItem('token') !== null)
      {
        this.router.navigate(['/dashboard']);
      }
      this.validation();
    }

    validation(): void {
      this.registerForm = this.fb.group({
        fullName: ['', Validators.required],
        email: ['', [ Validators.required, Validators.email ]],
        userName: ['', Validators.required],
        passwords: this.fb.group({
          password: ['', [ Validators.required, Validators.minLength(4) ]],
          confirmPassword: ['', Validators.required]
        }, { validator: this.compararSenhas })
      });
    }

    cadastrarUsuario(): void {
      if (this.registerForm.valid) {
        this.user = Object.assign(
          {
            password: this.registerForm.get('passwords.password').value
          },
          this.registerForm.value
          );
          this.authService.register(this.user).subscribe(() => {
            this.router.navigate(['/users/login']);
            this.toastService.success('Usuário cadastrado com sucesso!');
          }, error => {
            const erro = error.erro;
            erro.forEach(element => {
              switch (element.code) {
                case 'DuplicateUserName':
                this.toastService.error('Cadastro duplicado!');
                break;
                default:
                this.toastService.error(`Erro no cadastro! CODE: ${element.code}`);
                break;
              }
            });
          });
        }
      }

      compararSenhas(fb: FormGroup): void {
        const controleConfirmaSenha = fb.get('confirmPassword');
        if (controleConfirmaSenha.errors === null || 'mismatch' in controleConfirmaSenha.errors)
        {
          if (fb.get('password').value !== controleConfirmaSenha.value)
          {
            controleConfirmaSenha.setErrors({ mismatch: true });
          } else {
            controleConfirmaSenha.setErrors(null);
          }
        }
      }

    }
