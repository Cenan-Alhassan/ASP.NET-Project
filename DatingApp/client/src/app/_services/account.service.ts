import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { map } from 'rxjs';
import { User } from '../_models/user';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private http = inject(HttpClient)
  baseUrl: string = "https://localhost:5001/api/"

  currentUser = signal<User | null>(null);  // initial value is null, can return User or null

  login(model: any)
  {
    return this.http.post<User>(this.baseUrl + "account/login", model).pipe(
      map(
        user => {
          localStorage.setItem('user', JSON.stringify(user)) // user here is json. convert it to string
          this.currentUser.set(user) // in order for currentUser to accept user (which is object), we need to specify that the post returns User
          console.log(`${this.currentUser()?.username} has logged in.`)

          return user;
        }

      )
    )
  }

  register(model: any)
  {
    return this.http.post<User>(this.baseUrl + "account/register", model).pipe(
      map(
        user => {
          localStorage.setItem('user', JSON.stringify(user)) // user here is json. convert it to string
          this.currentUser.set(user) // in order for currentUser to accept user (which is object), we need to specify that the post returns User
          console.log(`${this.currentUser()?.username} was registered.`)

          return user;
        }
        
      )
    )
  }

  logout()
  {
    localStorage.removeItem('user')
    this.currentUser.set(null);
  }
}
