import { Photo } from './../../Models/Photo';
import { async } from '@angular/core/testing';
import { GaleriesInfinieServiceService } from './../Services/GaleriesInfinieService.service';
import { Galerie } from './../../Models/Galerie';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, ElementRef, ViewChildren, QueryList } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { compilePipeFromMetadata } from '@angular/compiler';

declare var Masonry : any;
declare var ImagesLoaded : any;

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
  PhotoSelectionner? : Photo; 
  @ViewChild("myPictureUpdate", {static:false}) pictureUpdate ? : ElementRef;
  @ViewChild("fileUploadPicture", {static:false}) AddedPicture ? : ElementRef;
  @ViewChild('masongrid') masongrid?: ElementRef; 
  @ViewChildren('masongriditems') masongriditems?: QueryList<any>; 
                                         
       
  constructor(public http : HttpClient, public service : GaleriesInfinieServiceService) { }

  ngAfterViewInit() 
   { 
    this.masongriditems?.changes.subscribe(e => { 
    this.initMasonry(); 
   }); 
     
     if(this.masongriditems!.length > 0) { 
     this.initMasonry(); 
     } 
    } 
    
    initMasonry() 
    { 
     var grid = this.masongrid?.nativeElement; 
    var msnry = new Masonry( grid, { 
     itemSelector: '.grid-item',
     columnWidth:320, // À modifier si le résultat est moche
     gutter:3
     });
    
    ImagesLoaded( grid ).on( 'progress', function() { 
     msnry.layout(); 
     }); 
   } 

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
        SelectPhoto(photo : Photo){
               this.PhotoSelectionner = photo
        }

  async  SelectGalerie(pGal : Galerie) : Promise<void>{
           this.galerieSelectionner = pGal
           this.galerieSelectionner.Photos = [];
           this.galerieSelectionner.Photos = await this.service.getPhotos(this.galerieSelectionner.id); 
           console.log(this.galerieSelectionner.Photos)
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

    async AddPicture() : Promise<void>{
if  (this.AddedPicture !=undefined && this.galerieSelectionner != undefined)
{
  let file = this.AddedPicture.nativeElement.files[0];
  if(file == null)
  {
    console.log("Pas d'image dans le upload")
  }
  else{
    let formdata = new FormData();
    formdata.append("MonImage", file, file.name)
    
    await this.service.PostPhoto(formdata,this.galerieSelectionner?.id)
    await this.SelectGalerie(this.galerieSelectionner)

  }
}


    
  }

  async DeletePicture(Photo : Photo) : Promise<void> {
if  (this.galerieSelectionner != undefined){
        await this.service.SupprimerPhoto(Photo);
        await this.SelectGalerie(this.galerieSelectionner)
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

