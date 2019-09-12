using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTac.Calculator
{
    // // You are given a collection of person objects with three fields=
    // // {firstName, lastName, age} e.g. {Jane, Smith, 14}
    // // We want to know which family has the longest line of "juniors". 
    // // A family has "juniors" when multiple family members have the same full name.

    // // Consider the following example.
    // // [
    // //     {firstName= "John",  lastName= "Doe",   age= 13},    
    // //     {firstName= "John",  lastName= "Doe",   age= 32},   
    // //     {firstName= "John",  lastName= "Doe",   age= 62},  
    // //     {firstName= "Janet", lastName= "Doe",   age= 14},
    // //     {firstName= "Jenny", lastName= "Smith", age= 34},   
    // //     {firstName= "Jenny", lastName= "Smith", age= 12},  
    // // ]

    // // In this example, the Doe family has the longest line of juniors.

    // // Let’s talk about your plan of attack before you start coding, and remember 
    // // to keep talking me through what you are doing as you code.

    // Return family with longest line of juniors
    
    public class LongestLineOfJuniorsCommand : CommandBase
    {
        public LongestLineOfJuniorsCommand(IReceiver receiver) : base(receiver)
        {
        }
            public override void Execute()
            {
            var persons = new[]
            {
                new {FirstName= "John",  LastName= "Doe",   Age= 32 },
                new { FirstName= "John",  LastName= "Doe",   Age= 62 },
                new {FirstName= "Janet", LastName= "Doe",   Age= 14 },
                new { FirstName= "Jenny", LastName= "Smith", Age= 34 },
                new { FirstName= "Jenny", LastName= "Smith", Age= 12}
            };

            var longestLineOfJuniors = (from person in persons
                                        group person by new { person.FirstName, person.LastName } into family
                                        select new
                                        {
                                            Family = family.Key,
                                            Count = family.Count(),
                                        }).OrderByDescending(c => c.Count)
                                      .FirstOrDefault();

            receiver.Process(new Result { Value = longestLineOfJuniors.Count,
                Alias = string.Format("- Family with longest line of juniors is Mr. \"{0}\"", longestLineOfJuniors.Family.LastName.ToUpperInvariant()) });

        }

    }
}
