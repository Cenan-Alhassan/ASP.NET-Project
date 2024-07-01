import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown'
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule, RouterOutlet, RouterLink, RouterLinkActive, TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);
  private router = inject(Router);
  private toastr = inject(ToastrService)
  model: any = {};

  login() {
    this.accountService.login(this.model).subscribe({

      next: () => {
        this.router.navigateByUrl('/members')
        console.log("Log in successful")
      },

      error: errorProperty => this.toastr.error(errorProperty.error)

    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }
}
