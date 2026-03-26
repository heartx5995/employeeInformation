using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace employeeInformation
{
    public class empDbData : IDataService
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True;TrustServerCertificate=True;";
        private SqlConnection sqlConnection;

        public empDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(Employee emp)
        {
            string query = @"
                INSERT INTO Employees (ID, FirstName, LastName, MiddleName, Suffix, Gender, Birthdate, Phone, Email, Address, Position, Salary)
                VALUES (@id, @firstName, @lastName, @middleName, @suffix, @gender, @birthdate, @phone, @email, @address, @position, @salary)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@id", emp.ID);
            cmd.Parameters.AddWithValue("@firstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@lastName", emp.LastName);
            cmd.Parameters.AddWithValue("@middleName", emp.MiddleName);
            cmd.Parameters.AddWithValue("@suffix", emp.Suffix);
            cmd.Parameters.AddWithValue("@gender", emp.Gender.ToString());
            cmd.Parameters.AddWithValue("@birthdate", emp.Birthdate);
            cmd.Parameters.AddWithValue("@phone", emp.Phone);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@address", emp.Address);
            cmd.Parameters.AddWithValue("@position", emp.Position);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            string query = "SELECT ID, FirstName, LastName, MiddleName, Suffix, Gender, Birthdate, Phone, Email, Address, Position, Salary FROM Employees";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.ID = reader["ID"].ToString();
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.MiddleName = reader["MiddleName"].ToString();
                emp.Suffix = reader["Suffix"].ToString();
                emp.Gender = char.Parse(reader["Gender"].ToString());
                emp.Birthdate = reader["Birthdate"].ToString();
                emp.Phone = long.Parse(reader["Phone"].ToString());
                emp.Email = reader["Email"].ToString();
                emp.Address = reader["Address"].ToString();
                emp.Position = reader["Position"].ToString();
                emp.Salary = float.Parse(reader["Salary"].ToString());
                employees.Add(emp);
            }

            sqlConnection.Close();
            return employees;
        }

        public Employee GetById(string id)
        {
            Employee emp = null;
            string query = "SELECT ID, FirstName, LastName, MiddleName, Suffix, Gender, Birthdate, Phone, Email, Address, Position, Salary FROM Employees WHERE ID = @id";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                emp = new Employee();
                emp.ID = reader["ID"].ToString();
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.MiddleName = reader["MiddleName"].ToString();
                emp.Suffix = reader["Suffix"].ToString();
                emp.Gender = char.Parse(reader["Gender"].ToString());
                emp.Birthdate = reader["Birthdate"].ToString();
                emp.Phone = long.Parse(reader["Phone"].ToString());
                emp.Email = reader["Email"].ToString();
                emp.Address = reader["Address"].ToString();
                emp.Position = reader["Position"].ToString();
                emp.Salary = float.Parse(reader["Salary"].ToString());
            }

            sqlConnection.Close();
            return emp;
        }

        public void Update(Employee emp)
        {
            string query = @"
                UPDATE Employees 
                SET FirstName = @firstName,
                    LastName = @lastName,
                    MiddleName = @middleName,
                    Suffix = @suffix,
                    Gender = @gender,
                    Birthdate = @birthdate,
                    Phone = @phone,
                    Email = @email,
                    Address = @address,
                    Position = @position,
                    Salary = @salary
                WHERE ID = @id";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@id", emp.ID);
            cmd.Parameters.AddWithValue("@firstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@lastName", emp.LastName);
            cmd.Parameters.AddWithValue("@middleName", emp.MiddleName);
            cmd.Parameters.AddWithValue("@suffix", emp.Suffix);
            cmd.Parameters.AddWithValue("@gender", emp.Gender.ToString());
            cmd.Parameters.AddWithValue("@birthdate", emp.Birthdate);
            cmd.Parameters.AddWithValue("@phone", emp.Phone);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@address", emp.Address);
            cmd.Parameters.AddWithValue("@position", emp.Position);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(string id)
        {
            string query = "DELETE FROM Employees WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public bool TestConnection()
        {
            try
            {
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}