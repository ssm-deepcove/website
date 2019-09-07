﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deepcove_Trust_Website.Models.ArgumentModels
{
    public class CropArguments
    {
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
    }
}