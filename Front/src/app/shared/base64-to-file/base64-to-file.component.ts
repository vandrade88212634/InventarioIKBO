import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-base64-to-file',
  standalone: true,
  imports:[MatIconModule],
  templateUrl: './base64-to-file.component.html',
  styleUrls: ['./base64-to-file.component.scss']
})
export class Base64ToFileComponent {
  @Input() base64String: string | undefined;
  @Input() fileName: string | undefined;

  downloadFile() {
    if (this.base64String && this.fileName) {
      const byteCharacters = atob(this.base64String);
      const byteNumbers = new Array(byteCharacters.length);

      for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
      }

      const byteArray = new Uint8Array(byteNumbers);
      const blob = new Blob([byteArray], { type: 'application/octet-stream' });

      // Descargar el archivo con el nombre proporcionado
      const link = document.createElement('a');
      link.href = window.URL.createObjectURL(blob);
      link.download = this.fileName;
      link.click();
    }
  }
}