function copyme(element: string): void {
    var el = <HTMLTextAreaElement>document.createElement('textarea');
    el.value = document.getElementById(element).innerText;
    document.body.appendChild(el);
    el.select();
    document.execCommand('copy');
    document.body.removeChild(el);
}
function copymeInput(element: string): void {
    var el = <HTMLTextAreaElement>document.createElement('textarea');
    el.value = (<HTMLInputElement>document.getElementById(element)).value;
    document.body.appendChild(el);
    el.select();
    document.execCommand('copy');
    document.body.removeChild(el);
}