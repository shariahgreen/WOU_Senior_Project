using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;
using Microsoft.AspNet.Identity;

namespace Peak_Performance.Models.ViewModels
{
    public class WorkoutsViewModel
    {
        public DateTime date { get; set; }

        public string team {get; set;}
        
        public ComplexesViewModel complexes { get; set; }
    }

    public class ComplexesViewModel
    {
        public List<ComplexViewModel> complex { get; set; }
    }

    public class ComplexViewModel
    { 
        public List<ExerciseViewModel> exercise { get; set; }
    
    }

    public class ExerciseViewModel
    {
        string name { get; set; }
        int reps { get; set; }
        int sets { get; set; }
        double weight { get; set; }
        TimeSpan time { get; set; }
        double speed { get; set; }
        double distance { get; set; }
    }
}