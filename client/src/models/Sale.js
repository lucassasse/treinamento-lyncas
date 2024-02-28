export class Sale {
    constructor({id, fullName, saleTotalItems, billingDate, saleDate, saleTotalValue}) {
        this.id = id;
        this.fullName = fullName;
        this.saleTotalItems = saleTotalItems;
        this.billingDate = billingDate;
        this.saleDate = saleDate;
        this.saleTotalValue = saleTotalValue;
    }
}