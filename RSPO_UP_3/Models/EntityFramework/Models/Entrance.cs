﻿namespace RSPO_UP_3.Models.EntityFramework.Models
{
	public class Entrance
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public string Date { get; set; }
	}
}