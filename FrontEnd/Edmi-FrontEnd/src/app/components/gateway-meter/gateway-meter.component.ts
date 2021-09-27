import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import {Gateway} from '../../models/gateway';
import {GLOBAL} from '../../services/global';
import{GatewayService} from '../../services/gateway.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-gateway-meter',
  templateUrl: './gateway-meter.component.html',
  styleUrls: ['./gateway-meter.component.css'],
  providers:[GatewayService]
})
export class GatewayMeterComponent implements OnInit {

  public gateways:Gateway [] ;
  public status:string;
  public url:string;
  public insertform : FormGroup;

  constructor(
    private route:ActivatedRoute,
    private router:Router,
    private gatewayService:GatewayService ,
    private formBuilder: FormBuilder   
  ) {
    this.url=GLOBAL.url;
    this.gateways = [];
    this.status = "";
    this.insertform =  this.formBuilder.group({
      serialNumber:['',[Validators.required]],
      firmwareVersion:[''],
      state:[''],
      ip:[''],
      port:['']
    });
   }

   ngOnInit() {
    this.getGateways();
  }
  getGateways(){
    this.gatewayService.getGateways().subscribe(
      response=>{
       if(response){
            this.gateways=response;
        }
      },
      error=>{
        if(error){
          this.status=error.error;
        }
      }
    );
  }

  insertGateway(){
    var wm = this.insertform.value;
    this.gatewayService.insertGateway(wm).subscribe(
      response=>{
       if(response){
            this.gateways.push(response);
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

  deleteGateway(wm:any){
    this.gatewayService.deleteGateway(wm.Id).subscribe(
      response=>{
       if(response){
        var search = this.gateways.indexOf(wm);
        if(search != -1){
            this.gateways.splice(search,1);
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
