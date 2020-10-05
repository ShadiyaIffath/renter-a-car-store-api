﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class VehicleDto
    {
        public int id { get; set; }

        public string model { get; set; }

        public string engine { get; set; }

        public string carCode { get; set; }

        public bool active { get; set; }

        public bool automatic { get; set; }

        public DateTime dayAdded { get; set; }

        public DateTime dayRemoved { get; set; }

        public int typeId { get; set; }

        public VehicleTypeDto type { get; set; }

        public byte[] image { get; set; }
    }
}