namespace owasp_topten_api.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }

        public User User { get; set; }
    }
}