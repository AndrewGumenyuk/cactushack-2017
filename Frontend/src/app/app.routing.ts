import {Routes, RouterModule} from "@angular/router";
import {NewsComponent} from "./news/components/news.component";
import {ProductsComponent} from "./products/components/products.component";
import {ReportComponent} from "./report/components/report.component";
import {SettingsComponent} from "./settings/components/settings.component";
import {StatsComponent} from "./stats/components/stats.component";
import {ModuleWithProviders} from "@angular/core";

const appRoutes: Routes = [
    {path: '', redirectTo: 'news', pathMatch: 'full'},
    {path: 'news', component: NewsComponent},
    {path: 'products', component: ProductsComponent},
    {path: 'report', component: ReportComponent},
    {path: 'settings', component: SettingsComponent},
    {path: 'stats', component: StatsComponent}
];

export const appRoutingProviders: any[] = [];
export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, { useHash: true });
