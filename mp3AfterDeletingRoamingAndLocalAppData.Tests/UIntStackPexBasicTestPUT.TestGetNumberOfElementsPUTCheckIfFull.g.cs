using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mp3AfterDeletingRoamingAndLocalAppData;
// <copyright file="UIntStackPexBasicTestPUT.TestGetNumberOfElementsPUTCheckIfFull.g.cs">Copyright ©  2017</copyright>
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
public void TestGetNumberOfElementsPUTCheckIfFull444()
{
    UIntStack uIntStack;
    int[] ints = new int[2];
    ints[1] = 1;
    uIntStack = UIntStackFactory.CreateVariedSizeAnyElemsStack(ints);
    this.TestGetNumberOfElementsPUTCheckIfFull(uIntStack, 0);
    Assert.IsNotNull((object)uIntStack);
}
    }
}
