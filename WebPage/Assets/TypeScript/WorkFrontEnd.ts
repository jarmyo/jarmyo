function demoFunction(): void {

    console.clear();
    console.log("OK, there are some things i can do in javascript");
    //TODO: Create an example that uses all concepts.
    createModalGUI();
    //inherance.
    //DOM
    const myModal = new bootstrap.Modal(document.getElementById('javascriptModal'))
    myModal.show();

    const c1 = ClosureFunction(8);
    const c2 = ClosureFunction(4);

    for (let x = 0; x < 20; x++) {
        c1.Increment();
        c2.Increment();
    }
    //console.log(c1.ShowValue());
    //console.log(c2.ShowValue());
}

function createModalGUI(): void {

    const container = <HTMLDivElement>document.getElementById('containerGrid');
    container.innerText = "";

    const paragraphNode = document.createElement('p');
    paragraphNode.innerText = "This paragraph is dymaic created";
    container.appendChild(paragraphNode);

    container.appendChild(document.createElement('hr'));

    const inputGroup = document.createElement('div');
    inputGroup.classList.add('input-group');

    const inputText = document.createElement('input');
    inputText.id = "sendValue";
    inputText.type = "number";
    inputText.placeholder = "a number between 1 and 100";
    inputText.min = "1";
    inputText.max = "32767";
    inputText.className = "form-control";
    inputGroup.appendChild(inputText);

    const inputButton = document.createElement('input');
    inputButton.type = "button";
    inputButton.value = "Fetch API";
    inputButton.addEventListener('click', () => { SendDataToAPI() });
    inputButton.classList.add("btn");
    inputButton.classList.add("btn-primary");
    inputGroup.appendChild(inputButton);

    container.appendChild(inputGroup);
}

function SendDataToAPI(): void {
    //fetch data from API, obtain from FORM
    const valueField = <HTMLInputElement>document.getElementById('sendValue');
    const container = <HTMLDivElement>document.getElementById('secondcontainerGrid');
    let outputString: string = "";
    const valueData = valueField.value;
    fetch('/Work/WebApiExample/' + valueData).then(
        function (result) { return result.json() }
    ).then(
        function (result: ObjectResult) {
            if (result.ok != true) {
                outputString = "Error: ";
            }
            outputString += result.name;
            console.log(outputString);
            container.innerText = outputString;
        }
    );

}

function ClosureFunction(step: number) {
    let counter = 0;
    return {
        Increment: function (): void {
            counter = counter + step;
        },
        ShowValue: function (): number {
            return counter;
        }
    }
}