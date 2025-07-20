using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CRUD_Operation.Models
{
    public class EmpModel
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public string EmpSalary { get; set; }

        public string EmpDesignation { get; set; }

        public string EmpCity { get; set; }
    }
}