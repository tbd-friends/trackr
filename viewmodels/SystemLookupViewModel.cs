using System;
using System.Data.Common;

namespace viewmodels
{
    public class SystemLookupViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description => $"{Name} ({Manufacturer})";
    }
}