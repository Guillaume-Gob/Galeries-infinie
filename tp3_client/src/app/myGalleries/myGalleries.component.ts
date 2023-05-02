import { GaleriesInfinieServiceService } from './../Services/GaleriesInfinieService.service';
import { Galerie } from './../../Models/Galerie';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { compilePipeFromMetadata } from '@angular/compiler';

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {
  @ViewChild("myPictureViewChild", {static:false}) pictureInput ? : ElementRef;
  galeries: Galerie[] = [];
  galerieSelectionner? : Galerie;
  galerieCréé? : Galerie;
  InputPublic? : boolean;
  InputNom? : string;
  InputUsername? : string; 
  @ViewChild("myPictureUpdate", {static:false}) pictureUpdate ? : ElementRef;                              

  constructor(public http : HttpClient, public service : GaleriesInfinieServiceService) { }

  ngOnInit() {
this.getGalleries()
  }






  async getGalleries() : Promise<void>{
      this.galeries = await this.service.getmyGalleries()
        };

       
        async SupprimerGalerie() : Promise<void>{
          if(this.galerieSelectionner != undefined){
                 await this.service.SupprimerGalerie(this.galerieSelectionner)
                this.galerieSelectionner = undefined;
                this.getGalleries()}
                else{ console.log("Aucune galerie selectionnée")}
        }

     SelectGalerie(pGal : Galerie) : void{
           this.galerieSelectionner = pGal
    }

    async RendrePublique() : Promise<void>{
         if(this.galerieSelectionner != undefined)
         {
                    this.galerieSelectionner.Private = false;
                    await this.service.PutGallerie(this.galerieSelectionner)    
                    this.getGalleries() 
         }
         else{ console.log("Aucune galerie selectionnée")}

    }
    
    async RendrePriver() : Promise<void>{
      if(this.galerieSelectionner != undefined)
      {
                 this.galerieSelectionner.Private = true;
                 await this.service.PutGallerie(this.galerieSelectionner)    
                 this.getGalleries() 
      }
      else{ console.log("Aucune galerie selectionnée")}

 }

    async CreeGalerie() : Promise<void>{
              if(this.InputNom != undefined && this.InputPublic != undefined )
              {
                if(this.pictureInput == undefined)
              {
               console.log("pas d'image")
              return;
              }
              let file = this.pictureInput.nativeElement.files[0];
                if(file == null){
                    console.log("pas d'image dans le upload")
                                }
                let formdata = new FormData();
                 formdata.append("monImage",file, file.name);
                 formdata.append("NomGalerie", this.InputNom)
                 formdata.append("isPublic", this.InputPublic.toString())

               let nouvGalerie = new Galerie(0,this.InputNom, !this.InputPublic)

              await this.service.PostGalerie(formdata)

            
           await this.getGalleries()
              }
              else{
                console.log("un ou plusieurs champs Manquant")
              }

  


    }
 
    async UpdatePicture() : Promise<void>{
     if (this.pictureUpdate != undefined && this.galerieSelectionner != undefined)
     {
      let file = this.pictureUpdate.nativeElement.files[0];
         if(file == null)
         {
          console.log("Pas d'image dans le upload")
         }
           let formdata = new FormData();
           formdata.append("MonImage", file, file.name)
           
           await this.service.ChangerCouverture(formdata,this.galerieSelectionner?.id)
           await this.getGalleries()
     }
     else{

      console.log("pas d'image")
     }

    }

    async AjouterUtilisateur() : Promise<void>{
   if(this.InputUsername != undefined && this.galerieSelectionner != undefined)
      {
        this.service.AddUserToGalerie(this.InputUsername, this.galerieSelectionner)
        

      }
  else{
console.log("Aucune galerie selectionner ou Aucun username entrer")

  }
    }

       

        
  }

