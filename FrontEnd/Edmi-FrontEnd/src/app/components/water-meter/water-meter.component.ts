import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import {WaterMeter} from '../../models/water-meter';
import {GLOBAL} from '../../services/global';
import{WaterMeterService} from '../../services/water-meter.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-water-meter',
  templateUrl: './water-meter.component.html',
  styleUrls: ['./water-meter.component.css'],
  providers:[WaterMeterService]
})
export class WaterMeterComponent implements OnInit {

  public waterMeters:WaterMeter [] ;
  public status:string;
  public url:string;
  public insertform : FormGroup;

  constructor(
    private route:ActivatedRoute,
    private router:Router,
    private waterMeterService:WaterMeterService ,
    private formBuilder: FormBuilder   
  ) {
    this.url=GLOBAL.url;
    this.waterMeters = [];
    this.status = "";
    this.insertform =  this.formBuilder.group({
      serialNumber:['',[Validators.required]],
      firmwareVersion:[''],
      state:['']
    });
   }

   ngOnInit() {
    this.getWaterMeters();
  }
  getWaterMeters(){
    this.waterMeterService.getWaterMeters().subscribe(
      response=>{
       if(response){
            this.waterMeters=response;
            this.status='';
        }
      },
      error=>{
        if(error){
            this.status=error.error;
        }
      }
    );
  }

  insertWaterMeter(){
    var wm = this.insertform.value;
    this.waterMeterService.insertWaterMeter(wm).subscribe(
      response=>{
       if(response){
            this.waterMeters.push(response);
            this.insertform.reset();
            this.status='';
        }
      },
      error=>{
        if(error){
          this.status=error.error;
        }
      }
    );
  }

  deleteWaterMeter(wm:any){
    this.waterMeterService.deleteWaterMeter(wm.Id).subscribe(
      response=>{
       if(response){
        var search = this.waterMeters.indexOf(wm);
        if(search != -1){
            this.waterMeters.splice(search,1);
            this.status='';
          }
        }
      },
      error=>{
        if(error){
          this.status=error.error;
        }
      }
    );
  }

}
