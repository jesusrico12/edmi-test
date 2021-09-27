import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import {ElectricMeter} from '../../models/electric-meter';
import {GLOBAL} from '../../services/global';
import{ElectricMeterService} from '../../services/electric-meter.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-electric-meter',
  templateUrl: './electric-meter.component.html',
  styleUrls: ['./electric-meter.component.css'],
  providers:[ElectricMeterService]
})
export class ElectricMeterComponent implements OnInit {


  public electricMeters:ElectricMeter [] ;
  public status:string;
  public url:string;
  public insertform : FormGroup;

  constructor(
    private route:ActivatedRoute,
    private router:Router,
    private electricMeterService:ElectricMeterService ,
    private formBuilder: FormBuilder   
  ) {
    this.url=GLOBAL.url;
    this.electricMeters = [];
    this.status = "";
    this.insertform =  this.formBuilder.group({
      serialNumber:['',[Validators.required]],
      firmwareVersion:[''],
      state:['']
    });
   }

   ngOnInit() {
    this.getElectricMeters();
  }
  getElectricMeters(){
    this.electricMeterService.getElectricMeters().subscribe(
      response=>{
       if(response){
            this.electricMeters=response;
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

  insertElectricMeter(){
    var wm = this.insertform.value;
    this.electricMeterService.insertElectricMeter(wm).subscribe(
      response=>{
       if(response){
            this.electricMeters.push(response);
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

  deleteElectricMeter(wm:any){
    this.electricMeterService.deleteElectricMeter(wm.Id).subscribe(
      response=>{
       if(response){
        var search = this.electricMeters.indexOf(wm);
        if(search != -1){
            this.electricMeters.splice(search,1);
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
