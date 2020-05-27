using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTablePractice;

namespace HashTableTesting
{
    [TestClass]
    public class HashTesting
    {
        [TestMethod]
        public void TestConstructorChaining()
        {
            HashTableForPerson_UsingChaining chain = new HashTableForPerson_UsingChaining();

            Assert.AreEqual(chain.listOfPeople.Length, 10);
        }

        [TestMethod]
        public void TestAddHash()
        {
            HashTableForPerson_UsingChaining chain = new HashTableForPerson_UsingChaining();
            Person a = new Person(0, 30, "Julie", "Engineer");
            Person b = new Person(0, 30, "Billy", "Engineer");
            Person c = new Person(0, 30, "Alex", "Engineer");
            Person d = new Person(2, 30, "John Cena", "Engineer");
            Person e = new Person(3, 30, "Matt", "Engineer");
            Person f = new Person(4, 30, "John", "Engineer");
            Person g = new Person(5, 30, "Bryant", "Engineer");
            Person h = new Person(6, 30, "Jac", "Engineer");
            Person i = new Person(7, 30, "Emily", "Engineer");
            Person j = new Person(8, 30, "Kyoko", "Engineer");
            Person k = new Person(9, 30, "Nina", "Engineer");
            Person l = new Person(9, 30, "Kerry", "Engineer");
            Person m = new Person(1, 30, "Olivia", "Engineer");
            Person n = new Person(1, 30, "Kendra", "Engineer");

            chain.addToHashTable(a);
            chain.addToHashTable(b);
            chain.addToHashTable(c);
            chain.addToHashTable(d);
            chain.addToHashTable(e);
            chain.addToHashTable(f);
            chain.addToHashTable(g);
            chain.addToHashTable(h);
            chain.addToHashTable(i);
            chain.addToHashTable(j);
            chain.addToHashTable(k);
            chain.addToHashTable(l); 
            chain.addToHashTable(m);
            chain.addToHashTable(n);

            Assert.AreEqual(chain.listOfPeople[0].First.Value, c);
            Assert.AreEqual(chain.listOfPeople[0].First.Next.Value, b);
            Assert.AreEqual(chain.listOfPeople[0].First.Next.Next.Value, a);

        }

        [TestMethod]
        public void TestRemove()
        {
            HashTableForPerson_UsingChaining chain = new HashTableForPerson_UsingChaining();
            Person a = new Person(0, 30, "Julie", "Engineer");
            Person b = new Person(0, 30, "Billy", "Engineer");
            Person c = new Person(0, 30, "Alex", "Engineer");
            Person d = new Person(2, 30, "John Cena", "Engineer");
            Person e = new Person(3, 30, "Matt", "Engineer");
            Person f = new Person(4, 30, "John", "Engineer");
            Person g = new Person(5, 30, "Bryant", "Engineer");
            Person h = new Person(6, 30, "Jac", "Engineer");
            Person i = new Person(7, 30, "Emily", "Engineer");
            Person j = new Person(8, 30, "Kyoko", "Engineer");
            Person k = new Person(9, 30, "Nina", "Engineer");
            Person l = new Person(9, 30, "Kerry", "Engineer");
            Person m = new Person(1, 30, "Olivia", "Engineer");
            Person n = new Person(1, 30, "Kendra", "Engineer");

            chain.addToHashTable(a);
            chain.addToHashTable(b);
            chain.addToHashTable(c);
            chain.addToHashTable(d);
            chain.addToHashTable(e);
            chain.addToHashTable(f);
            chain.addToHashTable(g);
            chain.addToHashTable(h);
            chain.addToHashTable(i);
            chain.addToHashTable(j);
            chain.addToHashTable(k);
            chain.addToHashTable(l);
            chain.addToHashTable(m);
            chain.addToHashTable(n);

            Assert.AreEqual(chain.listOfPeople[0].Count, 3);
            Assert.IsTrue(chain.removeFromhashTable(a));
            Assert.IsFalse(chain.removeFromhashTable(a));
            Assert.AreEqual(chain.listOfPeople[0].Count, 2);


        }

    }
}
