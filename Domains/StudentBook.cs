namespace Domains
{
    public class StudentBook : BaseEntity
    {
        public DateTime StartOfTake { get; set; }

        public DateTime EndOfTake { get; set; }

        public int StudentId { get; set; }

        public int BookId { get; set; }
    }
}
