using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMentor.Model
{
    public class CyberReview
    {
        public int id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public int user_id { get; set; }
        public string more { get; set; }
        public int post_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
