import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../modelos/Usuario';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styles: []
})
export class FormularioComponent implements OnInit {

  usuario: Usuario;
  formGroup: FormGroup;

  constructor(private _usuarioService: UsuarioService, private formBuilder: FormBuilder) {
    this.usuario = new Usuario();
   }

  ngOnInit() {
    this.buildForm();
  }
  private buildForm() {
    this.usuario = new Usuario();
    this.usuario.identificacion = '';
    this.usuario.nombre = '';
    this.usuario.costo = 0;
    this.usuario.copago = 0;
    this.usuario.salario = 0;

    this.formGroup = this.formBuilder.group({
      identificacion: [this.usuario.identificacion, Validators.required],
      nombre: [this.usuario.nombre, Validators.required],
      costo: [this.usuario.costo, Validators.required, Validators.min(1)],
      salario: [this.usuario.salario, Validators.required, Validators.min(1)]
    });
  }

  agregarUsuario() {
    this._usuarioService.post(this.usuario).subscribe(p => {
      if (p != null) {
        console.log(p + ' ha sido creado');
        this.usuario = p;
      }
    });
  }
  onSubmit() {
    if (!this.formGroup.invalid) {
      this.agregarUsuario();
    }
  }
}
