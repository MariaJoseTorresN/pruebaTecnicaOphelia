import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Producto } from 'src/app/interface/producto';
import { ProductoService } from 'src/app/services/producto.service';


@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['nombre', 'precio', 'cantidad', 'Acciones'];
  dataSource = new MatTableDataSource<Producto>();
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar,
    private _productoService:ProductoService) { }

  ngOnInit(): void {
    this.obtenerProducto();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if(this.dataSource.data.length > 0){
      this.paginator._intl.itemsPerPageLabel = 'Items por página';
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  obtenerProducto(){
    this.loading = true;
    this._productoService.getProductos().subscribe({
      next: (data) => {
        this.loading = false;
        this.dataSource.data = data;
        console.log(this.dataSource);
      },
      error: (e) => this.loading = false,
      complete:() => console.info('complete')
    })
  }

  eliminarProducto(id: number) {
    this.loading = true;
    this._productoService.deleteProducto(id).subscribe(() => {
      this.successMessage();
      this.loading = false;
      this.obtenerProducto();
    });
  }

  successMessage() {
    this._snackBar.open('Producto eliminado','', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
