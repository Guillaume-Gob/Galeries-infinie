import { RegisterDTO } from './../../Models/RegisterDTO';
import { LoginDTO } from './../../Models/LoginDTO';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Galerie } from 'src/Models/Galerie';

@Injectable({
  providedIn: 'root'
})
export class GaleriesInfinieServiceService {
  galeries: Galerie[] = [];
private DomaineUilisateurs : string = "https://localhost:7183/api/Utilisateurs/"
private Domainegalerie : string = "https://localhost:7183/api/Galeries/"
constructor(public http : HttpClient) { }

async getmyGalleries() : Promise<Galerie[]>{
  this.galeries = [];
  let x = await lastValueFrom(this.http.get<any>(this.Domainegalerie+"GetMyGaleries"))
  console.log(x)
    for(let i =0; i< x.length; i++){
  this.galeries.push(new Galerie(x[i].id,x[i].name,x[i].imageUrl,x[i].private))
       
    }
    return this.galeries
      };

async PutGallerie(pgal : Galerie) : Promise<void>{
  let x = await lastValueFrom(this.http.put<Galerie>(this.Domainegalerie+"PutGalerie/"+ pgal.id, pgal))
 console.log(x)
 await this.getmyGalleries()

 }
 
 async SupprimerGalerie(Pgal : Galerie) : Promise<void>{
  let x = await lastValueFrom(this.http.delete<any>(this.Domainegalerie+"DeleteGalerie/"+ Pgal.id))
   console.log(x)
        
        await this.getmyGalleries()
 }

 async  getGalleries() : Promise<Galerie[]> {
  this.galeries = [];
  let x = await lastValueFrom(this.http.get<any>(this.Domainegalerie+"GetAllPublic"))
  console.log(x)
    for(let i =0; i< x.length; i++){
  this.galeries.push(new Galerie(x[i].id,x[i].name,x[i].imageUrl,x[i].private))
  
    }
    return this.galeries
  }

  async Login(pLogin : LoginDTO) : Promise<void>{
      let x = await lastValueFrom(this.http.post<any>(this.DomaineUilisateurs+"Login",pLogin))
      console.log(x);
      localStorage.setItem("token", x.token)
     
  }

  async Register(pregister :RegisterDTO) {
          
    let x = await lastValueFrom(this.http.post<RegisterDTO>(this.DomaineUilisateurs+"Register",pregister))
    console.log(x)

  }

  async PostGalerie(pGal : Galerie): Promise<void>{
          
      let x = await lastValueFrom(this.http.post<any>(this.Domainegalerie+"PostGalerie", pGal))
      console.log(x)
      

  }

  async AddUserToGalerie(Username : string, pGal : Galerie): Promise<void>{

        let x = await lastValueFrom(this.http.post<any>(this.Domainegalerie+"AddUserToGalerie/"+pGal.id+"?Username="+Username,Username))
        console.log(x)

  }
}