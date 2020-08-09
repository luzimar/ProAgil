// Modulos
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxMaskModule } from 'ngx-mask';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxCurrencyModule } from 'ngx-currency';
import { AuthInterceptor } from './auth/auth.interceptor';

// Components
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContatosComponent } from './contatos/contatos.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { UsersComponent } from './users/users.component';
import { LoginComponent } from './users/login/login.component';
import { RegistrationComponent } from './users/registration/registration.component';
import { EventoEditComponent } from './eventos/evento-edit/evento-edit.component';

// Pipes
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { EventoService } from './services/evento.service';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      EventosComponent,
      PalestrantesComponent,
      DashboardComponent,
      ContatosComponent,
      TituloComponent,
      DateTimeFormatPipe,
      UsersComponent,
      LoginComponent,
      RegistrationComponent,
      EventoEditComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      ModalModule.forRoot(),
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      BsDatepickerModule.forRoot(),
      ToastrModule.forRoot({
        timeOut: 3000,
        preventDuplicates: true,
        progressBar: true
      }),
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      JwtModule.forRoot({
        config: {
          tokenGetter: () => '',
        }
      }),
      TabsModule.forRoot(),
      NgxMaskModule.forRoot(),
      NgxCurrencyModule
   ],
   providers: [
     EventoService,
     {
       provide: HTTP_INTERCEPTORS,
       useClass: AuthInterceptor,
       multi: true
     }
   ],
   bootstrap: [
      AppComponent
   ]
})


export class AppModule { }
