﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Moduls.Students
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Address { get; set; }
    }
}
