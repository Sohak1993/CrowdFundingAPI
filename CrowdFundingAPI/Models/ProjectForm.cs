namespace CrowdFundingAPI.Models
{
    public class ProjectForm
    {
		public int Id { get; set; }
		public int IdOwner { get; set; }
		public string Title { get; set; }
		public string Description { get; set; } = string.Empty;
		public int Goal { get; set; }
		public DateOnly BeginDate { get; set; }
		public DateOnly EndDate { get; set; }
		public int IdUser { get; set; }
		public bool IsValidate { get; set; }
	}
}
