import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Module } from "../_models/module";
import { Movement } from "../_models/movements";
import { Product } from "../_models/products";
import { Cosif } from "../_models/cosif";

@Injectable()
export class ProductService {

  private _module: string = "/api/products";

  constructor(private http: HttpClient) { }

 getProductList(): Observable<Product[]>{
    return this.http.get<Product[]>("https://localhost:44340" + this._module );
  }

}
