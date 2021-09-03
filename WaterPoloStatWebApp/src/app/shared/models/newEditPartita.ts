import { NewEditSquadra } from "./newEditSquadra";

export class NewEditPartita {
    id!: number;
    campionato!: string;
    data!: Date;
    citta!: string;
    luogo!: string;
    squadraCasa!: NewEditSquadra;
    squadraOspiti!: NewEditSquadra;
}