namespace Domain.Abstract.Personal
{
    public interface IEmployee
    {
        string No { get; set; }
        string Name { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        DateTime TerminateDate { get; set; }
    }
}
