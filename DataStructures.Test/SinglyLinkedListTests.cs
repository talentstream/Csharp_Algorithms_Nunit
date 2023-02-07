using System;
using System.Linq;
using DataStructures.LinkedList.SinglyLinkedList;

namespace DataStructures.Test
{
    public static class SinglyLinkedListTests
    {
        [Test]
        public static void LengthWorksCorrectly([Random(0,1000,100)] int quantity)
        {
            // Arrange
            var testList = new SinglyLinkedList<int>();

            // Act 
            var r = TestContext.CurrentContext.Random;

            for(var i = 0; i < quantity; i++)
            {
                _ = testList.AddFirst(r.Next());
            }

            // Assert
            Assert.AreEqual(quantity,testList.Length());
        }

        [Test]
        public static void LengthOnEmptyListIsZero()
        {
            // Arrange
            var testList = new SinglyLinkedList<int>();
            // Act

            // Assert
            Assert.AreEqual(0, testList.Length());
        }

        [Test]
        public static void GetItemsFromLinkedList()
        {
            // Arrange
            var testList = new SinglyLinkedList<string>();
            _ = testList.AddLast("H");
            _ = testList.AddLast("E");
            _ = testList.AddLast("L");
            _ = testList.AddLast("L");
            _ = testList.AddLast("O");

            // Act
            var items = testList.GetListData();

            // Assert
            Assert.AreEqual(5, items.Count());
            Assert.AreEqual("O", testList.GetElementByIndex(4));
        }

        [Test]
        public static void GetElementByIndex_IndexOutOfRange_ArgumentOutOfRangeExceptionThrown()
        {
            // Arrange
            var testList = new SinglyLinkedList<int>();

            // Act
            _ = testList.AddFirst(1);
            _ = testList.AddFirst(2);
            _ = testList.AddFirst(3);

            // Assert
            _ = Assert.Throws<ArgumentOutOfRangeException>(() => testList.GetElementByIndex(-1));
            _ = Assert.Throws<ArgumentOutOfRangeException>(() => testList.GetElementByIndex(3));
        }

        [Test]
        public static void RemoveItemsFromList()
        {
            // Arrange
            var testList = new SinglyLinkedList<string>();
            _ = testList.AddLast("X");
            _ = testList.AddLast("H");
            _ = testList.AddLast("E");
            _ = testList.AddLast("L");
            _ = testList.AddLast("L");
            _ = testList.AddLast("I");
            _ = testList.AddLast("O");

            // Act
            var xRemoveSucess = testList.DeleteElement("X");
            var oRemoveSucess = testList.DeleteElement("O");
            var eRemoveSucess = testList.DeleteElement("E");
            var lRemoveSucess = testList.DeleteElement("L");
            var l2RemoveSucess = testList.DeleteElement("L");
            var l3RemoveSucess = testList.DeleteElement("L");
            var nonExistantRemoveSucess = testList.DeleteElement("F");

            var resultString = testList.GetElementByIndex(0) + testList.GetElementByIndex(1);

            // Assert
            Assert.AreEqual("HI", resultString);
            Assert.IsTrue(xRemoveSucess);
            Assert.IsTrue(oRemoveSucess);
            Assert.IsTrue(eRemoveSucess);
            Assert.IsTrue(lRemoveSucess);
            Assert.IsTrue(l2RemoveSucess);
            Assert.IsFalse(l3RemoveSucess);
            Assert.IsFalse(nonExistantRemoveSucess);
        }
    }
}