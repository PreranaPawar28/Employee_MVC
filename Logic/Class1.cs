using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CRUD_Operation.Models;
using System.Data;

namespace CRUD_Operation.Logic
{
    public class Class1
    {

        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PreranaPawar"].ConnectionString);

        public List<EmpModel> GetAllData()
        {
            List<EmpModel> EmpList = new List<EmpModel>();
            string qry = "select * from EmployeeData";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            SDA.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                EmpModel emp = new EmpModel()
                {
                    EmpId = Convert.ToInt32(dr["ID"]),
                    EmpName = dr["EmpName"].ToString(),
                    EmpSalary = dr["EmpSalary"].ToString(),
                    EmpDesignation = dr["Designation"].ToString(),
                    EmpCity = dr["City"].ToString()
                };

                EmpList.Add(emp);
            }
            return EmpList;
        }

        public string AddEmp(EmpModel emp)
        {
            string msg;
            string qry = "insert into EmployeeData(EmpName,EmpSalary,Designation,City) values(@Name,@Salary,@EmpDesignation,@Empcity)";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@Name", emp.EmpName);
            cmd.Parameters.AddWithValue("@Salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@EmpDesignation", emp.EmpDesignation);
            cmd.Parameters.AddWithValue("@Empcity", emp.EmpCity);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
            {
                msg = "Data Inserted Succesfully";
            }
            else
            {
                msg = "Insert fail";
            }
            return msg;
        }
    }
}