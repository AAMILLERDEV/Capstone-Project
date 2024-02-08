import { Zones } from "./Zones";

export interface ZoneCategories {
    id: number;
    categoryName: string;
    target: number;
    zones?: Zones[];
}