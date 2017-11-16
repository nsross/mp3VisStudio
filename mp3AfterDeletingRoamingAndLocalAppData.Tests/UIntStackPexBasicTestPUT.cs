// <copyright file="UIntStackTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp3AfterDeletingRoamingAndLocalAppData;

namespace mp3AfterDeletingRoamingAndLocalAppData.Tests
{
    /// <summary>This class contains parameterized unit tests for UIntStack</summary>
    [PexClass(typeof(UIntStack))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class UIntStackPexBasicTestPUT
    {
        //This PUT test class is a holder for parameterized unit tests generalized from conventional unit tests
        //This PUT test class includes parameterized unit tests generalized from UIntStackPexBasicTest, including
        //conventional test cases that are created from JUnit test cases found at:
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

        //Naming convention: for a conventional test case testXXX, the PUT generalized from it is testXXXPUT being prefixed by meaningful 
        //words to indicate the purpose of the PUT, such as TestFullPUTCheckFullAfterPop
        //When filling here a PUT, please copy its corresponding conventional unit test above the PUT and comment
        //out the conventional unit test with /* */. When multiple PUTs are created from the same conventional unit test,
        //you need to copy only the conventional unit test once above the first PUT. Below is one example: generalizing 
        //TestFullPUT1, TestFullPUT2, and TestFullPUT3 from TestFull.

        /*
         *
         *public void TestFull()
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
         */

        [PexMethod]
        public void TestFullPUTCheckFullAfterPushOnNotNearFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.GetNumberOfElements() < (numbers.MaxSize() - 1));
            numbers.Push(i);
            PexAssert.IsTrue(!numbers.IsFull());
        }

        [PexMethod]
        public void TestFullPUTCheckFullAfterPushOnNearFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.GetNumberOfElements() == (numbers.MaxSize() - 1));
            PexAssume.IsTrue(!numbers.IsMember(i));
            numbers.Push(i);
            PexAssert.IsTrue(numbers.IsFull());
        }

        [PexMethod]
        public void TestFullPUTCheckFullAfterPop([PexAssumeUnderTest]UIntStack numbers)
        {
            numbers.Pop();
            PexAssert.IsTrue(!numbers.IsFull());
        }

        [PexMethod]
        public void TestEmptyPUTCheckEmptyAfterPush([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            numbers.Push(i);
            PexAssert.IsTrue(!numbers.IsEmpty());
        }


        [PexMethod]
        public void TestEmptyPUTCheckEmptyAfterPopOnEmpty([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.GetNumberOfElements() == 0);
            numbers.Pop();
            PexAssert.IsTrue(numbers.IsEmpty());
        }

        [PexMethod]
        public void TestEmptyPUTCheckEmptyAfterPopOnNearEmpty([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.GetNumberOfElements() == 1);
            numbers.Pop();
            PexAssert.IsTrue(numbers.IsEmpty());
        }

        [PexMethod]
        public void TestEmptyPUTCheckEmptyAfterPopOnNotNearEmpty([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.GetNumberOfElements() > 1);
            numbers.Pop();
            PexAssert.IsTrue(!numbers.IsEmpty());
        }

        [PexMethod]
        public void TestMaxPUTCheckMaxAfterPushOnFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsFull());
            numbers.Push(i);
            PexAssert.IsTrue(numbers.MaxSize() == 2);
        }

        [PexMethod]
        public void TestMaxPUTCheckMaxAfterPushOnNearFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.GetNumberOfElements() == (numbers.MaxSize() - 1));
            numbers.Push(i);
            PexAssert.IsTrue(numbers.MaxSize() == 2);
        }

        [PexMethod]
        public void TestMaxPUTCheckMaxAfterPushOnNotNearFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.GetNumberOfElements() < (numbers.MaxSize() - 1));
            numbers.Push(i);
            PexAssert.IsTrue(numbers.MaxSize() == 2);
        }

        [PexMethod]
        public void TestMemberPUTCheckMemberIfMember([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsEmpty());
            numbers.Push(i);
            PexAssert.IsTrue(numbers.IsMember(i));
        }

        [PexMethod]
        public void TestMemberPUTCheckMemberIfNotMemberAndEmpty([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsEmpty());
            PexAssert.IsTrue(!numbers.IsMember(i));
        }

        [PexMethod]
        public void TestMemberPUTCheckMemberIfNotMemberAndNotEmpty([PexAssumeUnderTest]UIntStack numbers, int i, int j)
        {
            PexAssume.IsTrue(numbers.IsEmpty());
            PexAssume.IsTrue(i != j);
            numbers.Push(i);
            PexAssert.IsTrue(!numbers.IsMember(j));
        }

        [PexMethod]
        public void TestMemberPUTCheckMemberIfNotMemberAfterPop([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsEmpty());
            numbers.Push(i);
            numbers.Pop();
            PexAssert.IsTrue(!numbers.IsMember(i));
        }

        [PexMethod]
        public void TestGetNumberOfElementsPUTCheckIfEmpty([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsEmpty());
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 0);
        }

        [PexMethod]
        public void TestGetNumberOfElementsPUTCheckIfFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsFull());
            PexAssert.IsTrue(numbers.GetNumberOfElements() == numbers.MaxSize());
        }

        [PexMethod]
        public void TestGetNumberOfElementsPUTCheckAfterPush([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(!numbers.IsFull());
            PexAssume.IsTrue(!numbers.IsMember(i));
            int num = numbers.GetNumberOfElements();
            numbers.Push(i);
            PexAssert.IsTrue(numbers.GetNumberOfElements() == (num + 1));
        }

        [PexMethod]
        public void TestGetNumberOfElementsPUTCheckAfterPop([PexAssumeUnderTest]UIntStack numbers)
        {
            PexAssume.IsTrue(!numbers.IsEmpty());
            int num = numbers.GetNumberOfElements();
            numbers.Pop();
            PexAssert.IsTrue(numbers.GetNumberOfElements() == (num - 1));
        }

        [PexMethod]
        public void TestTopPUTCheckTopAfterEmpty([PexAssumeUnderTest]UIntStack numbers)
        {
            PexAssume.IsTrue(numbers.IsEmpty());
            int num = numbers.Top();
            //PexAssert.IsTrue(); TODO handle error
        }

        [PexMethod]
        public void TestTopPUTCheckTopAfterPushOnNotFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(!numbers.IsFull());
            PexAssume.IsTrue(!numbers.IsMember(i));
            numbers.Push(i);
            PexAssert.IsTrue(numbers.Top() == i);
        }

        [PexMethod]
        public void TestTopPUTCheckTopAfterPushOnFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsFull());
            PexAssume.IsTrue(!numbers.IsMember(i));
            int num = numbers.Top();
            numbers.Push(i);
            PexAssert.IsTrue(numbers.Top() == num);
        }

        [PexMethod]
        public void TestPopPUTCheckPopOnEmpty([PexAssumeUnderTest]UIntStack numbers)
        {
            PexAssume.IsTrue(numbers.IsEmpty());
            numbers.Pop();
            PexAssert.IsTrue(numbers.GetNumberOfElements() == 0);
        }

        [PexMethod]
        public void TestPopPUTCheckPopAfterPushOnFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(numbers.IsFull());
            PexAssume.IsTrue(!numbers.IsMember(i));
            int num = numbers.GetNumberOfElements();
            numbers.Push(i);
            numbers.Pop();
            PexAssert.IsTrue(numbers.GetNumberOfElements() == (num - 1));
        }

        [PexMethod]
        public void TestPopPUTCheckPopAfterPushOnNotFull([PexAssumeUnderTest]UIntStack numbers, int i)
        {
            PexAssume.IsTrue(!numbers.IsFull());
            PexAssume.IsTrue(!numbers.IsMember(i));
            int num = numbers.GetNumberOfElements();
            numbers.Push(i);
            numbers.Pop();
            PexAssert.IsTrue(numbers.GetNumberOfElements() == num);
        }
    }
}
