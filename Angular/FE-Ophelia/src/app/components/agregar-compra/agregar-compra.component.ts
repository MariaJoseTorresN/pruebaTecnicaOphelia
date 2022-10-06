import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Compra } from 'src/app/interface/compra';
import { CompraService } from 'src/app/services/compra.service';

@Component({
  selector: 'app-agregar-compra',
  templateUrl: './agregar-compra.component.html',
  styleUrls: ['./agregar-compra.component.css']
})
export class AgregarCompraComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;
  operacion: string = 'Agregar';

  constructor(private fb: FormBuilder,
    private _compraService: CompraService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute) { 
    this.form = this.fb.group({
      PrecioPagado: ['', Validators.required],
      Cantidad: ['', Validators.required],
      FacturaId: ['', Validators.required],
      ProductoId: ['', Validators.required]
    })

    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if(this.id !=0) {
      this.operacion = 'Editar';
      this.obtenerCompra(this.id);
    }
  }

  agregarEditarCompra() {

    //Objeto Compra
    const compra: Compra = {
      precioPagar: this.form.value.precioPagado,
      cantidad: this.form.value.cantidad,
      productoId: this.form.value.productoId,
      facturaId: this.form.value.facturaId
    }

    if(this.id !=0) {
      compra.compraId = this.id,
      this.editarCompra(this.id,compra);
    } else {
      this.agregarCompra(compra);
    }

    

  }

  agregarCompra(compra: Compra){
    //Envio back
    this._compraService.addCompra(compra).subscribe(data =>{
      this.successMessage('agregada');
      this.router.navigate(['/compras'])
    })
  }

  editarCompra(id:number, compra: Compra){
    this.loading = true;
    this._compraService.updateCompra(id, compra). subscribe(() =>{
      this.loading = false;
      this.successMessage('editada');
      this.router.navigate(['/compras']);
    });
  }

  obtenerCompra(id: number){
    this._compraService.getCompra(id).subscribe(data => {
      this.form.setValue({
        precioPagar: data.precioPagar,
        cantidad: data.cantidad,
        productoId: data.productoId,
        facturaId: data.facturaId
      })
      this.loading = false;
    });
  }

  successMessage(accion: string) {
    this._snackBar.open(`Compra ${accion}`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
