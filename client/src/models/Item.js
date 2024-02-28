export class Item {
    constructor({id, description, quantity, saleDate, unityValue, totalValueItem, saleTotalItems}) {
        this.id = id;
        this.description = description;
        this.quantity = quantity;
        this.saleDate = saleDate;
        this.unityValue = unityValue;
        this.totalValueItem = totalValueItem;
        this.saleTotalItems = saleTotalItems;
    }
}