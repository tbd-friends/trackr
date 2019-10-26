import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/security/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  constructor(private auth: AuthService, private router: Router) {}

  ngOnInit() {}

  navigate(route: string) {
    this.router.navigateByUrl(route);
  }
}
