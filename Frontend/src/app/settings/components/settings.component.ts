import { Component, OnInit } from '@angular/core';
import { SettingsService } from '../services/settings-service';
import { User } from '../models/user';
import { Router } from '@angular/router';

@Component({
    selector: 'settings',
    host: {'class': 'col-xs-12 settings'},
    templateUrl: './app/settings/components/settings.html',
    providers: [SettingsService]
})

export class SettingsComponent implements OnInit {
    constructor(private _settingsService: SettingsService; private router: Router) {
        // this.user = _settingsService.getUser();
     }

     age: number;
     sex:number;
     activity: number;
     weight: number;
     height: number;
    user: User;

    activities: [
        { id: 0, name: 'Малая активность(сидячий образ жизни)' }, 
        { id: 1, name: 'Легкая активность(тренировки 1-3 раза в неделю)' }, 
        { id: 2, name: 'Умереная активность(умереные тренировки 1-5 раз в неделю)' }, 
        { id: 3, name: 'Повышеная активность(интенсивные тренировки 6-7 раз в неделю)' }
    ];
    ngOnInit() {
        var data = this._settingsService.getUser()
            .subscribe(
            value => {
                this.age = value.age;
                this.height = value.height;
                this.sex = value.sex;
                this.activity = value.activity;
                this.weight = value.weight;
            });
    }
    goToStatistic(event) {
        this.router.navigate(['/stats']);
    }
    saveSettings(event) {
        this._settingsService.setUser(
            new User(this.age, this.sex, this.weight, this.height, this.activity)
        );
    }
}