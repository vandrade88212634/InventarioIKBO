import { CommonModule } from '@angular/common';
import { Component, Inject, TemplateRef } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

export interface DialogModel {
  title: string;
  content: string;
}

export interface DialogTemplateData {
  template: TemplateRef<any>;
  size: 'small' | 'medium' | 'large';
  title: string;
  type: 'info' | 'succes' | 'error' | 'warning' | 'answer' | 'security'
}

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css',
  providers: [] 
})
export class ModalComponent {

  icons = {
    info :'info',
    succes : 'check_circle',
    error :'error',
    warning : 'add_alert',
    answer : 'help',
    security: 'security'
  }


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: DialogTemplateData,
    private dialogRef: MatDialogRef<ModalComponent>
  ) {
    
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  getSizeClass(): string {
    return this.data.size + ' mat-dialog';
  }

}  