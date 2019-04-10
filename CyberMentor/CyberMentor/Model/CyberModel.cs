using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMentor.Model
{
    public class CyberModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string desc { get; set; }
        public string section_id { get; set; }
        public string more { get; set; }
        public string key { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public YoutubeItem Youtube { get; set; }
    }

}
