﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    class OpenWeather
    {
        public string name { get; set; }
        public string id { get; set; }
        public NhieuDo main { get; set; }
        public List<ThoiTiet> weather { get; set; }
    }
}
