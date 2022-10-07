import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cliente } from 'src/app/interface/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-vercliente',
  templateUrl: './vercliente.component.html',
  styleUrls: ['./vercliente.component.css']
})
export class VerclienteComponent implements OnInit {
  id: number;
  cliente!: Cliente;
  loading: boolean = false;

  constructor(private _clienteService: ClienteService,
    private aRoute: ActivatedRoute) { 
      this.id = +this.aRoute.snapshot.paramMap.get('id')!;
    }

  ngOnInit(): void {
    this.obtenerCliente();
  }

  obtenerCliente(){
    this.loading = true;
    this._clienteService.getCliente(this.id).subscribe(data =>{
      this.cliente = data;
      this.loading = false;
    })
  }

}
