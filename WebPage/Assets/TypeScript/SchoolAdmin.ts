function CreateNewClient(): void {
    var data = new FormData();


    var clientName: HTMLInputElement = <HTMLInputElement>document.getElementById('clientName');
    var clientPhone: HTMLInputElement = <HTMLInputElement>document.getElementById('clientPhone');

    var newClient: Client = {
        Id : uuid(),
        IdBusiness : (<HTMLInputElement>document.getElementById('IdBusiness')).value,
        Name : clientName.value,
        Phone : clientPhone.value
    }

    data.append("Id", newClient.Id);
    data.append("Name", newClient.Name);
    data.append("Phone", newClient.Phone);
    data.append("IdBusiness", newClient.IdBusiness);

    fetch('/School/Clients/', { method: "POST", body: data })
        .then(
            function (result) { return result.json() }
        ).then(function (result) {
            if (result.result == "ok") {

                var clientTable: HTMLTableElement = <HTMLTableElement>document.getElementById('clientTable');
                clientTable.appendChild(CreateTableRow(newClient));
                clientName.value = "";
                clientPhone.value = "";
            }
            console.log(result);
        }
        );
}

function CreateTableRow(client: Client): HTMLTableRowElement {
    var row: HTMLTableRowElement = <HTMLTableRowElement>document.createElement('tr');
    row.id = "client-" + client.Id;
    var cell1: HTMLTableCellElement = row.insertCell(0);
    var cell2: HTMLTableCellElement = row.insertCell(1);
    var cell3: HTMLTableCellElement = row.insertCell(2);
    var cell4: HTMLTableCellElement = row.insertCell(3);
    var cell5: HTMLTableCellElement = row.insertCell(4);
    cell1.innerHTML = client.Id;
    cell2.innerHTML = client.Name;
    cell3.innerHTML = client.Phone;
    cell4.innerHTML = '<button type="button" onclick="EditClient(\'' + client.Id + '\')" class="btn btn-sm btn-info">Edit</button>';
    cell5.innerHTML = '<button type="button" onclick="DeleteClient(\'' + client.Id + '\)" class="btn btn-sm btn-danger">Delete</button>';
    return row;
}


function DeleteClient(id: string): void {
    fetch('/School/Clients/' + id, { method: "DELETE" })
        .then(
            function (result) { return result.json() }
        ).then(function (result) {
            if (result.result == "ok") {
                var row: HTMLTableRowElement = <HTMLTableRowElement>document.getElementById('client-' + id);
                var clientTable: HTMLTableElement = <HTMLTableElement>document.getElementById('clientTable');
                clientTable.removeChild(row);
            }
        }
        );
}

function EditClient(id: string): void {
    //Open dialogBox with fields
    //With PUT to update data.
}

function uuid(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c): string {
        var randomUuid: number = Math.random() * 16 | 0, randomVar = c == 'x' ? randomUuid : (randomUuid & 0x3 | 0x8);
        return randomVar.toString(16);
    });
}