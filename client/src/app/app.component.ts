import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
// Component is decorator : is used to define angular component.
// Inject is function : used for dependency injection
// OnInit interface from angular core module : It's life cycle hook
// interface used to define ngOnIt method to run appcomponent 
// when it is initialized.
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
// Initializing the component 
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'DatingApp';
  users: any;

  // we are calling ngOnInit and executing the code inside
  ngOnInit(): void {
    this.http.get('http://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }
}
