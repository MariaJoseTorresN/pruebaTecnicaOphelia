import { Cliente } from "./cliente";

export interface Factura {
    facturaId?: number,
    fecha: string,
    precioTotal: number,
    clienteId:number,
    cliente: Cliente
}
