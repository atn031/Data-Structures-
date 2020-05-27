using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablePractice
{
    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }


        public Person(int Id, int Age, string Name, String Occupation )
        {
            this.Id = Id;
            this.Age = Age;
            this.Name = Name;
            this.Occupation = Occupation; 
        }
    }
}
