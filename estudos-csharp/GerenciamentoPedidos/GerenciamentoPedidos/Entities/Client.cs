namespace GerenciamentoPedidos.Entities {
    internal class Client {
        public string Name { get; set; }
        public string Email { get; set;}
        public string BirthDate { get; set;}

        public Client() { }

        public Client(string name, string email, string birthDate) {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override string ToString() {
            return Name + ", ( " + BirthDate.ToString() + ") - " + Email;
        }
    }
}
