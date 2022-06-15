function AgregarVisitante(): void {

    let nameField = <HTMLInputElement>document.getElementById('CampoNombre');
    let nameData = nameField.value;

    fetch('/Work/SQLiteAgregarVisitante/' + nameData).then(
        function (result) { return result.json() }
    ).then(
        function (result: ObjectResult) {
            if (result.ok == true) {
                let visitorsTable = document.getElementById('ListaVisitantes');
                let newRow = document.createElement('tr');
                newRow.appendChild(Columna(result.guid))
                newRow.appendChild(Columna(result.attributes['Fecha']));
                newRow.appendChild(Columna(result.name));
                visitorsTable.appendChild(newRow);
            }
            else {
                console.log(result.name)
            }
        }
    );
}

function Columna(texto: string): HTMLTableDataCellElement {
    let cell = document.createElement('td');
    cell.innerText = texto;
    return cell;
}