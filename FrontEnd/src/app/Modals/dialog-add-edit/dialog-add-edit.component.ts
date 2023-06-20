import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

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

@Component({
  selector: 'app-dialog-add-edit',
  templateUrl: './dialog-add-edit.component.html',
  styleUrls: ['./dialog-add-edit.component.css'],
  providers: [
    {provide: MAT_DATE_FORMATS,useValue: MY_DATE_FORMATS},]
})

export class DialogAddEditComponent implements OnInit {
  formCliente : FormGroup;
  tituloAccion : string = "Nuevo"
  botonAccion:string = "Guardar"

  constructor(
    private dialogRef: MatDialogRef<DialogAddEditComponent>,
    private fb: FormBuilder,
    private _snackbar: MatSnackBar,
    private _clienteService: ClienteService,
  ){

    this.formCliente = this.fb.group({
      nombre:["",Validators.required],
      apellido:["",Validators.required],
      email:["",Validators.required],
      fechaDeNacimiento:["",Validators.required],
      activo:["",Validators.required],
      direccion:["",Validators.required],
      telefono:["",Validators.required],
    });
    
  }
  showAlert(message:string,action:string){
    this._snackbar.open(message,action,{
      horizontalPosition:"end",
      verticalPosition:"top",
      duration:3000
    });
  }
  
  addEditCliente(){
    console.log(this.formCliente);
    console.log(this.formCliente.value);
  }
  
  ngOnInit(): void {
    
}


}

