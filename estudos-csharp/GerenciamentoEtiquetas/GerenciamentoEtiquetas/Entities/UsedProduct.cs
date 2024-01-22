namespace GerenciamentoEtiquetas.Entities {
    internal class UsedProduct : Product {
        DateTime ManufacturedDate { get; set; }

        public UsedProduct() { }

        public UsedProduct(string name, double price, DateTime manufacturedDate) : base(name, price) {
            ManufacturedDate = manufacturedDate;
        }

        public override string PriceTag() {
            return Name + " (used) R$" + Price.ToString("F2") + " (Manufactured date: " + ManufacturedDate.ToString("dd/MM/yyyy") + ")";
        }
    }
}
