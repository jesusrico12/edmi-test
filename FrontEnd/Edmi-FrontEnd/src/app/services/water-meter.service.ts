import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs-compat';
import {WaterMeter} from '../models/water-meter';
import {GLOBAL} from './global';

@Injectable(
    )
    export class WaterMeterService{
        public url:string;

        constructor(
            private _http: HttpClient
        ){
            this.url=GLOBAL.url;
    
        }

        insertWaterMeter(wm: any):Observable<any>{
            let params = JSON.stringify(wm);
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.post(this.url+'WaterMeter',params,{headers:headers});

        }
        getWaterMeters():Observable<any>{
            let headers =  new HttpHeaders().set('Content-Type', 'application/json')
            .set('Accept', 'application/json');

        return this._http.get(this.url+'WaterMeter',{headers:headers});

        }

        deleteWaterMeter(Id: string):Observable<any>{
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.delete(this.url+'WaterMeter/'+Id,{headers:headers});
    }

}