using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsDatabaseDiscussion.Models
{
    public class StudentsModel
    {
        public List<TBL_STUDENTS> Students { get; set; }
        public TBL_STUDENTS Student { get; set; }   
    }
}