import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Factura } from 'src/app/interface/factura';
import { FacturaService } from 'src/app/services/factura.service';

@Component({
  selector: 'app-verfactura',
  templateUrl: './verfactura.component.html',
  styleUrls: ['./verfactura.component.css']
})
export class VerfacturaComponent implements OnInit {
  id!:number;
  factura!: Factura;
  loading: boolean = false;

  constructor(private _facturaService:FacturaService,
    private aRoute: ActivatedRoute) { 
      this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
    }

  ngOnInit(): void {
    this.obtenerFactura();
  }

  obtenerFactura(){
    this.loading = true;
    this._facturaService.getFactura(this.id).subscribe(data => {
      this.factura = data
      this.loading = false;
    })
  }

}
