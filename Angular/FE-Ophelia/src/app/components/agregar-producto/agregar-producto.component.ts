import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Producto } from 'src/app/interface/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-agregar-producto',
  templateUrl: './agregar-producto.component.html',
  styleUrls: ['./agregar-producto.component.css']
})
export class AgregarProductoComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;
  operacion: string = 'Agregar'

  constructor(private fb: FormBuilder,
    private _productoService: ProductoService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute) { 
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      precio: ['', Validators.required],
      cantidad: ['', Validators.required]
    })
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if(this.id != 0){
      this.operacion = 'Editar';
      this.obtenerProducto(this.id);
    }
  }

  agregarEditarProducto(){
    //Objeto Producto
    const producto: Producto = {
      nombre: this.form.value.nombre,
      precio: this.form.value.precio,
      cantidad: this.form.value.cantidad
    }
    if(this.id != 0) {
      producto.productoId = this.id,
      this.editarProducto(this.id, producto)
    } else {
      this.agregarProducto(producto);
    }
  }

  agregarProducto(producto: Producto) {
    //Envio back
    this._productoService.addProducto(producto).subscribe(data => {
      this.successMessage('agregado');
      this.router.navigate(['/productos'])
    })
  }

  editarProducto(id:number, producto: Producto){
    this._productoService.updateProducto(id, producto).subscribe(() => {
      this.loading = false;
      this.successMessage('editado');
      this.router.navigate(['/productos']);
    });
  }

  obtenerProducto(id: number){
    this._productoService.getProducto(id).subscribe(data => {
      this.form.setValue({
        nombre: data.nombre,
        precio: data.precio,
        cantidad: data.cantidad
      })
      this.loading = false;
    });
  }
  
  successMessage(accion: string) {
    this._snackBar.open(`Producto ${accion}`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
