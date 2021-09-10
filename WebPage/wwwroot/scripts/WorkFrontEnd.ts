function demoFunction(): void {

    console.clear();
    console.log("OK, there are some things i can do in javascript");
    //TODO: Create an example that uses all concepts.


    //inherance.
    //Representation of the objects.

    //DOM
    //Create a modal in bootstrap.
    // Modify elementes in the model
    var myModal = new bootstrap.Modal(document.getElementById('javascriptModal'))
    myModal.show();
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
}

function ClosureFunction(step: number) {
    var counter = 0;
    return {
        Increment: function (): void {
            counter = counter + step;
        },
        ShowValue: function (): number {
            return counter;
        }
    }
}