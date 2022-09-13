namespace VisitorManagementStudent2022.Models
{
    public class Visitors
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Business { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }

        //navigation

        public Guid StaffNameId { get; set; }
        public StaffNames? StaffName { get; set; }

    }
}
