using ADOCRUDApplication.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace ADOCRUDApplication
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        //Get All Employees API 
        public List<Employees> GetAllEmployess()
        {
            //making list of empployess
            List<Employees> employees = new List<Employees>();
            //if am writing Using attribute it means i dont have to close this or else i have to open it and close it 
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                //now telling that i am using a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //passing it in the while loop so it can read all the data that we have 
                while (reader.Read())
                {
                    //model that we have made creating a object for it 
                    Employees employee = new Employees();

                    employee.Id = Convert.ToInt32(reader["Id"]);
                    employee.Name = reader["Name"].ToString() ?? "";
                    employee.age = Convert.ToInt32(reader["age"]);
                    employee.designation = reader["designation"].ToString() ?? "";
                    employee.gender = reader["gender"].ToString() ?? "";
                    employee.city = reader["city"].ToString() ?? "";
                    //now adding all the data into the above list we have made 
                    employees.Add(employee);
                }
            }
            return employees;
        }
        public Employees GetEmployeeByID(int? id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Employees where id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //model that we have made creating a object for it 
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.age = Convert.ToInt32(reader["age"]);
                    emp.designation = reader["designation"].ToString() ?? "";
                    emp.gender = reader["gender"].ToString() ?? "";
                    emp.city = reader["city"].ToString() ?? "";
                   
                }

            }
            return emp;

        }
        public void AddEmployee(Employees employees)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", employees.Name);
                cmd.Parameters.AddWithValue("@gender", employees.gender);
                cmd.Parameters.AddWithValue("@age", employees.age);
                cmd.Parameters.AddWithValue("@designation", employees.designation);
                cmd.Parameters.AddWithValue("@city", employees.city);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEmployee(Employees employees)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", employees.Id);
                cmd.Parameters.AddWithValue("@name", employees.Name);
                cmd.Parameters.AddWithValue("@gender", employees.gender);
                cmd.Parameters.AddWithValue("@age", employees.age);
                cmd.Parameters.AddWithValue("@designation", employees.designation);
                cmd.Parameters.AddWithValue("@city", employees.city);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open() ;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
