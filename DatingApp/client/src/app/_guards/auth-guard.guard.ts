import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export const authGuardGuard: CanActivateFn = (route, state) => { // guard which returns true if currentUser exists
  const accountService = inject(AccountService);
  const toastr = inject(ToastrService);

  if (accountService.currentUser()) {
    return true;
  } 
  else {
    toastr.error('YOU SHALL NOT PAAASSS!!')
    return false;
  }
  return true;
};
