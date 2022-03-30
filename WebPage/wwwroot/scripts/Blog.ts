//Add or remove tags.
function ToggleTag(tag: string): void {
    var inputTag = <HTMLInputElement>document.getElementById('Etiquetas');
    var oldvalue: string = inputTag.value;
    if (oldvalue.includes(tag)) {
        inputTag.value = oldvalue.replace(tag + ';', '').trim();
    }
    else {
        inputTag.value = (oldvalue + tag + ";").trim();
    }
}