namespace GerenciamentoPedidos.Entities.Enums {
    enum OrderStatus : int {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivery = 3,
    }
}
