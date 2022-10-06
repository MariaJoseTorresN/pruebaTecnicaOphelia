import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Compra } from 'src/app/interface/compra';
import { CompraService } from 'src/app/services/compra.service';

@Component({
  selector: 'app-vercompra',
  templateUrl: './vercompra.component.html',
  styleUrls: ['./vercompra.component.css']
})
export class VercompraComponent implements OnInit {
  id: number;
  compra!: Compra;
  loading: boolean = false;

  constructor(private _compraService: CompraService,
    private aRoute: ActivatedRoute) { 
      this.id = +this.aRoute.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.obtenerCompras();
  }

  obtenerCompras(){
    this.loading = true;
    this._compraService.getCompra(this.id).subscribe(data =>{
      this.compra = data;
      this.loading = false;
    })
  }

}
