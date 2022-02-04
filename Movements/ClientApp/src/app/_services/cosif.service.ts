import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Module } from "../_models/module";
import { Movement } from "../_models/movements";
import { Product } from "../_models/products";
import { Cosif } from "../_models/cosif";

@Injectable()
export class CosifService {

  private _module: string = "/api/cosifs";

  constructor(private http: HttpClient) { }

 getCosifList(): Observable<Cosif[]>{
    return this.http.get<Cosif[]>("https://localhost:44340" + this._module );
  }

}
