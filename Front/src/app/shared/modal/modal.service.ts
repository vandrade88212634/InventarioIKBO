import { Injectable, TemplateRef } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ModalComponent } from './modal.component';
import { ModalConfirmComponent } from './modal/modal-confirm/modal-confirm.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {

  currentModalRef: MatDialogRef<ModalComponent> | null = null;

  constructor(private dialog: MatDialog) { }

  openModal(template: TemplateRef<any>,
    size: 'small' | 'medium' | 'large',
    title: string,
    type: 'info' | 'succes' | 'error' | 'warning' | 'answer' | 'security' | null
  ): MatDialogRef<ModalComponent> {
    this.currentModalRef = this.dialog.open(ModalComponent, {
      data: {
        template: template,
        size: size,
        title: title,
        type: type
      }
    });
    return this.currentModalRef;
  }

  closeModal(): void {
    if (this.dialog) {
      this.dialog.closeAll();
    }
  }

  closeModalUnit(): void {
    if (this.currentModalRef) {
      this.currentModalRef.close();
    }
  }


  openConfirmDialog(title:string, message: string): MatDialogRef<ModalConfirmComponent> {
    return this.dialog.open(ModalConfirmComponent, {
      data: { message: message, title:title }
    });
  }

  
}
