namespace Blazor.Models
{
    public class Adult : Person
    {
        public Adult()
        {
            JobTitle = new Job();
        }

        public Job JobTitle { get; set; }
    }
}