namespace owasp_topten_api.Model
{
    public class AccountInfo
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public string Owner { get; set; }
    }
}