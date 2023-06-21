import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Cliente } from './Interfaces/cliente';

import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ClienteService } from './Services/cliente.service';
import { DialogAddEditComponent } from './Modals/dialog-add-edit/dialog-add-edit.component';
import { DialogDeleteComponent } from './Modals/dialog-delete/dialog-delete.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit, OnInit {
  title = 'FrontEnd';
  displayedColumns: string[] = ['nombre', 'apellido', 'correoElectronico', 'fechaNacimiento', 'activo', 'direccion', 'telefono', 'Acciones'];
  //displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = new MatTableDataSource<Cliente>();
  constructor(
    private _clienteService: ClienteService,
    public dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) {

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

  showClientes() {
    this._clienteService.getList().subscribe({
      next: (dataResponse) => {
        console.log(dataResponse);
        this.dataSource.data = dataResponse;
      }, error: (e) => { }
    })
  }
  openDialogEditClient(dataCliente: Cliente) {
    this.dialog.open(DialogAddEditComponent,
      {
        disableClose: true,
        width: "40%",
        data: dataCliente
      }).afterClosed().subscribe(resultado => {
        if (resultado === "creado") {
          this.showClientes();
        }
      });
  }
  openDialogNewClient() {
    this.dialog.open(DialogAddEditComponent,
      {
        disableClose: true,
        width: "40%",

      }).afterClosed().subscribe(resultado => {
        if (resultado === "editado") {
          this.showClientes();
        }
      });
  }
  showAlert(message: string, action: string) {
    this._snackBar.open(message, action, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    });
  }
  openDialogDeleteClient(dataCliente:Cliente){
    this.dialog.open(DialogDeleteComponent,
      {
        disableClose: true,
      }).afterClosed().subscribe(resultado => {
        console.log(resultado);
          this._clienteService.delete(dataCliente.usuarioId).subscribe({
            next:(data) => {
              this.showAlert("Cliente eliminado","Listo");
              this.showClientes();
              window.location.reload();
            },error:(e) => {
              this.showAlert("Ha ocurrido un erro","OK");
            }
          })
        
      });
  }
}