import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from 'src/app/interface/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-agregar-cliente',
  templateUrl: './agregar-cliente.component.html',
  styleUrls: ['./agregar-cliente.component.css']
})
export class AgregarClienteComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;
  operacion: string = 'Agregar';

  constructor(private fb: FormBuilder,
    private _clienteService: ClienteService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute) { 
    this.form = this.fb.group({
      cedula: ['', Validators.required],
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      celular: ['', Validators.required],
      correo: ['', Validators.required],
    })

    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if(this.id !=0) {
      this.operacion = 'Editar';
      this.obtenerCliente(this.id);
    }
  }

  agregarEditarCliente() {

    //Objeto Cliente
    const cliente: Cliente = {
      cedula: this.form.value.cedula+"",
      nombre: this.form.value.nombre,
      apellido: this.form.value.apellido,
      fechaNacimiento: this.form.value.fechaNacimiento,
      celular: this.form.value.celular+"",
      correo: this.form.value.correo
    }

    if(this.id !=0) {
      cliente.clienteId = this.id,
      this.editarCliente(this.id,cliente);
    } else {
      this.agregarCliente(cliente);
    }

    

  }

  agregarCliente(cliente: Cliente){
    //Envio back
    this._clienteService.addCliente(cliente).subscribe(data =>{
      this.successMessage('agregado');
      this.router.navigate(['/clientes'])
    })
  }

  editarCliente(id:number, cliente: Cliente){
    this.loading = true;
    this._clienteService.updateCliente(id, cliente).subscribe(() =>{
      this.loading = false;
      this.successMessage('editado');
      this.router.navigate(['/clientes']);
    });
  }

  obtenerCliente(id: number){
    this._clienteService.getCliente(id).subscribe(data => {
      this.form.setValue({
        cedula: data.cedula,
        nombre: data.nombre,
        apellido: data.apellido,
        fechaNacimiento: data.fechaNacimiento,
        celular: data.celular,
        correo: data.correo
      })
      this.loading = false;
    });
  }

  successMessage(accion: string) {
    this._snackBar.open(`Cliente ${accion}`,'', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }

}
