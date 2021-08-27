using System;
using System.Collections.Generic;

namespace SlektsTre
{
    public class FamilyApp
    {
        public string WelcomeMessage = "Velkommen til SlektsTre - Skriv 'Hjelp' for mer informasjon.";
        public string CommandPrompt = "";
        public List<Person> People;

        public FamilyApp(params Person[] family)
        {
            People = new List<Person>(family);
        }

        public string HandleCommand(string command)
        {
            var input = command.ToLower();

            if (input == "hjelp")
            {
                return HjelpCommand();
            }
            if (input == "liste")
            {
                return ListeCommand(People);
            }
            if (input.Contains("vis "))
            {
                return VisCommand(input, People);
            }
            if (input == "exit" || input == "x")
            {
                Environment.Exit(0);
            }
            return "Ugyldig kommando";
        }

        private static string ListeCommand(List<Person> people)
        {
            string tekst = String.Empty;
            foreach (var t in people)
            {
                tekst += t.GetDescription() + "\n";
            }

            return tekst;
        }
        private static string VisCommand(string input, List<Person> people)
        {
            var id = Int32.Parse(input.Substring(input.IndexOf(" ", StringComparison.Ordinal) + 1));
            var tekst = String.Empty;
            List<string> children = new List<string>();

            foreach (var t in people)
            {
                if (t.Id != id) continue;                   // The not-equal-to operator (!=) - returns true if the operands don't have the same value; otherwise, it returns false.
                tekst += t.GetDescription();
                foreach (var t1 in people)
                {
                    if (t1.Father != null)
                    {
                        if (t1.Father.Id == t.Id)
                        {
                            children.Add(t1.FirstName + " (Id=" + t1.Id + ") Født: " + t1.BirthYear);
                        }
                    }
                    if (t1.Mother == null) continue;
                    if (t1.Mother.Id == t.Id)
                    {
                        children.Add(t1.FirstName + " (Id=" + t1.Id + ") Født: " + t1.BirthYear);
                    }
                }
            }
            tekst += "\n";
            if (children.Count != 0)
                tekst += "  Barn:\n    ";
            {
                for (var i = 0; i < children.Count; i++)
                {
                    if (i == children.Count - 1)
                    {
                        tekst += children[i] + "\n";
                    }
                    else
                    {
                        tekst += children[i] + "\n    ";
                    }
                }
            }
            return tekst;
        }

        private static string HjelpCommand()
        {
            return @"
hjelp    => viser en hjelpetekst som forklarer alle kommandoene
liste    => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert
vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)";
        }

    }
}
