using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMentor.Model
{
    public class SettingsModel
    {
        public int id { get; set; }
        public string about { get; set; }
        public string enabout { get; set; }
        public string policy { get; set; }
        public string enpolicy { get; set; }
        public string logo { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
