import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Factura } from 'src/app/interface/factura';
import { FacturaService } from 'src/app/services/factura.service';

@Component({
  selector: 'app-agregar-factura',
  templateUrl: './agregar-factura.component.html',
  styleUrls: ['./agregar-factura.component.css']
})
export class AgregarFacturaComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;
  operacion: string = 'Agregar';

  constructor(private fb: FormBuilder,
    private _facturaService:FacturaService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute){
    this.form = this.fb.group({
      fecha: ['', Validators.required],
      precioTotal: ['', Validators.required],
      clienteId: ['', Validators.required],
    })
    this.id = Number(aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if(this.id != 0){
      this.operacion = 'Editar';
      this.obtenerFactura(this.id);
    }
  }

  obtenerFactura(id: number){
    this.loading = true;
    this._facturaService.getFactura(id).subscribe(data => {
      this.loading = false;
      this.form.setValue({
        fecha: data.fecha,
        precioTotal: data.precioTotal,
        clienteId: data.clienteId
      })
    })
  }

  agregarEditarFactura() {

    //Objeto Factura
    const factura: Factura = {
      fecha: this.form.value.fecha,
      precioTotal: this.form.value.precioTotal,
      clienteId: this.form.value.clienteId
    }

    if(this.id != 0){
      factura.facturaId = factura.facturaId;
      this.editarFactura(this.id,factura);
    }else{
      this.agregarFactura(factura);
    }
    
  }

  editarFactura(id:number, factura:Factura){
    this.loading = true;
    this._facturaService.updateFactura(id,factura).subscribe(() =>{
      this.loading = false;
      this.successMessage('actualizada');
      this.router.navigate(['/facturas']);
    });
  }

  agregarFactura(factura:Factura){
    // Envio back
    this._facturaService.addFactura(factura).subscribe(data => {
      this.successMessage('registrada');
      this.router.navigate(['/facturas']);
    })
  }

  successMessage(msg: string) {
    this._snackBar.open(`Factura ${msg}`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
