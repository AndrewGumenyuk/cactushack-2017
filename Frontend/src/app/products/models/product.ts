export class Product {
    constructor(
        public name: string, public amount: number,
        public proteins: number, public carbonHydrates: number,
        public fat: number, public energy: number
    ) {}
}