import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//Modulos
import { SharedModule } from './shared/shared.module';

// Components
import { ClienteComponent } from './components/cliente/cliente.component';
import { ProductoComponent } from './components/producto/producto.component';
import { FacturaComponent } from './components/factura/factura.component';
import { CompraComponent } from './components/compra/compra.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgregarFacturaComponent } from './components/agregar-factura/agregar-factura.component';
import { HomeComponent } from './components/home/home.component';
import { VerfacturaComponent } from './components/verfactura/verfactura.component';
import { ErrorComponent } from './components/error/error.component';
import { AgregarClienteComponent } from './components/agregar-cliente/agregar-cliente.component';
import { VerclienteComponent } from './components/vercliente/vercliente.component';
import { VercompraComponent } from './components/vercompra/vercompra.component';
import { AgregarCompraComponent } from './components/agregar-compra/agregar-compra.component';
import { AgregarProductoComponent } from './components/agregar-producto/agregar-producto.component';
import { VerproductoComponent } from './components/verproducto/verproducto.component';

@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    ProductoComponent,
    FacturaComponent,
    CompraComponent,
    AgregarFacturaComponent,
    HomeComponent,
    VerfacturaComponent,
    ErrorComponent,
    AgregarClienteComponent,
    VerclienteComponent,
    VercompraComponent,
    AgregarCompraComponent,
    AgregarProductoComponent,
    VerproductoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
