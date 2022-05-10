// Pues tambien le muevo al typescript.
function toggleTheme(theme: string): void {
    var refStart: string = "https://cdn.jsdelivr.net/npm/bootswatch@5.1.3/dist/";
    var refEnd: string = "/bootstrap.min.css";
    var styleSheet = <HTMLLinkElement>document.getElementById('themeSheet');
    styleSheet.href = refStart + theme + refEnd;
    console.log(styleSheet.href);
}