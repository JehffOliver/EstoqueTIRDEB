using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models.ViewModels
{
    public class CreateItensViewModel
    {
        public IFormFile ExcelFile { get; set; }
    }
}
