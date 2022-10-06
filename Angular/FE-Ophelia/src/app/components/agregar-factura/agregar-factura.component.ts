import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Factura } from 'src/app/interface/factura';

@Component({
  selector: 'app-agregar-factura',
  templateUrl: './agregar-factura.component.html',
  styleUrls: ['./agregar-factura.component.css']
})
export class AgregarFacturaComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup

  constructor(private fb: FormBuilder){
    this.form = this.fb.group({
      Fecha: ['', Validators.required],
      PrecioTotal: ['', Validators.required],
      Cliente: ['', Validators.required],
      Compras: ['', Validators.required],
    })
  }

  ngOnInit(): void {
  }

  agregarFactura() {

    //Objeto Factura
    const factura: Factura = {
      fecha: this.form.value.fecha,
      precioTotal: this.form.value.precioTotal,
      clienteId: this.form.value.clienteId
    }
  }

}
