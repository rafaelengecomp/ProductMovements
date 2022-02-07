import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { Interceptor } from './app.interceptor.module';
import { MovementService } from './_services/movements.service';
import { ProductService } from './_services/products.service';
import { CosifService } from './_services/cosif.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AlertService } from './_services/alert.service';
import { ErrorService } from './_services/error.service';
import { NgxLoadingModule } from 'ngx-loading';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';


@NgModule({
  declarations: [
    AppComponent,    
    HomeComponent,
    DashboardComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DashboardComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'dashboard', component: DashboardComponent },
    ]),
    Interceptor,    
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    NgxLoadingModule.forRoot({}), ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [MovementService, ProductService, CosifService, AlertService, ErrorService, AppComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
