import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Compra } from 'src/app/interface/compra';
import { CompraService } from 'src/app/services/compra.service';

@Component({
  selector: 'app-compra',
  templateUrl: './compra.component.html',
  styleUrls: ['./compra.component.css']
})
export class CompraComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['PrecioPagar', 'Cantidad', 'FacturaId', 'ProductoId', 'Acciones']
  dataSource = new MatTableDataSource<Compra>();
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar,
    private _compraService:CompraService) { }

  ngOnInit(): void {
    this.obtenerCompras();
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

  obtenerCompras(){
    this.loading = true;
    this._compraService.getCompras().subscribe({
      next: (data) => {
        this.loading = false;
        this.dataSource.data = data;
        console.log(this.dataSource);
      },
      error: (e) => this.loading = false,
      complete:() => console.info('complete')
    })
  }

  eliminarCompra(id: number) {
    this.loading = true;
    this._compraService.deleteCompra(id).subscribe(( )=> {
      this.successMessage();
      this.loading = false;
      this.obtenerCompras();
    });
  }

  successMessage() {
    this._snackBar.open('Compra eliminada','', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
