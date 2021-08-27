// ReSharper disable once RedundantUsingDirective
using System;

namespace SlektsTre
{
    public class Person
    {
        public int? Id;                         // public int? - It's a shortcut for INullable<int>. This means that someField can be null, and has a HasValue and Value properties, HasValue means it's not null and Value is the value, in this case, the int.
        public string FirstName;
        public string LastName;
        public int? BirthYear;
        public int? DeathYear;
        public Person Father;
        public Person Mother;
        private string ShowContent(string bef, object value, string aft)
        {
            if (value == null)
            {
                return "";

            }
            return $"{bef}{value}{aft}";               
        }
        public string GetDescription()
        {
            return ShowContent("", FirstName, " ") +
                   ShowContent("", LastName, " ") +
                   ShowContent("(Id=", Id, ")") +
                   ShowContent("Født: ", BirthYear, " ") +
                   ShowContent("Død: ", DeathYear, " ") +
                   ShowContent("Far: ", Father, "") +
                   ShowContent("Mor: ", Mother, "");
        }
        public override string ToString()
        {
            if (Id != null)
            {
                return $"{FirstName ?? ""} {LastName ?? ""}(Id={Id})".Trim();           // ?? The null-coalescing operator - returnerer verdien på venstre side hvis den ikke er null; ellers, evalureres høyre siden og returnerer dens verdi. Den evalurer ikke høyre siden dersom venstre siden evalueres til non-null.
            }
            else return $"{FirstName ?? ""} {LastName ?? ""}".Trim();                   // Trim() - Removes all leading and trailing white-space characters from the current string.
        }
    }
   
}
