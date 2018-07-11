using System;
namespace BestRestaurants.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int CuisineId { get; set; }
        public string Name { get; set;  }
        public string Street1 { get; set; }
        public string Street2 { get; set;  }
        public string City { get; set;  }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Price { get; set; }
        public int Rating { get; set; }
        public string Portion { get; set; }
        public string Atmosphere { get; set; }
        public string Comments { get; set; }

        public Restaurant(int cuisineId, string name, string street1, string street2, string city, string state, string price, int rating, string portion, string atmosphere, string comments, int id = 0, )
        {
            Id = id;
            CuisineId = cuisineId;
            Name = name;
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            Price = price;
            Rating = rating;
            Portion = portion;
            Atmosphere = atmosphere;
            Comments = comments;
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
                bool idEquality = (this.Id == newRestaurant.Id);
                bool cuisineIdEquality = (this.CuisineId == newRestaurant.CuisineId);
                bool nameEquality = (this.Name == newRestaurant.Name);
                bool street1Equality = (this.Street1 == newRestaurant.Street1);
                bool street2Equality = (this.Street2 == newRestaurant.Street2);
                bool cityEquality = (this.City == newRestaurant.City);
                bool stateEquality = (this.State == newRestaurant.State);
                bool zipEquality = (this.Zip == newRestaurant.Zip);
                bool priceEquality = (this.Price == newRestaurant.Price);
                bool ratingEquality = (this.Rating == newRestaurant.Rating);
                bool portionEquality = (this.Portion == newRestaurant.Portion);
                bool atmosphereEquality = (this.Atmosphere == newRestaurant.Atmosphere);
                bool commentsEquality = (this.Comments == newRestaurant.Comments);

                return (idEquality && cuisineIdEquality && nameEquality && street1Equality && street2Equality && cityEquality && stateEquality && zipEquality && priceEquality && ratingEquality && portionEquality && atmosphereEquality && commentsEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }


    }
}
