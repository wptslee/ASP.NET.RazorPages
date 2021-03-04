using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Portfolios
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioServiceJsonFile _service;

        // 생성자의 매개 변수로 서비스 (리포지토리) 클래스 주입
        public IndexModel(PortfolioServiceJsonFile service)
        {
            this._service = service;
        }

        public IEnumerable<Portfolio> Portfolios { get; private set; }

        public void OnGet()
        {
            Portfolios = _service.GetPortfolios();
        }
    }
}
