import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAppSettings } from './models/app-settings';

@Injectable({
  providedIn: 'root'
})
export class AppSettingsService {
  private appSettings: IAppSettings;
  constructor(private http: HttpClient) { }
  load(){
    return this.http.get('/assets/appsettings.json')
      .toPromise()
      .then(data => {
        this.appSettings = data as IAppSettings;
      });
  }
  get settings(){
    return this.appSettings;
  }

}
