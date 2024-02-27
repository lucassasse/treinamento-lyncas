export class Sale {
    constructor(id, customerId, customerName, billingDate, item) {
        this.id = id;
        this.customerId = customerId;
        this.customerName = customerName;
        this.billingDate = billingDate;
        this.item = item
    }
}