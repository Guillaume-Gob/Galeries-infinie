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
  InputImageUrl : string = "aaaaa/aaaa.img"
  InputUsername? : string; 
                                

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
              let file = this.pictureInput.nativeElement.Files[0];
                if(file == null){
                    console.log("pas d'image dans le upload")
                                }
                let formdata = new FormData();
                 formdata.append("monImage",file, file.name);
               let nouvGalerie = new Galerie(0,this.InputNom, this.InputImageUrl, !this.InputPublic)

              await this.service.PostGalerie(nouvGalerie)

            
              this.getGalleries()
              }
              else{
                console.log("un ou plusieurs champs Manquant")
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

