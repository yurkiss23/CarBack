﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBack.ViewModels
{
    public class CarVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class CarCreateVM
    {
        public string Name { get; set; }
        public int MakerId { get; set; }
        public string Image { get; set; }
    }
}
