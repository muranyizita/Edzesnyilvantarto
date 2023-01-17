namespace Fit_Challenge.Models
{
    public class SportFajtaModel
    {
        public int Id { get; set; }
        public string Fajta { get; set; }
        public string Leiras { get; set; }

        public SportFajtaModel(int id, string fajta, string leiras)
        {
            Id = id;
            Fajta = fajta;
            Leiras = leiras;
        }

        /*
        static List<SportFajtaModel> sportFajtaModels = new List<SportFajtaModel>()
        {
            new SportFajtaModel(""),
            new SportFajtaModel(""),
            new SportFajtaModel(""),
            new SportFajtaModel(""),
            new SportFajtaModel(""),
            new SportFajtaModel(""),
        }
        */

    }
}
