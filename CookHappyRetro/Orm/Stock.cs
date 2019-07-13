using System;
using SQLite;

namespace CookHappyRetro
{
	public class Stock {
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }
		
		[MaxLength(8)]
		public string Symbol { get; set; }

		public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Directions { get; set; }

        public string NutritionFacts { get; set; }
	}
}

