import { Component, OnInit, inject } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [RegisterComponent]
})
export class HomeComponent implements OnInit{
  registerMode = false;
  users: any
  http = inject(HttpClient)
  event: any;
  

  registerToggle() {
    this.registerMode = !this.registerMode
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }


  ngOnInit(): void {
      this.getUsers();
  }


  getUsers()
  { 
    this.http.get('https://localhost:5001/api/users').subscribe({
      

      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('getUsers has completed, type of users variable: ' + typeof this.users)

      })
  }

  
}