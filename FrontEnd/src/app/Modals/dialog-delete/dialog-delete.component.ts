import { AfterViewInit, Component, ViewChild, OnInit, Inject } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';

import { Cliente } from 'src/app/Interfaces/cliente';
import { ClienteService } from 'src/app/Services/cliente.service';

@Component({
  selector: 'app-dialog-delete',
  templateUrl: './dialog-delete.component.html',
  styleUrls: ['./dialog-delete.component.css']
})
export class DialogDeleteComponent implements OnInit{
  constructor(
    private dialogRef: MatDialogRef<DialogDeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public dataCliente: Cliente
  ) {
  }


  ngOnInit(): void {
      
  }

  confirmDeletion(): void {
    if(this.dataCliente){
      console.log("Deleting")
      this.dialogRef.close("eliminar")

    }
    this.dialogRef.close("eliminar")
    console.log("Not deleting") 

  }
}
