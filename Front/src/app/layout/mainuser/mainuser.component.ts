import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTabsModule } from '@angular/material/tabs';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { elementAt } from 'rxjs';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth/auth.service';

export interface Notification {
  tipoNotificacion: string;
  titulo: string;
  descripcion: string;
  ago: string;
}

@Component({
  selector: 'app-mainuser',
  standalone: true,
  imports: [MatIconModule, CommonModule, MatMenuModule, MatTabsModule, MatListModule, MatButtonModule],
  templateUrl: './mainuser.component.html',
  styleUrl: './mainuser.component.css'
})
export class MainuserComponent {

  nombre = 'Cindy Herrera';
  notifiSelect!: Notification;
  notificaciones!: Notification[]; 

  constructor(
    private route : Router,
    private authSrv : AuthService) {

  }

  preventTooltipClose(event: MouseEvent, show: boolean): void {
    if (show) {
      event.stopPropagation();
    }
  }


  viewNotification(info: Notification) {
    this.notifiSelect = info;
  }

  logout() {
    this.authSrv.logout();
  }

}
