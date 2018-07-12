using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BestRestaurants;

namespace BestRestaurants.Models
{
    public class Cuisine
    {
        public int Cid { get; set; }
        public string Type { get; set; }

        public Cuisine(int cuisineId, string cuisineType)
        {
            Cid = cuisineId;
            Type = cuisineType;
        }

        public override bool Equals(System.Object otherCuisine)
        {
            if (!(otherCuisine is Cuisine))
            {
                return false;
            }
            else
            {
                Cuisine newCuisine = (Cuisine) otherCuisine;
                bool cuisineIdEquality = (this.Cid == newCuisine.Cid);
                bool typeEquality = (this.Type == newCuisine.Type);

                return (cuisineIdEquality && typeEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Type.GetHashCode();
        }

        public static List<Cuisine> GetAll()
        {
            List<Cuisine> allCuisines = new List<Cuisine> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisines;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int cuisineId = rdr.GetInt32(0);
                string cuisineType = rdr.GetString(1);
                Cuisine newCuisine = new Cuisine(cuisineId, cuisineType);
                allCuisines.Add(newCuisine);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCuisines;
        }

        public static Cuisine Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisines WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int CuisineId = 0;
            string CuisineType = "";

            while (rdr.Read())
            {
                CuisineId = rdr.GetInt32(0);
                CuisineType = rdr.GetString(1);
            }
            Cuisine newCuisine = new Cuisine(CuisineId, CuisineType);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newCuisine;
        }

        public List<Restaurant> GetRestaurantsByCuisine(int cId)
        {
            List<Restaurant> allCuisineRestaurants = new List<Restaurant> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurants WHERE cuisine_id = @CuisineId;";
            cmd.Parameters.AddWithValue("@CuisineId", cId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
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
                allCuisineRestaurants.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCuisineRestaurants;
        }
    }
}
