import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { NgChartsModule  } from 'ng2-charts';
import { DataService } from './data.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgChartsModule ,
    FormsModule,
    ReactiveFormsModule 
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
