import { Component, OnInit } from '@angular/core';
import { SettingsService } from '../services/settings-service';
import { User } from '../models/user';

@Component({
    selector: 'settings',
    host: {'class': 'col-xs-12 settings'},
    templateUrl: './app/settings/components/settings.html',
    providers: [SettingsService]
})

export class SettingsComponent implements OnInit {
    constructor(private _settingsService: SettingsService) {
        // this.user = _settingsService.getUser();
     }

     age: number;
     sex:string;
     activity: string;
     weight: number;
     height: number;
    user: User;

    ngOnInit() {
        var data = this._settingsService.getUser()
            .subscribe(
            value => {
                this.age = value.age;
                this.height = value.height;
                this.sex = value.sex === "0" ? "male" : "female";
                this.activity = value.activity;
                this.weight = value.weight;
            });
    }
}