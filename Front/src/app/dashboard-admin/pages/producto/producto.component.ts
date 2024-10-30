import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { ModalService } from '../../../shared/modal/modal.service';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_LOCALE, provideNativeDateAdapter } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { Router } from '@angular/router';
import { productoFecha, responseProductoFecha} from '../../../core/models/productofecha.model';
import {responseProducto, producto} from '../../../core/models/producto.model';
import { ProductoService } from '../../../services/producto/producto.service';
import { AuthService } from '../../../services/auth/auth.service';
import { AesService } from '../../../services/aes/aes.service';
import { MatSort, MatSortModule } from '@angular/material/sort';

import { AbstractControl, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MatMomentDateModule } from '@angular/material-moment-adapter';

const ELEMENT_DATA_PRODUCTO: producto[] = [];
const ELEMENT_DATA_PRODUCTOFECHA: productoFecha[] = [];


@Component({
  selector: 'app-producto',
  standalone: true,
  providers: [provideNativeDateAdapter(), { provide: MAT_DATE_LOCALE, useValue: 'es-ES' }, // Establece el idioma en español
  { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } }], // Opcional: configura otras opciones del adaptador de fecha y hora],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MatProgressBarModule, MatPaginatorModule, MatTableModule, MatSortModule, MatIconModule, MatSelectModule, MatButtonModule, MatFormFieldModule, MatDividerModule, MatInputModule, MatDatepickerModule, MatMomentDateModule,MatCheckboxModule],
  templateUrl: './producto.component.html',
  styleUrl: './producto.component.css'
})
export class productoComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  
  
  
 
  accion = "Add"
  isLoader = false;
  
  IdProducto = 0
  Nombre = '';
  //--Datos Usuario--//

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  @ViewChild(MatSort) sort!: MatSort;

  @ViewChild('add', { static: true })
  addTemplate!: TemplateRef<any>;
  @ViewChild('addBtn', { static: true })
  addBtnTemplate!: TemplateRef<any>;
  @ViewChild('view', { static: true })
  viewTemplate!: TemplateRef<any>;
  @ViewChild('edit', { static: true })
  editTemplate!: TemplateRef<any>;
  @ViewChild('delete', { static: true })
  deleteTemplate!: TemplateRef<any>;
  @ViewChild('cancel', { static: true })
  cancelTemplate!: TemplateRef<any>;
  @ViewChild('block', { static: true })
  blockTemplate!: TemplateRef<any>;
  @ViewChild('unblock', { static: true })
  unblockTemplate!: TemplateRef<any>;
  @ViewChild('accions', { static: true })
  accionsTemplate!: TemplateRef<any>;
  searchTerm = '';
  textAddEdit: string = '';
  textDelete: string = '¿Está seguro de que desea eliminar?';
  subTextDelete: string = 'Al eliminarlo, se eliminarán permanentemente todos sus datos y perderá el acceso al sistema.';
  regActivo: boolean = false;
  textActivar: string = '';
  subTextActivar: string = '';
  editarDatos = false;
  asignar = false;
  NuevoLote = false;
  addEditForm = new FormGroup({

 
    IdProducto: new FormControl(''),
    Nombre: new FormControl(''),
    
    
   
  });


  constructor(private modalService: ModalService,   private aes: AesService, private ProductoService : ProductoService, private authService : AuthService,private router: Router) {
    // Crear una instancia de MatTableDataSource con tu array de usuarios y paginator
    
    // Observa cambios en el campo tipoUsu
   
  }

  ngOnInit(): void {
   
     
    } 
  

 



  
  closemodal(): void {
    const customTemplate: TemplateRef<any> = this.cancelTemplate;
    this.modalService.openModal(customTemplate, 'medium', '¿Está seguro de que desea cancelar?', 'info',);
  }

  confirmClosemodal(): void {
    setTimeout(() => {
      this.modalService.closeModal();// Cierra todos los modales abiertos
    }, 1000);;
  }

  modalAccions(idTarea: number) {
    
    const customTemplate: TemplateRef<any> = this.accionsTemplate;
    this.modalService.openModal(customTemplate, 'medium', '', null);
  }

  clickAddEdit(accion: string, idTarea: any): void {
    this.addEditForm.reset();
    this.accion = accion;
   
    
    
   {
      this.textAddEdit = 'Crear nuevo Producto';
    const customTemplate: TemplateRef<any> = this.addTemplate;
    setTimeout(() => {
      this.modalService.openModal(customTemplate, 'large', '', null);
    }, 500);
  }
}

  addOreditTarea() {
  
    let message = 'Editar Tarea';
    if (this.accion === 'add') message = 'Crear Producto';
    const data = {
    
      IdProducto: 0,
      Nombre: this.addEditForm.get('Nombre')!.value!,
      IsSucess: false,
      Message: ''
      
      
    
    }


    if (this.accion === 'add') {
        data.IdProducto = 0;
      this.ProductoService.InsertProducto(data).subscribe({
        next: (data: any) => {
          console.log(data.result);
          if (data.result.isSuccess)
            {
            const customTemplate: TemplateRef<any> = this.addBtnTemplate;
            this.modalService.openModal(customTemplate, 'small', 'Entrada creada con éxito!', 'succes',);
           
          } 
          else {
            console.log(data.result.messages);
            const customTemplate: TemplateRef<any> = this.addBtnTemplate;
            this.modalService.openModal(customTemplate, 'small', data.result.messages, 'info',);
           
          }
        },
        error: (error) => {
          console.error('Error:', error);
        },
      });
    } 
    this.confirmClosemodal();
  }

 salir()
 {
  this.router.navigate(['/DashboardAdmin']);

 }
 

   
 
}
