interface ObjectResult {
    ok: boolean;
    guid: string;
    id: number;
    name: string;
    attributes: { [key: string]: string; };
}
type Client = {
    Id: string;
    Name: string;  
    Phone: string;
    IdBusiness: string;    
}