using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SlektsTre;

namespace SlektsTreTest
{
    class PersonTest
    {
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        public void Vilde()
        {
            var p = new Person
            {
                Id = 16,
                FirstName = "Vilde",
                LastName = "Svenkesen",
                BirthYear = 1994,
                Father = new Person() { Id = 34, },
                Mother = new Person() { Id = 35, },
            };

            var actualDescriptio = p.GetDescription();
            var expectedDescriptio = "Vilde Svenkesen (Id=16) Født: 1994 Far: (Id=34) Mor: (Id=35)";

            Assert.AreEqual(actualDescriptio, expectedDescriptio);
        }
    }
}
