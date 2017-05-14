import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Report } from '../models/report';

@Component({
    selector: 'report',
    host: {'class': 'col-sm-12 test-prod'},
    templateUrl: './app/report/components/report.html'
})

export class ReportComponent implements OnInit {
    constructor(private route: ActivatedRoute, private router: Router) { }

    reports: Array<Report>;

    high: boolean;
    middle: boolean;
    low: boolean;

    ngOnInit() {
    this.route.params.subscribe((params: Params) => {
        this.reports = JSON.parse(params['report']) as Array<Report>;
        console.log(this.reports);
        this.high = this.reports.filter(x => x.DangerLevel === "высокая").length > 0;
        if (this.high === false) {
            this.middle = this.reports.filter(x => x.DangerLevel === "средняя").length > 0;
        }
        if (this.high === false && this.middle === false) {
            this.low = true;
        }
      });
    }
}