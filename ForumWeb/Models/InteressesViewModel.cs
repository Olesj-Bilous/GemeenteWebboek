using ForumData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class InteressesViewModel
    {
        public List<SelectListItem> Interesses { get; set; }
        public List<ProfielInteresse> ProfielInteresses { get; set; }
    }
}
