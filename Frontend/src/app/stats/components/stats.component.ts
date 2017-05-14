import { Component, OnInit } from '@angular/core';
import { StatsService } from '../services/stats-service';
import { Stats } from '../models/stats';
import { Router } from "@angular/router";

@Component({
    selector: 'stats',
    host: {"class": "col-sm-12 user-status"},
    templateUrl: './app/stats/components/stats.html',
    providers: [StatsService]
})

export class StatsComponent implements OnInit {
    constructor(private _statsService: StatsService, private router:Router) {}

     stats:Stats;

    ngOnInit() {
        var data = this._statsService.getStats()
            .subscribe(
                value => this.stats = value);
    }

    goToProducts(event) {
        this.router.navigate(['/products']);
    }
}