import { Component, OnInit } from '@angular/core';
import { StatsService } from '../services/stats-service';
import { Stats } from '../models/stats';

@Component({
    selector: 'stats',
    templateUrl: './app/stats/components/stats.html',
    providers: [StatsService]
})

export class StatsComponent implements OnInit {
    constructor(private _statsService: StatsService) {}

     stats:Stats;

    ngOnInit() {
        var data = this._statsService.getStats()
            .subscribe(
                value => this.stats = value);
    }
}