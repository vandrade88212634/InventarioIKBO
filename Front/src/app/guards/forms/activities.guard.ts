import { CanDeactivateFn } from '@angular/router';
import { ActividadesComponent } from '../../dashboard-admin/pages/actividades/actividades.component';

export const activitiesGuard: CanDeactivateFn<ActividadesComponent> = 
(component) => {

  if (component.addEditForm.dirty) {
   return component.openConfirmationModal();
  }

  return true;
};
