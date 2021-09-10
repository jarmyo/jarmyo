function demoFunction() {
    alert("All the magic is in te console!");
    //TODO: Create an example that uses all concepts.
    //Datatypes
    //inherance.
    //DOM
    //Create a modal in bootstrap.
    //Promises.
    //Closures.
    var c1 = ClosureFunction(2);
    var c2 = ClosureFunction(4);
    for (var x = 0; x < 20; x++) {
        c1.Increment();
        c2.Increment();
    }
    console.log(c1.ShowValue());
    console.log(c2.ShowValue());
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