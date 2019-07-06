using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neupusti.Data.FileManager;
using Neupusti.Data.Repository;
using Neupusti.Models;
using Neupusti.ViewModels;

namespace Neupusti.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index() => View();

        [Authorize(Policy = "UserAccess")]
        public IActionResult UserPage() => View();

        [Authorize(Policy = "PremiumUserAccess")]
        public IActionResult ManagerPage() => View();

        [Authorize(Policy = "AdminAccess")]
        public IActionResult AdminPage() => View();
    }
}