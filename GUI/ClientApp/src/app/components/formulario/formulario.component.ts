import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../modelos/Usuario';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styles: []
})
export class FormularioComponent implements OnInit {

  usuario: Usuario;

  constructor(private _usuarioService: UsuarioService) {
    this.usuario = new Usuario();
   }

  ngOnInit() {}

  agregarUsuario() {
    this._usuarioService.post(this.usuario);
  }
}
