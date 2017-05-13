import { Component, OnInit } from '@angular/core';
import { SettingsService } from '../services/settings-service';
import { User } from '../models/user';

@Component({
    selector: 'settings',
    templateUrl: './app/settings/components/settings.html',
    providers: [SettingsService]
})

export class SettingsComponent implements OnInit {
    constructor(_settingsService: SettingsService) {
        this.user = _settingsService.getUser();
     }

    user: User;

    ngOnInit() { }
}