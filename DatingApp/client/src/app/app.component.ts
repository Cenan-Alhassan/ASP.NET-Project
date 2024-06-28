import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";
import { NavComponent } from "./nav/nav.component";
import { RegisterComponent } from "./register/register.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    imports: [RouterOutlet, HomeComponent, NavComponent, RegisterComponent]
})

export class AppComponent implements OnInit{

  title = 'cenaenae time';
  accountService = inject(AccountService);

  constructor(private http: HttpClient) {}

  ngOnInit(): void {

    this.setCurrentUser();      
  }

  setCurrentUser()
  {

    const userString = localStorage.getItem('user');

    if (userString == null) return

    console.log("User exists in storage upon refresh");

    this.accountService.currentUser.set(JSON.parse(userString));  // MISTAKE = using equals instead of .set()
    console.log("Current user in local storage upon refresh is: " + this.accountService.currentUser()?.username)

  }
  


}
