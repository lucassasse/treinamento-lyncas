export class Sale {
    constructor({id, fullName, customerId, saleTotalItems, saleDate, billingDate, saleTotalValue, saleItems}) {
        this.id = id;
        this.fullName = fullName;
        this.customerId = customerId;
        this.saleTotalItems = saleTotalItems;
        this.saleDate = saleDate;
        this.billingDate = billingDate;
        this.saleTotalValue = saleTotalValue;
        this.saleItems = saleItems;
    }
}