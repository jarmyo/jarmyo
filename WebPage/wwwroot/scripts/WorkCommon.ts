export interface ObjetoResultado {
    ok: boolean;
    guid: string;
    id: number;
    name: string;
    attributes: { [key: string]: string; };
}
