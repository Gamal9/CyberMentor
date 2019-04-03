using System;
using System.Collections.Generic;
using System.Text;

namespace CyberMentor.Model
{
    public class Response<I, T>
    {
        public bool success { get; set; }
        public I data { get; set; }
        public T message { get; set; }
    }
}
