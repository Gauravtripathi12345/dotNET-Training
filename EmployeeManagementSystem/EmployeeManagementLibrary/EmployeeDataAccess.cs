using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeManagementLibrary
{
    public class EmployeeDataAccess
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
        }


        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees", connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Department = reader["Department"].ToString()
                        };
                        employees.Add(employee);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }

            return employees;
        }

        public void InsertEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("insert into Employees (Name, Department) VALUES (@Name, @Department)", connection);

            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Department", employee.Department);

            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("select * from Employees where Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                employee = new Employee
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Department = reader["Department"].ToString()
                };
            }

            if (reader != null)
                reader.Close();

            connection.Close();

            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("update Employees SET Name = @Name, Department = @Department where Id = @Id", connection);

            command.Parameters.AddWithValue("@Id", employee.Id);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Department", employee.Department);

            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void DeleteEmployee(int id)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("delete from Employees where Id = @Id", connection);

            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }



    }
}
