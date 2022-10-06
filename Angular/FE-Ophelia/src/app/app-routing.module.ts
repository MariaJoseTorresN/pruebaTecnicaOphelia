import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { FacturaComponent } from './components/factura/factura.component';
import { AgregarFacturaComponent } from './components/agregar-factura/agregar-factura.component';
import { HomeComponent } from './components/home/home.component';
import { VerfacturaComponent } from './components/verfactura/verfactura.component';
import { ErrorComponent } from './components/error/error.component';
import { ClienteComponent } from './components/cliente/cliente.component';
import { ProductoComponent } from './components/producto/producto.component';
import { CompraComponent } from './components/compra/compra.component';
import { AgregarClienteComponent } from './components/agregar-cliente/agregar-cliente.component';
import { VerclienteComponent } from './components/vercliente/vercliente.component';
import { AgregarCompraComponent } from './components/agregar-compra/agregar-compra.component';
import { VercompraComponent } from './components/vercompra/vercompra.component';
import { AgregarProductoComponent } from './components/agregar-producto/agregar-producto.component';
import { VerproductoComponent } from './components/verproducto/verproducto.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'facturas', component: FacturaComponent },
  { path: 'agregarfactura', component: AgregarFacturaComponent },
  { path: 'verfactura/:id', component: VerfacturaComponent },
  { path: 'editarfactura/:id', component: AgregarFacturaComponent},
  { path: 'clientes', component: ClienteComponent},
  { path: 'agregarcliente', component: AgregarClienteComponent},
  { path: 'vercliente/:id', component: VerclienteComponent },
  { path: 'editarcliente/:id', component: AgregarClienteComponent},
  { path: 'productos', component: ProductoComponent},
  { path: 'agregarproducto', component: AgregarProductoComponent},
  { path: 'verproducto/:id', component: VerproductoComponent},
  { path: 'editarproducto/:id', component: AgregarProductoComponent},
  { path: 'compras', component: CompraComponent},
  { path: 'agregarcompra', component: AgregarCompraComponent},
  { path: 'vercompra/:id', component: VercompraComponent},
  { path: 'editarcompra/:id', component: AgregarCompraComponent},
  { path: '**', component: ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
