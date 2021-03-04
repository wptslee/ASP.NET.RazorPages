using Microsoft.AspNetCore.Hosting;
using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPages.Services
{
    public class PortfolioServiceJsonFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioServiceJsonFile(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get
            {
                //return _webHostEnvironment.WebRootPath + "\\Portfolios" + "\\portfolios.json";
                return Path.Combine(_webHostEnvironment.WebRootPath, "Portfolios", "portfolios.json");
            }
        }


        public IEnumerable<Portfolio> GetPortfolios()
        {
            //var jsonFileName = @"C:\ProjectWorks\ASP.NET.RazorPages\RazorPages\wwwroot\Portfolios\portfolios.json";
            using (var jsonFileReader = File.OpenText(this.JsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var portfolios = JsonSerializer.Deserialize<Portfolio[]>(jsonFileReader.ReadToEnd(), options);
                return portfolios;
            }
        }
    }
}
