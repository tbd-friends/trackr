using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
