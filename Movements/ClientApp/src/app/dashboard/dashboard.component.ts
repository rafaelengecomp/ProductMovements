import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { ModuleService } from '../_services/module.service';
import { Module } from '../_models/module';
import { MovementService } from '../_services/movements.service';
import { ProductService } from '../_services/products.service';
import { CosifService } from '../_services/cosif.service';
import { Movement } from '../_models/movements';
import { Product } from '../_models/products';
import { Cosif } from '../_models/cosif';
import { AppComponent } from '../app.component';
import { ErrorService } from '../_services/error.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  
    view: string = 'list';
  _movements: Movement[] = [];
  _products: Product[] = [];
  _cosifs: Cosif[] = [];
  _userSelected: Movement = {};

  constructor(private movementService: MovementService, private productService: ProductService, private cosifService: CosifService, private app: AppComponent, private errorService: ErrorService) {
    this.getMovements();
    this.getProductList();
    this.getCosifList();
  }

  getMovements(){
    this.app.loading = true;
    this.movementService.getMovements().subscribe(data => {
      this._movements = data;
      this.app.loading = false;
    }, err => {
      this.errorService.validateError(err);
      this.app.loading = false;
    })
  }

  getProductList(){
    this.app.loading = true;
    this.productService.getProductList().subscribe(data => {
      this._products = data;
      this.app.loading = false;
    }, err => {
      this.errorService.validateError(err);
      this.app.loading = false;
    })
  }

  getCosifList(){
    this.app.loading = true;
    this.cosifService.getCosifList().subscribe(data => {
      this._cosifs = data;
      this.app.loading = false;
    }, err => {
      this.errorService.validateError(err);
      this.app.loading = false;
    })
  }


   openDetails(user){
    this._userSelected = user;
    this.view = 'form';
  }

}


