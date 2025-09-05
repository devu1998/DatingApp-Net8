import { Component, inject, OnInit } from '@angular/core';
// Component is decorator : is used to define angular component.
// Inject is function : used for dependency injection
// OnInit interface from angular core module : It's life cycle hook
// interface used to define ngOnIt method to run appcomponent 
// when it is initialized.
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
// Initializing the component 
export class AppComponent implements OnInit {
  private accountService = inject(AccountService)

  // we are calling ngOnInit and executing the code inside
  ngOnInit(): void {
    this.setCurrentUser();
  }

  // will create a function setUser

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }
}
