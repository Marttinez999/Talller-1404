import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../modelos/Usuario';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styles: []
})
export class ConsultaComponent implements OnInit {

  usuarios: Usuario[] = [];
  constructor(private _usuarioService: UsuarioService) { }

  ngOnInit() {
    this._usuarioService.get().subscribe(r => {
      this.usuarios = r;
    });
  }

}
