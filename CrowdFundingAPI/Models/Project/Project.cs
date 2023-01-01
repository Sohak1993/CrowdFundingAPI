﻿namespace CrowdFundingAPI.Models.Project
{
    public class Project
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; } = string.Empty;
		public int Goal { get; set; }
	}
}
