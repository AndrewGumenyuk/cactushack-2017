import {NgModule}      from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from "./app.component";
import {NewsComponent} from "./news/components/news.component";
import {ProductsComponent} from "./products/components/products.component";
import {ReportComponent} from "./report/components/report.component";
import {SettingsComponent} from "./settings/components/settings.component";
import {StatsComponent} from "./stats/components/stats.component";

import {routing, appRoutingProviders} from './app.routing';
import {FormsModule} from "@angular/forms";
import { HttpModule, JsonpModule } from '@angular/http';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        routing,
        HttpModule,
        JsonpModule
    ],
    declarations: [
        AppComponent,
        NewsComponent,
        ProductsComponent,
        ReportComponent,
        SettingsComponent,
        StatsComponent
    ],
    providers: [
        appRoutingProviders
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}