using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRestaurants;
using System;

namespace BestRestaurants.Models
{
    public class Restaurant
    {
        public int CuisineId { get; set; }
        public string Name { get; set;  }
        public string Street1 { get; set; }
        public string Street2 { get; set;  }
        public string City { get; set;  }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Atmosphere { get; set; }
        public string Price { get; set; }
        public string Portion { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int Id { get; set; }

        public Restaurant(int cuisineId, string name, string street1, string street2, string city, string state, int zip, string atmosphere, string price, string portion, int rating, string comments, int id = 0)
        {
            CuisineId = cuisineId;
            Name = name;
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            Zip = zip;
            Atmosphere = atmosphere;
            Price = price;
            Portion = portion;
            Rating = rating;
            Comments = comments;
            Id = id;
        }

        public override bool Equals(System.Object otherRestaurant)
        {
            if (!(otherRestaurant is Restaurant))
            {
                return false;
            }
            else
            {
                Restaurant newRestaurant = (Restaurant) otherRestaurant;
                bool cuisineIdEquality = (this.CuisineId == newRestaurant.CuisineId);
                bool nameEquality = (this.Name == newRestaurant.Name);
                bool street1Equality = (this.Street1 == newRestaurant.Street1);
                bool street2Equality = (this.Street2 == newRestaurant.Street2);
                bool cityEquality = (this.City == newRestaurant.City);
                bool stateEquality = (this.State == newRestaurant.State);
                bool zipEquality = (this.Zip == newRestaurant.Zip);
                bool atmosphereEquality = (this.Atmosphere == newRestaurant.Atmosphere);
                bool priceEquality = (this.Price == newRestaurant.Price);
                bool portionEquality = (this.Portion == newRestaurant.Portion);
                bool ratingEquality = (this.Rating == newRestaurant.Rating);
                bool commentsEquality = (this.Comments == newRestaurant.Comments);
                bool idEquality = (this.Id == newRestaurant.Id);

                return (idEquality && cuisineIdEquality && nameEquality && street1Equality && street2Equality && cityEquality && stateEquality && zipEquality && priceEquality && ratingEquality && portionEquality && atmosphereEquality && commentsEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public static List<Restaurant> GetAll()
        {
            List<Restaurant> allRestaurants = new List<Restaurant> { }; 
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurants";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int cuisineId = rdr.GetInt32(0);
                string restaurantName = rdr.GetString(1);
                string restaurantStreet1 = rdr.GetString(2);
                string restaurantStreet2 = rdr.GetString(3);
                string restaurantCity = rdr.GetString(4);
                string restaurantState = rdr.GetString(5);
                int restaurantZip = rdr.GetInt32(6);
                string restaurantAtmosphere = rdr.GetString(7);
                string restaurantPrice = rdr.GetString(8);
                string restaurantPortion = rdr.GetString(9);
                int restaurantRating = rdr.GetInt32(10);
                string restaurantComments = rdr.GetString(11);
                int restaurantId = rdr.GetInt32(12);
                Restaurant newRestaurant = new Restaurant(cuisineId, restaurantName, restaurantStreet1, restaurantStreet2, restaurantCity, restaurantState, restaurantZip, restaurantAtmosphere, restaurantPrice, restaurantPortion, restaurantRating, restaurantComments, restaurantId);
                allRestaurants.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allRestaurants;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurants;";

            cmd.ExecuteNonQuery();
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO animals (cuisineId, name, street_address_1, street_address_2, city, state, zip, atmosphere, price, portion, rating, comments) VALUES (@RestaurantCuisineId, @RestaurantName, @RestaurantStreet_address_1, @RestaurantStreet_address_2, @RestaurantCity, @RestaurantState, @RestaurantZip, @RestaurantAtmosphere, @RestaurantPrice, @RestaurantPortion, @RestaurantRating, @RestaurantComments);";

            MySqlParameter cuisineId = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantCuisineId", this.Type);
            MySqlParameter name = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantName", this.Breed);
            MySqlParameter street_address_1 = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantStreet_address_1", this.Gender);
            MySqlParameter street_address_2 = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantStreet_address_2", this.Name);
            MySqlParameter city = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantCity", this.AdmittanceDate);
            MySqlParameter state = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantState", this.AdmittanceDate);
            MySqlParameter zip = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantZip", this.Type);
            MySqlParameter atmosphere = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantAtmosphere", this.Breed);
            MySqlParameter price = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantPrice", this.Gender);
            MySqlParameter portion = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantPortion", this.Name);
            MySqlParameter rating = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantRating", this.AdmittanceDate);
            MySqlParameter comments = new MySqlParameter();
            cmd.Parameters.AddWithValue("@RestaurantComments", this.AdmittanceDate);

            cmd.ExecuteNonQuery();
            this.Id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
