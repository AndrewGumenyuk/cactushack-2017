import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable()
export class SettingsService {

    constructor() { }

    private user: User = new User(34, "male", 80, 180, "active");

    getUser() {
        return this.user;
    }

    setUser() { }
}