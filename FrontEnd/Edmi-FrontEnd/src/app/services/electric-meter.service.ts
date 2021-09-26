import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs-compat';
import {ElectricMeter} from '../models/electric-meter';
import {GLOBAL} from './global';

@Injectable(
    )
    export class ElectricMeterService{
        public url:string;

        constructor(
            private _http: HttpClient
        ){
            this.url=GLOBAL.url;
    
        }

        insertElectricMeter(wm: any):Observable<any>{
            let params = JSON.stringify(wm);
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.post(this.url+'ElectricMeter',params,{headers:headers});

        }
        getElectricMeters():Observable<any>{
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.get(this.url+'ElectricMeter/',{headers:headers});

        }

        deleteElectricMeter(id: string):Observable<any>{
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.delete(this.url+'ElectricMeter/'+id,{headers:headers});
    }

}