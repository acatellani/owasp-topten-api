namespace owasp_topten_api.Entities
{

    /*
dotnet aspnet-codegenerator controller -name CardController -api  -async -m owasp_topten_api.Entities.Card -dc DataContext -namespace owasp_topten_api.Controllers  -outDir Controllers
    */
    public class Card
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Code { get; set; }
    }
}