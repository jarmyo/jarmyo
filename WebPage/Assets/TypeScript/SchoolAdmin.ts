﻿function CreateNewClient(): void {
    const data = new FormData();
    const clientName: HTMLInputElement = <HTMLInputElement>document.getElementById('clientName');
    const clientPhone: HTMLInputElement = <HTMLInputElement>document.getElementById('clientPhone');

    const newClient: Client = {
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

                const clientTable: HTMLTableElement = <HTMLTableElement>document.getElementById('clientTable');
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
                const row: HTMLTableRowElement = <HTMLTableRowElement>document.getElementById('client-' + id);
                const clientTable: HTMLTableElement = <HTMLTableElement>document.getElementById('clientTable');
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
        const randomUuid: number = Math.random() * 16 | 0, randomVar = c == 'x' ? randomUuid : (randomUuid & 0x3 | 0x8);
        return randomVar.toString(16);
    });
}

function CreateTableRow(client: Client): HTMLTableRowElement {
    const row: HTMLTableRowElement = <HTMLTableRowElement>document.createElement('tr');
    row.id = "client-" + client.Id;
    const cell1: HTMLTableCellElement = row.insertCell(0);
    const cell2: HTMLTableCellElement = row.insertCell(1);
    const cell3: HTMLTableCellElement = row.insertCell(2);
    const cell4: HTMLTableCellElement = row.insertCell(3);
    const cell5: HTMLTableCellElement = row.insertCell(4);
    cell1.innerHTML = SanitizeHtmlString(client.Id);
    cell2.innerHTML = SanitizeHtmlString(client.Name);
    cell3.innerHTML = SanitizeHtmlString(client.Phone);
    cell4.innerHTML = '<button type="button" onclick="EditClient(\'' + client.Id + '\')" class="btn btn-sm btn-info">Edit</button>';
    cell5.innerHTML = '<button type="button" onclick="DeleteClient(\'' + client.Id + '\)" class="btn btn-sm btn-danger">Delete</button>';
    return row;
}

function SanitizeHtmlString(data: string): string {
    return data.replace(/[^a-zA-Z0-9]/g, '');
}