import { Component, DebugElement, OnInit, TemplateRef, ViewChild } from '@angular/core';
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
import { ExistenciasService } from '../../../services/existencias/existencias.service';
import { existencias, responseExistencias } from '../../../core/models/existencias.model';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { AesService } from '../../../services/aes/aes.service';
import { MatSort, MatSortModule } from '@angular/material/sort';

import { AbstractControl, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MatMomentDateModule } from '@angular/material-moment-adapter';

const ELEMENT_DATA_EXISTENCIA: existencias[] = [];



@Component({
  selector: 'app-soporte',
  standalone: true,
  providers: [provideNativeDateAdapter(), { provide: MAT_DATE_LOCALE, useValue: 'es-ES' }, // Establece el idioma en español
  { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } }], // Opcional: configura otras opciones del adaptador de fecha y hora],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MatProgressBarModule, MatPaginatorModule, MatTableModule, MatSortModule, MatIconModule, MatSelectModule, MatButtonModule, MatFormFieldModule, MatDividerModule, MatInputModule, MatDatepickerModule, MatMomentDateModule],
  templateUrl: './existencias.component.html',
  styleUrl: './existencias.component.css'
})
export class ExistenciasComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayedColumns: string[] = ['nombre', 'fechaVence',  'nombreEstado','saldo'];
 
  dataSource: MatTableDataSource<existencias>; // Instancia de MatTableDataSource
  existencias = ELEMENT_DATA_EXISTENCIA;
  dataStatic = ELEMENT_DATA_EXISTENCIA;
  dataOri = ELEMENT_DATA_EXISTENCIA;
  accion = '';
  opcional: boolean = true;

  isLoader = false;
  // Datos Usuario //

 
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

 

  constructor(private modalService: ModalService,  private ExistenciasService:ExistenciasService,  private aes: AesService,  private authService : AuthService, private router : Router) {
    // Crear una instancia de MatTableDataSource con tu array de usuarios y paginator
    this.dataSource = new MatTableDataSource<existencias>(this.existencias);
    this.dataStatic = this.existencias;
    this.dataOri = this.existencias;
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    // Observa cambios en el campo tipoUsu
   
  }

  ngOnInit(): void {
   
    debugger;
    this.getAllExistencias();

    
  }

 

   

 
  onPageChange(event: any) {
    const startIndex = event.pageIndex * event.pageSize;
    const endIndex = startIndex + event.pageSize;
    const newData = this.existencias.slice(startIndex, endIndex);
    this.dataSource = new MatTableDataSource<existencias>(newData);
  }

  getAllExistencias() 
  {
    const data = {
    
      IdProducto: 0,
      Nombre: '',
      IsSucess: false,
      Message: ''
      
      
    
    }

    this.ExistenciasService.GetAllExistencias(data).subscribe({
      next: (data: any) => {
     
       
        this.dataSource = data.result;
        this.existencias = data.result;
        this.dataStatic = data.result;
        this.dataOri = data.result;
        this.resultsLength = data.result.length;
        this.isLoader = true;
       
      },
      error: (error) => {
        console.error('Error:', error);
      },
    });
  }
    
 

  

  applyFilter(event: Event) {
    console.log(event);
    const filterValue = (event.target as HTMLInputElement).value;
    
    this.existencias = this.dataStatic.filter(
      (item: any) =>
        
        item.nombre.toLowerCase().includes(filterValue.toLowerCase()) ||
      
        item.nombreEstado.toLowerCase().includes(filterValue.toLowerCase()) 
        
       
       
        
    );
    debugger;
    this.updateDataSource();
  }

  updateDataSource() {
    this.dataSource = new MatTableDataSource<existencias>(this.existencias);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.resultsLength = this.existencias.length;
  }

  salir()
 {
  this.router.navigate(['/DashboardAdmin']);

 }
 

 
 

}