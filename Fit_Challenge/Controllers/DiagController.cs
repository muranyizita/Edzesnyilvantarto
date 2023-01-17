using Fit_Challenge.Adatdir;
using Fit_Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fit_Challenge.Controllers
{
    public class DiagController : Controller
    {
        public IActionResult Index()
        {
            KategoriaModel km = new KategoriaModel();
            return View(km);
        }

        public IActionResult Kirajzol()
        {
            string keresettkat = Request.Form["kategoriak"];

            AdatCTX ak = new AdatCTX();
            Dictionary<string, int> elvegzettek = new Dictionary<string, int>();

            foreach (Edze edzes in ak.Edzes)
            {
                if(edzes.SportAg.TrimEnd() == keresettkat)
                {
                    if (elvegzettek.ContainsKey(edzes.SportFajta))
                    {
                        elvegzettek[edzes.SportFajta] += (int)edzes.EdzesPerc;
                    }
                    else
                    {
                        elvegzettek.Add(edzes.SportFajta, (int)edzes.EdzesPerc);
                    }

                }
            }
            
            return View(elvegzettek);
        }

        public IActionResult Vonal()
        {
            AdatCTX ak = new AdatCTX();
            Dictionary<string, int> elvegzettek = new Dictionary<string, int>();

            foreach (Edze edzes in ak.Edzes)
            {
                    if (elvegzettek.ContainsKey(edzes.SportFajta))
                    {
                        elvegzettek[edzes.SportFajta] += (int)edzes.EdzesPerc;
                    }
                    else
                    {
                        elvegzettek.Add(edzes.SportFajta, (int)edzes.EdzesPerc);
                    }
            }

            return View(elvegzettek);
        }

    }
}
