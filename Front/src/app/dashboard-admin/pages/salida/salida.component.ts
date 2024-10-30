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
import { MAT_DATE_LOCALE, MatOptionModule, provideNativeDateAdapter } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import {SalidaService } from '../../../../app/services/salida/salida.service';
import { producto } from '../../../core/models/producto.model';
import { productoFecha} from '../../../core/models/productofecha.model';
import { AesService } from '../../../services/aes/aes.service';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { AbstractControl, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MatMomentDateModule } from '@angular/material-moment-adapter';
import { Router } from '@angular/router';
const ELEMENT_DATA_PRODUCTO: producto[] = [];
const ELEMENT_DATA_PRODUCTOFECHA: productoFecha[] = [];


@Component({
  selector: 'app-salida',
  standalone: true,
  providers: [provideNativeDateAdapter(), { provide: MAT_DATE_LOCALE, useValue: 'es-ES' }, // Establece el idioma en español
  { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } }], // Opcional: configura otras opciones del adaptador de fecha y hora],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MatProgressBarModule, MatPaginatorModule, MatTableModule, MatSortModule, MatIconModule, MatSelectModule, MatOptionModule, MatButtonModule, MatFormFieldModule, MatDividerModule, MatInputModule, MatDatepickerModule, MatMomentDateModule,MatCheckboxModule],
  templateUrl: './salida.component.html',
  styleUrl: './salida.component.css'
})
export class SalidaComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  
  Productos = ELEMENT_DATA_PRODUCTO; // Tu array de usuarios
  FechasVen = ELEMENT_DATA_PRODUCTOFECHA;
 
  
 
  accion = "Add"
  isLoader = false;
  
  IdMvto = 0
  IdProducto = '';
  IdProductoFecha = 0;
  Cantidad = 0;
  fecha = '';
  fechaVence= '' ;

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
    IdProductoFecha:  new FormControl(''),
    Cantidad: new FormControl(0),
    fecha: new FormControl(''),
    fechaVence: new FormControl(''),
    NuevoLote:new FormControl(false),
   
  });


  constructor(private modalService: ModalService,   private aes: AesService, private SalidaService : SalidaService, private router: Router) {
    // Crear una instancia de MatTableDataSource con tu array de usuarios y paginator
    
    // Observa cambios en el campo tipoUsu
   
  }

  ngOnInit(): void {
    
     this.SalidaService.GetAllProductos().subscribe({
      next: (data: any) => {
        console.log(data.result);
        if (data.isSuccess)
          {
           
            this.Productos = data.result
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
  

 productosFechas(IdProducto: number)
 {

  this.SalidaService.GetAllProductosFechaByIdProducto(IdProducto).subscribe({
    next: (data: any) => {
      console.log(data.result);
      if (data.isSuccess)
        {
          this.FechasVen = data.result
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
    
    console.log(this.Productos);
     
    
    
   {
      this.textAddEdit = 'Crear nueva entrada';
    const customTemplate: TemplateRef<any> = this.addTemplate;
    setTimeout(() => {
      this.modalService.openModal(customTemplate, 'large', '', null);
    }, 500);
  }
}

  addOreditTarea() {
  
    let message = 'Editar Tarea';
    if (this.accion === 'add') message = 'Crear Tarea';
       let idProductoFecha = 0
       if (!this.NuevoLote)
       {
          idProductoFecha =  parseInt(this.addEditForm.get('IdProductoFecha')!.value!)   
       }
       
    const data = {
      idMvto:0,
      idProducto: this.addEditForm.get('IdProducto')!.value!,
      idProductoFecha : idProductoFecha,
      idTipoMvto : 1,
      cantidad:this.addEditForm.get('Cantidad')!.value!,
      fecha: this.addEditForm.get('fecha')!.value!,
      fechaVence: this.addEditForm.get('fechaVence')!.value!,
      nombreProducto: 'xxx',
      nombreTipoMvto:'xxx',
      isSucess:false,
      message: ' '

      
    
    }
 
    
    if (this.accion === 'add') {
        data.idMvto = 0;
    if (data.fechaVence == null)
        data.fechaVence = '1901-01-01';


      this.SalidaService.InsertSalida(data).subscribe({
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
  

  cambiarNuevoLote(e:any){
 
    this.NuevoLote = e.checked;
  }

   
 
}
