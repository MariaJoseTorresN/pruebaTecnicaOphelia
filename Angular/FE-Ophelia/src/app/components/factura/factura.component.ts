import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Factura } from 'src/app/interface/factura';
import { FacturaService } from 'src/app/services/factura.service';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.css']
})
export class FacturaComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['fecha', 'precioTotal', 'clienteId', 'Acciones'];
  dataSource = new MatTableDataSource<Factura>();
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar, 
    private _facturaService:FacturaService) { }

  ngOnInit(): void {
    this.obtenerfacturas();
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
  }

  obtenerfacturas(){
    this.loading = true;
    this._facturaService.getFacturas().subscribe(data =>{
      this.dataSource.data = data;
      this.loading = false;
      console.log(data);
    });
  }

  eliminarFactura(id:number) {
    this.loading = true;
    this._facturaService.deleteFactura(id).subscribe(() => {
      this.successMessage();
      this.loading = false;
      this.obtenerfacturas();
    });
  }

  successMessage() {
    this._snackBar.open('Factura eliminada','', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
