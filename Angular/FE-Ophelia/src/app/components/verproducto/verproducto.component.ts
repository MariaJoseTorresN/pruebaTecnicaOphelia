import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Producto } from 'src/app/interface/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-verproducto',
  templateUrl: './verproducto.component.html',
  styleUrls: ['./verproducto.component.css']
})
export class VerproductoComponent implements OnInit {
  id:number;
  producto!: Producto;
  loading: boolean = false;

  constructor(private _productoService: ProductoService,
    private aRoute: ActivatedRoute) { 
      this.id = +this.aRoute.snapshot.paramMap.get('id')!;
    }

  ngOnInit(): void {
    this.obtenerProducto();
  }

  obtenerProducto(){
    this.loading = true;
    this._productoService.getProducto(this.id).subscribe(data => {
      this.producto = data;
      this.loading = false;
    })
  }

}
