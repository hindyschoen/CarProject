using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CarProject.Models
{
    public enum CarType
    {
        Sedan,
        Supercar,
        SUV
    }
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool LeatherSeats { get; set; }
        public CarType CarType { get; set; }


    }
    public class CarManager
    {
        private readonly string _connectionString;
        public CarManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Carcheckboxtable(Make, Model, Year, Price, CarType, LeatherSeats) Values(@make, @model, @year, @price, @cartype, @leatherseats)";
                command.Parameters.AddWithValue("@make", car.Make);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@year", car.Year);
                command.Parameters.AddWithValue("@price", car.Price);
                command.Parameters.AddWithValue("@cartype", car.CarType);
                command.Parameters.AddWithValue("@leatherseats", car.LeatherSeats);
                connection.Open();
                command.ExecuteNonQuery();

            }

        }

        public List<Car> GetCarsSorted(bool sort)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = " SELECT * FROM Carcheckboxtable ORDER BY YEAR ";
                if (sort)
                {
                    command.CommandText += "ASC ";
                }
                else
                {
                    command.CommandText += "DESC ";
                }
                connection.Open();
                List<Car> cars = new();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Car car = new();


                    car.Make = (string)reader["Make"];
                    car.Model = (string)reader["Model"];
                    car.Year = (int)reader["Year"];
                    car.Price = (decimal)reader["Price"];
                    car.CarType = (CarType)reader["Cartype"];
                    car.LeatherSeats = (bool)reader["Leatherseats"];
                    cars.Add(car);
                }

                return cars;
            }

        }

    }
}
