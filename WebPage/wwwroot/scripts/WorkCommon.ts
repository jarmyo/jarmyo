interface ObjectResult {
    ok: boolean;
    guid: string;
    id: number;
    name: string;
    attributes: { [key: string]: string; };
}
