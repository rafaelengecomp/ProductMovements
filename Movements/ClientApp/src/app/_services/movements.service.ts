import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Module } from "../_models/module";
import { Movement } from "../_models/movements";
import { Product } from "../_models/products";
import { Cosif } from "../_models/cosif";

@Injectable()
export class MovementService {

  private _module: string = "/api/movements";

  constructor(private http: HttpClient) { }

 getMovements(): Observable<Movement[]>{
    return this.http.get<Movement[]>("https://localhost:44340" + this._module );
  }

}
