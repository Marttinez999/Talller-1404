import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../modelos/Usuario';
import { FormGroup, FormBuilder, Validators, AbstractControl, FormControl} from '@angular/forms';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styles: []
})
export class FormularioComponent implements OnInit {

  get control() {
    return this.formGroup.controls;
  }

  usuario: Usuario;
  formGroup: FormGroup;

  constructor(private _usuarioService: UsuarioService, private formBuilder: FormBuilder) {
    this.usuario = new Usuario();
   }

  ngOnInit() {
    this.buildForm();
  }
  private buildForm() {

    this.formGroup = this.formBuilder.group({

      id: ['', Validators.required],
      nombre: ['', Validators.required],
      salario: [0, [Validators.required, Validators.min(1)]],
      costo: [0, [Validators.required, Validators.min(1)]],

    });

  }

  agregarUsuario() {
    this.usuario = this.formGroup.value;
    console.log(this.usuario);
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
