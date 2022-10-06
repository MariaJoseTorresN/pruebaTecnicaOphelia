import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Cliente } from 'src/app/interface/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit, AfterViewInit{
  displayedColumns: string[] = ['cedula', 'nombre', 'apellido', 'fechaNacimiento', 'celular', 'correo', 'Acciones'];
  dataSource = new MatTableDataSource<Cliente>();
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar, 
    private _clienteService:ClienteService) { }

  ngOnInit(): void {
    this.obtenerClientes();
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

  obtenerClientes(){
    this.loading = true;
    this._clienteService.getClientes().subscribe({
      next: (data) => {
        this.loading = false;
        this.dataSource.data = data;
        console.log(this.dataSource);
      },
      error: (e) => this.loading = false,
      complete:() => console.info('complete')
    })
  }
  
  eliminarCliente(id: number) {
    this.loading = true;
    this._clienteService.deleteCliente(id).subscribe(() =>{
      this.successMessage();
      this.loading = false;
      this.obtenerClientes();
    });
  }

  successMessage() {
    this._snackBar.open('Cliente eliminado','', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
