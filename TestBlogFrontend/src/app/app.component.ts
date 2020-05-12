import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppSettingsService } from './app-settings.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(){

  }
  title = 'TestBlogFrontend';
}
