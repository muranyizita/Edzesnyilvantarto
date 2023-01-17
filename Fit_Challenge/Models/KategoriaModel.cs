namespace Fit_Challenge.Models
{
    public class KategoriaModel
    {
        public List<string>  KatNevek { get; set; }

        public KategoriaModel()
        {
            KatNevek = new List<string>();
            using (StreamReader sr = new StreamReader("KategoriaConfig.txt"))
            {
                string sor;
                while((sor = sr.ReadLine()) != null)
                {
                    KatNevek.Add(sor);
                }
            }
        }

    }
}
