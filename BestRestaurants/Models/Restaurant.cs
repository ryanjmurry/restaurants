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
        public string City { get; set;  }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Atmosphere { get; set; }
        public string Price { get; set; }
        public string Portion { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int Id { get; set; }

        public Restaurant(int cuisineId, string name, string street1, string city, string state, int zip, string atmosphere, string price, string portion, int rating, string comments, int id = 0)
        {
            CuisineId = cuisineId;
            Name = name;
            Street1 = street1;
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
                bool cityEquality = (this.City == newRestaurant.City);
                bool stateEquality = (this.State == newRestaurant.State);
                bool zipEquality = (this.Zip == newRestaurant.Zip);
                bool atmosphereEquality = (this.Atmosphere == newRestaurant.Atmosphere);
                bool priceEquality = (this.Price == newRestaurant.Price);
                bool portionEquality = (this.Portion == newRestaurant.Portion);
                bool ratingEquality = (this.Rating == newRestaurant.Rating);
                bool commentsEquality = (this.Comments == newRestaurant.Comments);
                bool idEquality = (this.Id == newRestaurant.Id);

                return (idEquality && cuisineIdEquality && nameEquality && street1Equality && cityEquality && stateEquality && zipEquality && priceEquality && ratingEquality && portionEquality && atmosphereEquality && commentsEquality);
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
                int cuisineId = rdr.GetInt32(1);
                string restaurantName = rdr.GetString(2);
                string restaurantStreet1 = rdr.GetString(3);
                string restaurantCity = rdr.GetString(4);
                string restaurantState = rdr.GetString(5);
                int restaurantZip = rdr.GetInt32(6);
                string restaurantAtmosphere = rdr.GetString(7);
                string restaurantPrice = rdr.GetString(8);
                string restaurantPortion = rdr.GetString(9);
                int restaurantRating = rdr.GetInt32(10);
                string restaurantComments = rdr.GetString(11);
                int restaurantId = rdr.GetInt32(0);
                Restaurant newRestaurant = new Restaurant(cuisineId, restaurantName, restaurantStreet1, restaurantCity, restaurantState, restaurantZip, restaurantAtmosphere, restaurantPrice, restaurantPortion, restaurantRating, restaurantComments, restaurantId);
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
            cmd.CommandText = @"INSERT INTO restaurants (cuisine_id, name, street_address_1, city, state, zip, atmosphere, price, portion, rating, comments) VALUES (@RestaurantCuisineId, @RestaurantName, @RestaurantStreet_address_1, @RestaurantCity, @RestaurantState, @RestaurantZip, @RestaurantAtmosphere, @RestaurantPrice, @RestaurantPortion, @RestaurantRating, @RestaurantComments);";

            cmd.Parameters.AddWithValue("@RestaurantCuisineId", this.CuisineId);
            cmd.Parameters.AddWithValue("@RestaurantName", this.Name);
            cmd.Parameters.AddWithValue("@RestaurantStreet_address_1", this.Street1);
            cmd.Parameters.AddWithValue("@RestaurantCity", this.City);
            cmd.Parameters.AddWithValue("@RestaurantState", this.State);
            cmd.Parameters.AddWithValue("@RestaurantZip", this.Zip);
            cmd.Parameters.AddWithValue("@RestaurantAtmosphere", this.Atmosphere);
            cmd.Parameters.AddWithValue("@RestaurantPrice", this.Price);
            cmd.Parameters.AddWithValue("@RestaurantPortion", this.Portion);
            cmd.Parameters.AddWithValue("@RestaurantRating", this.Rating);
            cmd.Parameters.AddWithValue("@RestaurantComments", this.Comments);

            cmd.ExecuteNonQuery();
            this.Id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Restaurant Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `restaurants` WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int restaurantId = 0;
            int cuisineId = 0;
            string restaurantName = "";
            string restaurantStreet1 = "";
            string restaurantCity = "";
            string restaurantState = "";
            int restaurantZip = 0;
            string restaurantAtmosphere = "";
            string restaurantPrice = "";
            string restaurantPortion = "";
            int restaurantRating = 0;
            string restaurantComments = "";

            while (rdr.Read())
            {
                
                cuisineId = rdr.GetInt32(1);
                restaurantName = rdr.GetString(2);
                restaurantStreet1 = rdr.GetString(3);
                restaurantCity = rdr.GetString(4);
                restaurantState = rdr.GetString(5);
                restaurantZip = rdr.GetInt32(6);
                restaurantAtmosphere = rdr.GetString(7);
                restaurantPrice = rdr.GetString(8);
                restaurantPortion = rdr.GetString(9);
                restaurantRating = rdr.GetInt32(10);
                restaurantComments = rdr.GetString(11);
                restaurantId = rdr.GetInt32(0);
            }

            Restaurant foundRestaurant = new Restaurant(cuisineId, restaurantName, restaurantStreet1, restaurantCity, restaurantState, restaurantZip, restaurantAtmosphere, restaurantPrice, restaurantPortion, restaurantRating, restaurantComments, restaurantId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundRestaurant;
        }

        public void Update(int cuisineId, string restaurantName, string restaurantStreet1, string restaurantCity, string restaurantState, int restaurantZip, string restaurantAtmosphere, string restaurantPrice, string restaurantPortion, int restaurantRating, string restaurantComments, int restaurantId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE restaurants SET cuisine_id = @RestaurantCuisineId, name = @RestaurantName, street_address_1 = @RestaurantStreet_address_1, city = @RestaurantCity, state = @RestaurantState, zip = @RestaurantZip, atmosphere = @RestaurantAtmosphere, price = @RestaurantPrice, portion = @RestaurantPortion, rating = @RestaurantRating, comments = @RestaurantComments WHERE id = @RestaurantId;";

            cmd.Parameters.AddWithValue("@RestaurantId", restaurantId);
            cmd.Parameters.AddWithValue("@RestaurantCuisineId", cuisineId);
            cmd.Parameters.AddWithValue("@RestaurantName", restaurantName);
            cmd.Parameters.AddWithValue("@RestaurantStreet_address_1", restaurantStreet1);
            cmd.Parameters.AddWithValue("@RestaurantCity", restaurantCity);
            cmd.Parameters.AddWithValue("@RestaurantState", restaurantState);
            cmd.Parameters.AddWithValue("@RestaurantZip", restaurantZip);
            cmd.Parameters.AddWithValue("@RestaurantAtmosphere", restaurantAtmosphere);
            cmd.Parameters.AddWithValue("@RestaurantPrice", restaurantPrice);
            cmd.Parameters.AddWithValue("@RestaurantPortion", restaurantPortion);
            cmd.Parameters.AddWithValue("@RestaurantRating", restaurantRating);
            cmd.Parameters.AddWithValue("@RestaurantComments", restaurantComments);

            cmd.ExecuteNonQuery();
            Id = restaurantId;
            CuisineId = cuisineId;
            Name = restaurantName;
            Street1 = restaurantStreet1;
            City = restaurantCity;
            State = restaurantState;
            Zip = restaurantZip;
            Atmosphere = restaurantAtmosphere;
            Price = restaurantPrice;
            Portion = restaurantPortion;
            Rating = restaurantRating;
            Comments = restaurantComments;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurants WHERE id = @RestaurantId;";

            cmd.Parameters.AddWithValue("@RestaurantId", this.Id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteByCuisine(int cId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurants WHERE cuisine_id = @CuisineId;";
            cmd.Parameters.AddWithValue("@CuisineId", cId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
