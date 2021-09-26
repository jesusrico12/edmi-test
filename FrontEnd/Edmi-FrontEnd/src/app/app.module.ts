import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WaterMeterComponent } from './components/water-meter/water-meter.component';
import { ElectricMeterComponent } from './components/electric-meter/electric-meter.component';
import { GatewayMeterComponent } from './components/gateway-meter/gateway-meter.component';
import { FormsModule,ReactiveFormsModule  }   from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    WaterMeterComponent,
    ElectricMeterComponent,
    GatewayMeterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
