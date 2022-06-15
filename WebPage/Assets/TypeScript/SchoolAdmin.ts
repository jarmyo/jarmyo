function CreateNewClient(): void {
    let data = new FormData();
    let clientName: HTMLInputElement = <HTMLInputElement>document.getElementById('clientName');
    let clientPhone: HTMLInputElement = <HTMLInputElement>document.getElementById('clientPhone');

    let newClient: Client = {
        Id : uuid(),
        IdBusiness : (<HTMLInputElement>document.getElementById('IdBusiness')).value,
        Name : clientName.value,
        Phone : clientPhone.value
    }

    data.append("Id", newClient.Id);
    data.append("Name", newClient.Name);
    data.append("Phone", newClient.Phone);
    data.append("IdBusiness", newClient.IdBusiness);

    fetch('/api/v2/Schools/Clients/', { method: "POST", body: data })
        .then(
            function (result) { return result.json() }
        ).then(function (result) {
            if (result.result == "ok") {

                let clientTable: HTMLTableElement = <HTMLTableElement>document.getElementById('clientTable');
                clientTable.appendChild(CreateTableRow(newClient));
                clientName.value = "";
                clientPhone.value = "";
            }
            console.log(result);
        }
        );
}

function DeleteClient(id: string): void {
    fetch('/api/v2/Schools/Clients/' + id, { method: "DELETE" })
        .then(
            function (result) { return result.json() }
        ).then(function (result) {
            if (result.result == "ok") {
                let row: HTMLTableRowElement = <HTMLTableRowElement>document.getElementById('client-' + id);
                let clientTable: HTMLTableElement = <HTMLTableElement>document.getElementById('clientTable');
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
        let randomUuid: number = Math.random() * 16 | 0, randomVar = c == 'x' ? randomUuid : (randomUuid & 0x3 | 0x8);
        return randomVar.toString(16);
    });
}

function CreateTableRow(client: Client): HTMLTableRowElement {
    let row: HTMLTableRowElement = <HTMLTableRowElement>document.createElement('tr');
    row.id = "client-" + client.Id;
    let cell1: HTMLTableCellElement = row.insertCell(0);
    let cell2: HTMLTableCellElement = row.insertCell(1);
    let cell3: HTMLTableCellElement = row.insertCell(2);
    let cell4: HTMLTableCellElement = row.insertCell(3);
    let cell5: HTMLTableCellElement = row.insertCell(4);
    cell1.innerHTML = client.Id;
    cell2.innerHTML = client.Name;
    cell3.innerHTML = client.Phone;
    cell4.innerHTML = '<button type="button" onclick="EditClient(\'' + client.Id + '\')" class="btn btn-sm btn-info">Edit</button>';
    cell5.innerHTML = '<button type="button" onclick="DeleteClient(\'' + client.Id + '\)" class="btn btn-sm btn-danger">Delete</button>';
    return row;
}