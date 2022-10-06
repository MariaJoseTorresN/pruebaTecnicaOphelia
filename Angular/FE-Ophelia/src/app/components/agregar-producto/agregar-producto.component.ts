import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Producto } from 'src/app/interface/producto';

@Component({
  selector: 'app-agregar-producto',
  templateUrl: './agregar-producto.component.html',
  styleUrls: ['./agregar-producto.component.css']
})
export class AgregarProductoComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup

  constructor(private fb: FormBuilder) { 
    this.form = this.fb.group({
      Nombre: ['', Validators.required],
      Precio: ['', Validators.required],
      Cantidad: ['', Validators.required],
      Compra: ['', Validators.required]
    })
  }

  ngOnInit(): void {
  }

  agregarProducto() {

    //Objeto Producto
    const producto: Producto = {
      nombre: this.form.value.nombre,
      precio: this.form.value.precio,
      cantidad: this.form.value.cantidad,
      compra: this.form.value.compra
    }
  }

}
