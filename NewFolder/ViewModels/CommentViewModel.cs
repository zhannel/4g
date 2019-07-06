﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neupusti.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
