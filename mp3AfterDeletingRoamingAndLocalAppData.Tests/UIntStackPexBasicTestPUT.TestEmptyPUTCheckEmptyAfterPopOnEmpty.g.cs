using Microsoft.Pex.Framework.Exceptions;
using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp3AfterDeletingRoamingAndLocalAppData;
// <copyright file="UIntStackPexBasicTestPUT.TestEmptyPUTCheckEmptyAfterPopOnEmpty.g.cs">Copyright ©  2017</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace mp3AfterDeletingRoamingAndLocalAppData.Tests
{
    public partial class UIntStackPexBasicTestPUT
    {

[TestMethod]
[PexGeneratedBy(typeof(UIntStackPexBasicTestPUT))]
[PexRaisedException(typeof(PexAssertFailedException))]
public void TestEmptyPUTCheckEmptyAfterPopOnEmptyThrowsPexAssertFailedException93()
{
    UIntStack uIntStack;
    int[] ints = new int[0];
    uIntStack = UIntStackFactory.CreateVariedSizeAnyElemsStack(ints);
    this.TestEmptyPUTCheckEmptyAfterPopOnEmpty(uIntStack, 0);
}
    }
}
