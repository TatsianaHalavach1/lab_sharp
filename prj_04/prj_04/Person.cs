using System;

namespace prj_04
{
    public enum Genders { Man = 0, Woman = 1 }

    public class Person
    {   
        public static int Population { get; private set; }
        public string Name { get; }
        public DateTime DateOfBirth { get; }
        public string Gender { get; }

        public Person(string name, DateTime dateOfBirth, int gender = 0)
        {
            Population++;
            Name = name;
            DateOfBirth = dateOfBirth;
            switch ((Genders)gender)
            {
                case Genders.Man:
                    Gender = Genders.Man.ToString();
                    break;
                case Genders.Woman:
                    Gender = "woman";
                    break;
                default:
                    goto case Genders.Man;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, {DateOfBirth.ToShortDateString()}, gender: {Gender}";
        }
    }
}
