import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs-compat';
import {Gateway} from '../models/gateway';
import {GLOBAL} from './global';

@Injectable(
    )
    export class GatewayService{
        public url:string;

        constructor(
            private _http: HttpClient
        ){
            this.url=GLOBAL.url;
    
        }

        insertGateway(gw: any):Observable<any>{
            let params = JSON.stringify(gw);
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.post(this.url+'Gateway/',params,{headers:headers});

        }
        getGateways():Observable<any>{
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.get(this.url+'Gateway/',{headers:headers});

        }

        deleteGateway(id: string):Observable<any>{
            let headers =  new HttpHeaders().set('Content-Type', 'application/json');

        return this._http.delete(this.url+'Gateway/'+id,{headers:headers});
    }

}