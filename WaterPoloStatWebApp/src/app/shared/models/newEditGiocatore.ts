import { NewEditSquadra } from "./newEditSquadra";

export class NewEditGiocatore{
    id!: number;
    nome!: string;
    data!: Date;
    numero!: number;
    giocatoreId!: number;    
    ruoloId!: number;  
    squadraCasa!:NewEditSquadra;
    squadraOspiti!:NewEditSquadra;
}