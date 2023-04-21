import { Router } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

constructor(public router : Router) {}
  LogOut(){

localStorage.removeItem("token")
this.router.navigate(['/publicGalleries'])
console.log("Utilisateur déconnectée")

  }

}
