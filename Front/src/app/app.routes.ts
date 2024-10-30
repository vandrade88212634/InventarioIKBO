import { Routes } from '@angular/router';
import { DashboardAdminComponent } from './dashboard-admin/dashboard-admin.component';
import { EntradaComponent } from './dashboard-admin/pages/entrada/entrada.component';
import { SalidaComponent } from './dashboard-admin/pages/salida/salida.component';
import { ExistenciasComponent } from './dashboard-admin/pages/existencias/existencias.component';
import { authGuard } from './guards/auth.guard';
import { productoComponent } from './dashboard-admin/pages/producto/producto.component';

export const routes: Routes = [
    { path: '', redirectTo: 'DashboardAdmin', pathMatch: 'full' },
    {
        path: 'DashboardAdmin',
        component: DashboardAdminComponent,
    },
    {
        path: 'admin/producto',
        component: productoComponent,
    },
    {
        path: 'admin/entrada',
        component: EntradaComponent,
    },
    {
        path: 'admin/salida',
        component: SalidaComponent,
    },
    {
        path: 'admin/existencias',
        component: ExistenciasComponent,
    }
];
