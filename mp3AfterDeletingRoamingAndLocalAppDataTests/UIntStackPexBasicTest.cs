using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp3AfterDeletingRoamingAndLocalAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Pex.Framework;
namespace mp3AfterDeletingRoamingAndLocalAppData.Tests
{
    [TestClass()]
    public partial class UIntStackPexBasicTest
    {
        //these conventional test cases are created from JUnit test cases found at:
        /*
         * 
            http://rockfish-cs.cs.unc.edu/testing/
            http://rockfish-cs.cs.unc.edu/jax/lindsey/
            http://rockfish-cs.cs.unc.edu/JAX/
            http://rockfish-cs.cs.unc.edu/JUnitExamples/

            Here are their related papers:
            http://rockfish.cs.unc.edu/pubs/TR02-012.pdf
            http://rockfish.cs.unc.edu/misc/ajax-SEL02abst.pdf
            http://citeseerx.ist.psu.edu/viewdoc/summary?doi=10.1.1.47.1219
         */

        [TestMethod]
        public void TestEmpty()
        // Tests the emptying of the stack.
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            numbers.Push(k);
            PexAssert.IsTrue(!numbers.IsEmpty());
            numbers.Pop();
            PexAssert.IsTrue(numbers.IsEmpty());
        }

        [TestMethod]
        public void TestFull()
        // Tests the fulling of the stack. 
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            int j = 2;
            numbers.Push(k);
            PexAssert.IsTrue(!numbers.IsFull());
            numbers.Push(j);
            PexAssert.IsTrue(numbers.IsFull());
            numbers.Pop();
            PexAssert.IsTrue(!numbers.IsFull());
        }

        [TestMethod]
        public void TestMax()
        // Tests whether is a stack is full after a push of the stack. 
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            //max size is 2
            PexAssert.IsTrue(numbers.MaxSize() == 2);
            numbers.Push(k);
            PexAssert.IsTrue(numbers.MaxSize() == 2);
        }



        [TestMethod]
        public void TestMember()
        // Tests the emptying of the stack.  
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            int j = 2;
            numbers.Push(k);
            PexAssert.IsTrue(numbers.IsMember(3));
            numbers.Push(j);
            PexAssert.IsTrue(numbers.IsMember(2));
            numbers.Pop();
            PexAssert.IsTrue(!numbers.IsMember(2));
        }

        [TestMethod]
        public void TestGetNumberOfElements()
        // Tests the num elem of a stack. 
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            int j = 2;
            int n = 1;
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 0);
            numbers.Push(k);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 1);
            numbers.Push(k);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 1);
            numbers.Push(j);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 2);
            numbers.Push(n);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 2);
        }

        [TestMethod]
        public void TestTop()
        // Tests the peeking at the top of the stack. 
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            int j = 2;
            int n = 1;
            numbers.Push(k);
            PexAssert.IsTrue(numbers.Top() == k);
            numbers.Push(j);
            PexAssert.IsTrue(numbers.Top() == j);
            //max stack == 2
            numbers.Push(n);
            PexAssert.IsTrue(numbers.Top() == j);

        }

        [TestMethod]
        public void TestPop()
        // Tests the popping of the stack.  
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            numbers.Push(k);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 1);
            PexAssert.IsTrue(numbers.IsMember(k));
            numbers.Pop();
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 0);
            PexAssert.IsTrue(!numbers.IsMember(k));
        }

        [TestMethod]
        public void TestPush()
        // Tests the pushing of the stack. 
        {
            UIntStack numbers = new UIntStack();
            int k = 3;
            int j = 2;
            numbers.Push(k);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 1);
            PexAssert.IsTrue(numbers.IsMember(k));
            numbers.Push(k);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 1);
            PexAssert.IsTrue(numbers.IsMember(k));
            numbers.Push(j);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 2);
            PexAssert.IsTrue(numbers.IsMember(j));
            PexAssert.IsTrue(numbers.IsMember(k));
            PexAssert.IsTrue(numbers.Top() == j);
            numbers.Push(k);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 2);
            PexAssert.IsTrue(numbers.IsMember(j));
            PexAssert.IsTrue(numbers.IsMember(k));
            PexAssert.IsTrue(numbers.Top() == k);
        }
    }
}