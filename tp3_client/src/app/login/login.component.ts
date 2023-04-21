import { GaleriesInfinieServiceService } from './../Services/GaleriesInfinieService.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { LoginDTO } from 'src/Models/LoginDTO';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  Username? : string;
  Password? : string;
  constructor(public router : Router, public http : HttpClient, public service : GaleriesInfinieServiceService) { }

  ngOnInit() {
  }

 async login(): Promise<void>
 {
    // Retourner à la page d'accueil
    if(this.Username != undefined && this.Password != undefined)
    { let Login = new LoginDTO(
      this.Username,
      this.Password
      );
    console.log(Login);
    this.service.Login(Login)
    this.router.navigate(['/publicGalleries']);

    }
    else{

       console.log("Un ou plusieurs champs ne sont pas remplie")

    }
    
  }

}
