import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  a='0';
  b='0';
  soma='0';
  nome = '';

  onSubmit() {
    console.log(this.nome);
  }
}
