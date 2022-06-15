//Add or remove tags.
function ToggleTag(tag: string): void {
    const inputTag = <HTMLInputElement>document.getElementById('Etiquetas');
    const oldvalue: string = inputTag.value;
    if (oldvalue.includes(tag)) {
        inputTag.value = oldvalue.replace(tag + ';', '').trim();
    }
    else {
        inputTag.value = (oldvalue + tag + ";").trim();
    }
}

function removeTag(tag: string): void {
    fetch('/Blog/DeleteTag/' + tag).then(
        function (result) {
            console.log("1" + result);
            return result.json();
        }
    ).then(function (result) {
        if (result == "ok") {
            const row = <HTMLTableRowElement>document.getElementById('tagrow-' + tag);
            const table = <HTMLTableElement>document.getElementById('TagTable');
            table.removeChild(row);
        }
    });
}
function renameTag(tag: string): void {

}