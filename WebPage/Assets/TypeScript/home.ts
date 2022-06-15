// Pues tambien le muevo al typescript.
function toggleTheme(theme: string): void {
    let refStart: string = "https://cdn.jsdelivr.net/npm/bootswatch@5.1.3/dist/";
    let refEnd: string = "/bootstrap.min.css";
    let styleSheet = <HTMLLinkElement>document.getElementById('themeSheet');
    styleSheet.href = refStart + theme + refEnd;
    console.log(styleSheet.href);
}