import { Factura } from "./factura";
import { Producto } from "./producto";

export interface Compra {
    compraId?: number,
    precioPagado: number,
    cantidad: number,
    facturaId: number,
    productoId: number,
    factura: Factura,
    producto: Producto
}
