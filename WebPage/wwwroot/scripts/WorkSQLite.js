function AgregarVisitante() {
    var nameField = document.getElementById('CampoNombre');
    var nameData = nameField.value;
    fetch('/Work/SQLiteAgregarVisitante/' + nameData).then(function (result) { return result.json(); }).then(function (result) {
        if (result.ok == true) {
            var visitorsTable = document.getElementById('ListaVisitantes');
            var newRow = document.createElement('tr');
            newRow.appendChild(Columna(result.guid));
            newRow.appendChild(Columna(result.attributes['Fecha']));
            newRow.appendChild(Columna(result.name));
            visitorsTable.appendChild(newRow);
        }
        else {
            console.log(result.name);
        }
    });
}
function Columna(texto) {
    var cell = document.createElement('td');
    cell.innerText = texto;
    return cell;
}
//# sourceMappingURL=WorkSQLite.js.map