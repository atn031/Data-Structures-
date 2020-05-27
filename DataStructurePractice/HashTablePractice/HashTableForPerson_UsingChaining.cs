using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablePractice
{
   public class HashTableForPerson_UsingChaining
    {
        public LinkedList<Person>[] listOfPeople { get; set; }

        public HashTableForPerson_UsingChaining()
        {
            listOfPeople = new LinkedList<Person>[10];
        }

        public int hashFunction(int Id)
        {
            return Id % 10;
        }

        public void addToHashTable(Person aPerson)
        {
            int index = hashFunction(aPerson.Id);
            if(listOfPeople[index] == null)
            {
                listOfPeople[index] = new LinkedList<Person>();
            }

            listOfPeople[index].AddFirst(aPerson);
        }

        public Person search(Person aPerson)
        {
            int index = hashFunction(aPerson.Id);
            return listOfPeople[index].Find(aPerson).Value;
        }

        public Boolean removeFromhashTable(Person aPerson)
        {
            int index = hashFunction(aPerson.Id);
            if (listOfPeople[index].Contains(aPerson))
            {
                listOfPeople[index].Remove(aPerson);
                Console.WriteLine("Person has bee removed from the list");
                return true;
            }

            else
            {
                Console.WriteLine("That person doesn't exist in the hashtable!!");
                return false;
            }
             
        }
    }


}
