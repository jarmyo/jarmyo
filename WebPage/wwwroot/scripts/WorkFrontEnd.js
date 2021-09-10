function demoFunction() {
    console.clear();
    console.log("OK, there are some things i can do in javascript");
    //TODO: Create an example that uses all concepts.
    //inherance.
    //Representation of the objects.
    //DOM
    //Create a modal in bootstrap.
    // Modify elementes in the model
    //Promises.
    //Fecth an api; local API and public API
    //Closures.
    //To transform the elements fetched
    var c1 = ClosureFunction(2);
    var c2 = ClosureFunction(4);
    for (var x = 0; x < 20; x++) {
        c1.Increment();
        c2.Increment();
    }
    console.log(c1.ShowValue());
    console.log(c2.ShowValue());
    alert("All the magic is in te console!");
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