using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HashTablePractice
{
    public class HashtableForPerson_UsingLinearProbing
    {
        public Person[] listOfPeople { get; set; }
        public int TableSize { get; set; }
        public int currentCapacity { get; set; }

        public HashtableForPerson_UsingLinearProbing(int tableSize)
        {
            listOfPeople = new Person[tableSize];
            TableSize = tableSize;
            currentCapacity = 0;
        }

        public int hashFunction(int key)
        {
            return key % 13; 
        }
        public void Insertion(Person aPerson)
        {
            int index = hashFunction(aPerson.Id);
            int key = index;

            if (currentCapacity == TableSize)
            {
                Console.WriteLine("Capacity has been reached!!!");
                return;
            }

            if (listOfPeople[index] == null || listOfPeople[index].Id == -1)
            {
                listOfPeople[index] = aPerson;
                currentCapacity++;
            }
            else
            {
                int incrementIndex = 1;
                while (listOfPeople[index] != null && incrementIndex < TableSize)
                {
                    //index = (index + incrementIndex) % TableSize;
                    index = (key + incrementIndex) % TableSize;
                    incrementIndex++;
                    if (listOfPeople[index] != null && listOfPeople[index].Id == -1)
                    {
                        Console.WriteLine("In This loop");
                        break;
                    }
                        
                }

                if(listOfPeople[index] != null && listOfPeople[index].Id != -1)
                {
                    Console.WriteLine("Nah its still not empty later!!!");
                    return;
                }

                listOfPeople[index] = aPerson;
                Console.WriteLine("Made it here");
                currentCapacity++;

            }

        }


        public int retrieve(Person aPerson)
        {
            int index = hashFunction(aPerson.Id);
            int key = index;

            if (listOfPeople[index] == aPerson)
                return index;
            //return true;
            //return listOfPeople[index];
            else
            {
                int incrementIndex = 1;
                while (listOfPeople != null && incrementIndex < TableSize)
                {
                    index = (key + incrementIndex) % TableSize;
                    incrementIndex++;

                    if (listOfPeople[index] == aPerson)
                        return index;

                        //return true;
                    //return listOfPeople[index];
                }
                return -1;
                //return false;
                //return null;
            }
        }

        public Person removeLinear(Person aPerson)
        {
            Person a;
            int toDelete = retrieve(aPerson);

            if (toDelete != -1)
            {
                a = listOfPeople[toDelete];
                listOfPeople[toDelete] = new Person(-1, -1, "", "");

                Console.WriteLine("Person has been removed from list, and list has been replaced with placeholder");
                currentCapacity--;

                return a;
            }
            else
                return null;


        }

    }
}
