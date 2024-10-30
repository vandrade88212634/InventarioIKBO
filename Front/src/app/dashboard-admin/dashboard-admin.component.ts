import { CommonModule } from '@angular/common';
import { Component,OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIcon } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MainuserComponent } from '../layout/mainuser/mainuser.component';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-dashboard-admin',
  standalone: true,
  templateUrl: './dashboard-admin.component.html',
  styleUrl: './dashboard-admin.component.css',
  imports: [CommonModule, RouterOutlet, MatToolbarModule, MatSidenavModule, MatListModule, MatIcon, RouterLink, MainuserComponent, MatButtonModule]
})
export class DashboardAdminComponent implements OnInit {
  menu: { [key: string]: any[] } = {
    'admin': [
      {
        title: "Inventarios",
        path: "modules",
        icon: "security",
        visible: true, // Control de visibilidad
        subMenu: [
          {
            title: "Crear Productos",
            path: "/admin/producto",
            icon: "security",
            visible: true // Control de visibilidad
          },
          {
            title: "Entradas",
            path: "/admin/entrada",
            icon: "group",
            visible: true // Control de visibilidad
          },
          {
            title: "Salidas",
            path: "/admin/salida",
            icon: "group",
            visible: true // Control de visibilidad
          },
          {
            title: "Existencias",
            path: "/admin/existencias",
            icon: "group",
            visible: true // Control de visibilidad
          },
        ]
      }
    
    ]
  };
  isSubMenuOpen: boolean[] = [];
  menuSelect: any[] = [];
  isMenuOpen: boolean = false;
  idusuario = 0;
  nombreUsuario = "";
  constructor(private permisosService: AuthService) {}

  ngOnInit() {
   // this.checkPermissions();
  }

  // Método para verificar permisos
  
  toggleSubMenu(index: number) {
    this.isSubMenuOpen[index] = !this.isSubMenuOpen[index];
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  getMenuButtonClass() {
    return this.isMenuOpen ? 'btn-menu btn-menu-open' : 'btn-menu';
  }

 
 
}