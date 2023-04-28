import { Component } from '@angular/core';
//para hacer llamadas a la api
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {
  usuario: string = "";
  password: string = "";

  emisor: any;
  emisores: any;
  res: any;
  constructor(private http: HttpClient, private router: Router,) { };




  login() {


    const url = 'https://localhost:5001/Usuario?usuario=' + this.usuario + '&password=' + this.password;

    this.http.get(url).subscribe(async (response) => {

      this.res = response;
      // Guardar la respuesta en una variable para su posterior uso
      this.res = this.res[0];

      //Comparar si las sucursales son iguales
      if (this.emisor.Codigo != this.res.COMPANIA) {
        console.log("El código de la sucursal no coincide. Emisor seleccionado: ", this.emisor.Codigo, ", la compania es: ", this.res.COMPANIA);
        return;
      }

      if (this.res == null) {
        this.router.navigate(['']);
        console.log("NO Entra");
        return;
      }

      if (this.res.OBSERVACION == "INGRESO EXITOSO") {
        console.log("Entra");
        this.router.navigate(['/home']);
      }

    });
  }


  ngOnInit(): void {
    this.http.get('https://localhost:5001/Usuario/Emisores').subscribe(response => {

      this.emisores = response;

      console.log("Emisores: ", this.emisores);
    });
  }
}
