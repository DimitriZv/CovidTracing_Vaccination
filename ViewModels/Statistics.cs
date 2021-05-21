using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project334.ViewModels
{
    public class Statistics
    {
        public int DangCaseCount { get; set; }
        public int DangCaseCountNSW { get; set; }
        public int DangCaseCountACT { get; set; }
        public int DangCaseCountWA { get; set; }
        public int DangCaseCountQLD { get; set; }
        public int DangCaseCountSA { get; set; }
        public int DangCaseCountVIC { get; set; }
    }
}
