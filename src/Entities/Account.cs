namespace owasp_topten_api.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public decimal Saldo { get; set; }

        public User Usuario { get; set; }
    }
}