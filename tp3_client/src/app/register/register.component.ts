import { GaleriesInfinieServiceService } from './../Services/GaleriesInfinieService.service';
import { RegisterDTO } from './../../Models/RegisterDTO';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
Username? : string;
Email? : string;
Password? : string;
PasswordConfirm? :string; 



  constructor(public router : Router, public http : HttpClient, public service : GaleriesInfinieServiceService) { }

  ngOnInit() {
  }

 async register() : Promise<void>{
    // Aller vers la page de connexion

    if(this.Username != undefined && this.Email != undefined && this.Password != undefined && this.PasswordConfirm != undefined){
      let register = new RegisterDTO(
        this.Username,
        this.Email,
        this.Password,
        this.PasswordConfirm);
        
        console.log(register);
       
        this.service.Register(register)
       
    this.router.navigate(['/login']);
      }
      else{
        console.log("Un ou plusieurs champs ne sont pas remplie")
      }
  }
}
