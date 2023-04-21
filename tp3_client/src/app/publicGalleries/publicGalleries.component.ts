import { GaleriesInfinieServiceService } from './../Services/GaleriesInfinieService.service';
import { HttpClient } from '@angular/common/http';
import { Galerie } from './../../Models/Galerie';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})
export class PublicGalleriesComponent implements OnInit {
 galeries : Galerie[] = []
 galerieSelectionner? : Galerie;


  constructor(public http : HttpClient, public service : GaleriesInfinieServiceService ) { }

  ngOnInit() {
this.GetGaleries()

  }


 async GetGaleries() : Promise<void>{
       this.galeries = await this.service.getGalleries()
  }
  SelectGalerie(pGal : Galerie) : void{
    this.galerieSelectionner = pGal
}

}
