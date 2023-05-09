import { GaleriesInfinieServiceService } from './../Services/GaleriesInfinieService.service';
import { HttpClient } from '@angular/common/http';
import { Galerie } from './../../Models/Galerie';
import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Photo } from 'src/Models/Photo';

declare var Masonry : any;
declare var ImagesLoaded : any;
@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})
export class PublicGalleriesComponent implements OnInit {
 galeries : Galerie[] = []
 galerieSelectionner? : Galerie;
 PhotoSelectionner? : Photo;
 @ViewChild('masongrid') masongrid?: ElementRef; 
  @ViewChildren('masongriditems') masongriditems?: QueryList<any>;
  constructor(public http : HttpClient, public service : GaleriesInfinieServiceService ) { }
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
this.GetGaleries()

  }


 async GetGaleries() : Promise<void>{
       this.galeries = await this.service.getGalleries()
  }
  SelectPhoto(photo : Photo){
    this.PhotoSelectionner = photo
}
  async SelectGalerie(pGal : Galerie) : Promise<void>{
    this.galerieSelectionner = pGal
    this.galerieSelectionner.Photos = [];
    this.galerieSelectionner.Photos = await this.service.getPhotos(this.galerieSelectionner.id); 
    console.log(this.galerieSelectionner.Photos)
}

}
