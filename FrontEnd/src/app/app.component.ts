import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Cliente } from './Interfaces/cliente';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import {ClienteService} from './Services/cliente.service';
import { DialogAddEditComponent } from './Modals/dialog-add-edit/dialog-add-edit.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit, OnInit{
  title = 'FrontEnd';
  displayedColumns: string[] = ['nombre', 'apellido', 'correoElectronico', 'fechaNacimiento', 'activo', 'direccion', 'telefono', 'Acciones'];
 //displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = new MatTableDataSource<Cliente>();
  constructor(
    private _clienteService: ClienteService,
    public dialog: MatDialog
    ){

  }
  
  ngOnInit(): void {
      this.showClientes()
  }


  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  showClientes(){
    this._clienteService.getList().subscribe({
      next:(dataResponse) => {
        console.log(dataResponse);
        this.dataSource.data = dataResponse;
      },error:(e)=>{}
    })
  }
  openDialogNewClient() {
    this.dialog.open(DialogAddEditComponent);
  }
}