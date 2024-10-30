import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class AesService {

  constructor() { }

  key = 'ThisIsASecretKey';

  encryptData(data: string): any {
    
      var lkey = CryptoJS.enc.Utf8.parse(this.key);
      let ciphertext = CryptoJS.AES.encrypt(data, lkey, {iv: lkey}).toString();
      return ciphertext;

  }

  // Método para desencriptar el mensaje AES
  decryptData(encryptedData: any): any {
    
  
    var lkey = CryptoJS.enc.Utf8.parse(this.key);
    let decryptedData = CryptoJS.AES.decrypt(encryptedData, lkey, {
      iv: lkey
    });
    return decryptedData.toString( CryptoJS.enc.Utf8 );
  }

}
