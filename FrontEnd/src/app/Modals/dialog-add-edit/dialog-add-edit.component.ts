import { AfterViewInit, Component, ViewChild, OnInit, Inject } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';

import { Cliente } from 'src/app/Interfaces/cliente';
import { ClienteService } from 'src/app/Services/cliente.service';

export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
    dataA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  },
}
interface Animal {
  name: string;
}
@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.css'],

  providers: [
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS },],


})

export class DialogAddEditComponent implements OnInit {
  formCliente: FormGroup;
  tituloAccion: string = "Nuevo"
  botonAccion: string = "Guardar"

  constructor(
    private dialogRef: MatDialogRef<DialogAddEditComponent>,
    private fb: FormBuilder,
    private _snackbar: MatSnackBar,
    private _clienteService: ClienteService,
    @Inject(MAT_DIALOG_DATA) public dataCliente: Cliente
  ) {

    this.formCliente = this.fb.group({
      nombre: ["", Validators.required],
      apellido: ["", Validators.required],
      correoElectronico: ["", Validators.required],
      fechaDeNacimiento: ["", Validators.required],
      activo: ["", Validators.required],
      direccion: ["", Validators.required],
      telefono: ["", Validators.required],

    });

  }
  animalControl = new FormControl<Animal | null>(null, Validators.required);
  selectFormControl = new FormControl('', Validators.required);
  animals: Animal[] = [
    { name: 'Yes' },
    { name: 'No' },
  ]
  showAlert(message: string, action: string) {
    this._snackbar.open(message, action, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    });
  }

  addEditCliente() {
    console.log(this.formCliente);
    console.log(this.formCliente.value);
    let activo = true;
    if (this.selectFormControl.value === "No") {
      activo = false;
    }
    const modelo: Cliente = {
      usuarioId: 0,
      nombre: this.formCliente.value.nombre,
      apellido: this.formCliente.value.apellido,
      correoElectronico: this.formCliente.value.correoElectronico,
      fechaDeNacimiento: this.formCliente.value.fechaDeNacimiento,
      activo: activo,
      direccion: this.formCliente.value.direccion,
      telefono: this.formCliente.value.telefono
    }

    if (this.dataCliente == null) {
      this._clienteService.add(modelo).subscribe({
        next: (dataModelo) => {
          this.showAlert("Cliente agregado", "Listo");
          this.dialogRef.close("creado");
          window.location.reload();
        },
        error: (err) => {
          this.showAlert("Ha ocurrido un error", "Cerrar");
        }
      });
    } else {
      this._clienteService.update(this.dataCliente.usuarioId, modelo).subscribe({
        next: (dataModelo) => {
          this.showAlert("Cliente actualizado", "Listo");
          this.dialogRef.close("editado");
          window.location.reload();
        },
        error: (err) => {
          this.showAlert("Ha ocurrido un error", "Cerrar");
        }
      });

    }

  }


  ngOnInit(): void {
    console.log(this.dataCliente)
    if (this.dataCliente) {
      this.selectFormControl.setValue(this.dataCliente.activo ? 'Yes' : 'No');
      this.formCliente.patchValue({
        id: this.dataCliente.usuarioId,
        nombre: this.dataCliente.nombre,
        apellido: this.dataCliente.apellido,
        correoElectronico: this.dataCliente.correoElectronico,
        fechaDeNacimiento: moment(this.dataCliente.fechaDeNacimiento).toDate(),
        activo: this.dataCliente.activo,
        direccion: this.dataCliente.direccion,
        telefono: this.dataCliente.telefono
      });
    }
    this.tituloAccion = "Actualizar";
    this.botonAccion = "Editar";

  }





}

