using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMentor.Model
{
    public class CatModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string en_name { get; set; }
        public string ar_name { get; set; }
        public string logo { get; set; }
        public List<SubCatModel> sub_categories { get; set; }
        public string created_at { get; set; }
    }

    public class SubCatModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? section_id { get; set; }
        public string logo { get; set; }
        public string more { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
