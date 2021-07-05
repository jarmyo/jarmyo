import { ObjetoResultado } from "./WorkCommon";
function AgregarVisitante(): void {

    var campoNombre = <HTMLInputElement>document.getElementById('CampoNombre');
    var nombre = campoNombre.value;

    fetch('/Work/SQLiteAgregarVisitante/' + nombre).then(
        function (result) { return result.json() }
    ).then(
        function (result: ObjetoResultado) {
            if (result.ok == true) {
                var lista = document.getElementById('ListaVisitantes');
                var tr = document.createElement('tr');
                tr.appendChild(Columna(result.guid))
                tr.appendChild(Columna(result.attributes['Fecha']));
                tr.appendChild(Columna(result.name));
                lista.appendChild(tr);
            }
            else {
                console.log(result.name)
            }
        }
    );
}

function Columna(texto: string): HTMLTableDataCellElement {
    var cell = document.createElement('td');
    cell.innerText = texto;
    return cell;
}