namespace RevolutionIT_Technical_Test
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public Person(string firstname, string lastname, string cardnumber)
        {
            FirstName = firstname;
            LastName = lastname;
            CardNumber = cardnumber;
        }
    }
}