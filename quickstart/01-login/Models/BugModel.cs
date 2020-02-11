using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SampleMvcAP.Models
{
    public class BugModel
    {
        [Key]
        public int BugID { get; set; }
        [Display(Name = "Bug Title: ")]
        [StringLength(25, ErrorMessage = "Please provide a Bug Title within 50 characters.")]
        public string BugTitle { get; set; }
        [Display(Name = "Bug Description: ")]
        public string BugDescription { get; set; }
        [Display(Name = "Submission By: ")]
        [StringLength(40, ErrorMessage = "Please provide a name within 50 characters.")]
        public string SubmittedBy { get; set; }

    }
}