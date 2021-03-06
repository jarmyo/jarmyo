function demoFunction() {
    console.clear();
    console.log("OK, there are some things i can do in javascript");
    //TODO: Create an example that uses all concepts.
    createModalGUI();
    //inherance.    
    //DOM
    var myModal = new bootstrap.Modal(document.getElementById('javascriptModal'));
    myModal.show();
    var c1 = ClosureFunction(8);
    var c2 = ClosureFunction(4);
    for (var x = 0; x < 20; x++) {
        c1.Increment();
        c2.Increment();
    }
    //console.log(c1.ShowValue());
    //console.log(c2.ShowValue());   
}
function createModalGUI() {
    var container = document.getElementById('containerGrid');
    container.innerText = "";
    var paragraphNode = document.createElement('p');
    paragraphNode.innerText = "This paragraph is dymaic created";
    container.appendChild(paragraphNode);
    container.appendChild(document.createElement('hr'));
    var inputGroup = document.createElement('div');
    inputGroup.classList.add('input-group');
    var inputText = document.createElement('input');
    inputText.id = "sendValue";
    inputText.type = "number";
    inputText.placeholder = "a number between 1 and 100";
    inputText.min = "1";
    inputText.max = "32767";
    inputText.className = "form-control";
    inputGroup.appendChild(inputText);
    var inputButton = document.createElement('input');
    inputButton.type = "button";
    inputButton.value = "Fetch API";
    inputButton.addEventListener('click', () => { SendDataToAPI(); });
    inputButton.classList.add("btn");
    inputButton.classList.add("btn-primary");
    inputGroup.appendChild(inputButton);
    container.appendChild(inputGroup);
}
function SendDataToAPI() {
    //fetch data from API, obtain from FORM
    var valueField = document.getElementById('sendValue');
    var container = document.getElementById('secondcontainerGrid');
    var outputString = "";
    var valueData = valueField.value;
    fetch('/Work/WebApiExample/' + valueData).then(function (result) { return result.json(); }).then(function (result) {
        if (result.ok != true) {
            outputString = "Error: ";
        }
        outputString += result.name;
        console.log(outputString);
        container.innerText = outputString;
    });
}
function ClosureFunction(step) {
    var counter = 0;
    return {
        Increment: function () {
            counter = counter + step;
        },
        ShowValue: function () {
            return counter;
        }
    };
}
//# sourceMappingURL=WorkFrontEnd.js.map