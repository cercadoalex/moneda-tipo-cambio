import { Component, OnInit } from '@angular/core';
import { Divisa } from 'src/core/models/Divisa';
import { RequestTipoCambio } from 'src/core/models/RequestTipoCambio';
import { ConvertirService } from 'src/core/services/Convertir.service';
import { DivisaService } from 'src/core/services/Divisa.service';
import { TablaConversionService } from 'src/core/services/TablaConversion.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

    //Formulario Modificar
    montoModificar: number = 1;
    monedaModificar: string = ""
    texto_servicio: string = ""

    //Estado para mostrar formulario
    stateCambioMoneda: boolean = true
    stateActualizarCambioMoneda: boolean = false;

    imagenMonedaOrigen: any = "";
    imagenMonedaDestino: any = "";

    selectedMonedaOrigen: any;
    selectedMonedaDestino: any;


    monedaOrigen: any = "";
    monedaDestino: any = "";
    monto: number = 1;
    valorCambio: any = "";

    constructor(private _tablaConversionService: TablaConversionService, private _divisaService: DivisaService, private _convertirService: ConvertirService) {
    }
    divisas: Array<Divisa> = [];


    ngOnInit() {
        this.GetDivisa();
    }
    GetDivisa() {
        this._divisaService.GetAllDivisa().subscribe(response => {
            if (response.error) {
            } else {
                this.divisas = response.data;
            }
        },
            err => {
                console.error(err);
            },
            () => {
                console.log('Finished!');
            });
    }

    RealizarConversion() {
        this._convertirService.GetConvertirMoneda(this.monedaOrigen, this.monedaDestino, this.monto).subscribe(response => {
            if (response.error) {
            } else {
                console.log(response.data)
                this.valorCambio = response.data.montoTipoCambio;
            }
        },
            err => {
                console.error(err);
            },
            () => {
                console.log('Finished!');
            });
    }


    RealizarModificacion() {
        var objRequest = new RequestTipoCambio();

        objRequest.ISO = this.monedaModificar;
        objRequest.PerUSSD = this.montoModificar;

        this._tablaConversionService.Modificar(objRequest).subscribe(response => {
            if (response.error) {
            } else {
                this.texto_servicio = "Los Datos Fueron Actualizados"

                this.valorCambio = response.data.montoTipoCambio;
            }
        },
            err => {
                console.error(err);
            },
            () => {
                console.log('Finished!');
            });
    }

    NuevoTipoCambio() {
        this.stateCambioMoneda = false;
        this.stateActualizarCambioMoneda = true

        this.imagenMonedaDestino = "";
        this.selectedMonedaDestino = "";
    }
    Retroceder() {
        this.stateCambioMoneda = true;
        this.stateActualizarCambioMoneda = false
        this.imagenMonedaOrigen = "";
        this.imagenMonedaDestino = "";
        this.selectedMonedaOrigen = "";
        this.selectedMonedaDestino = "";
    }
    ChangeMonedaOrigen(event: any) {
        this.valorCambio = "";
        this.monedaOrigen = this.selectedMonedaOrigen.iso;
        var moneda = this.selectedMonedaOrigen.isoCorto.toLowerCase();
        this.imagenMonedaOrigen = `https://flagcdn.com/48x36/${moneda}.png`;
    }


    ChangeMonedaDestino(event: any) {
        this.valorCambio = "";
        this.monedaDestino = this.selectedMonedaDestino.iso;
        var moneda = this.selectedMonedaDestino.isoCorto.toLowerCase();
        this.imagenMonedaDestino = `https://flagcdn.com/48x36/${moneda}.png`;
    }

    ChangeModificarMonedaDestino(event: any) {
        this.valorCambio = "";
        this.monedaModificar = this.selectedMonedaDestino.iso;
        var moneda = this.selectedMonedaDestino.isoCorto.toLowerCase();
        this.imagenMonedaDestino = `https://flagcdn.com/48x36/${moneda}.png`;


    }

}
