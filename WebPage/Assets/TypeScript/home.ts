// Pues tambien le muevo al typescript.
function toggleTheme(theme: string): void {
    const refStart: string = "https://cdn.jsdelivr.net/npm/bootswatch@5.1.3/dist/";
    const refEnd: string = "/bootstrap.min.css";
    const styleSheet = <HTMLLinkElement>document.getElementById('themeSheet');
    styleSheet.href = refStart + theme + refEnd;
    console.log(styleSheet.href);
}