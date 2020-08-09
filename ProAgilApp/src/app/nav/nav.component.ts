import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { User } from '../models/User';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {


  constructor(public authService: AuthService,
              private router: Router) { }

  ngOnInit(): void {
  }

  loggedIn(): boolean {
    return this.authService.loggedIn();
  }
  logout(): void {
    this.authService.logout();
    this.router.navigate(['/users/login']);
  }

  entrar(): void {
    this.router.navigate(['/users/login']);
  }
  getUsername(): string {
    return sessionStorage.getItem('username');
  }
}
