using mp3AfterDeletingRoamingAndLocalAppData;
// <copyright file="UIntStackFactory.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;

namespace mp3AfterDeletingRoamingAndLocalAppData
{
    /// <summary>A factory for mp3AfterDeletingRoamingAndLocalAppData.UIntStack instances</summary>
    public static partial class UIntStackFactory
    {
        //The factory method below is limited since it creates only a fixed stack state
        //i.e., the size of the stack is only 4, what if a fault can be exposed when the size of the stack is 2?
        //the elements in the stack are 0, 1, 2, 3, 4, what if a fault can be exposed when an element is -1 (e.g., for the TestIsEmptyTop pex method)?
        //what if a fault can be exposed when these elements being pushed have duplication?
        /*
        [PexFactoryMethod(typeof(UIntStack))]
        public static UIntStack CreateFixedSizeElemsStack()
        {
            UIntStack uIntStack = new UIntStack();
            for (int i = 0; i < 4; i++)
                uIntStack.Push(i);
            return uIntStack;
        }
         */

        //The factory method below is better than the above CreateFixedSizeElemsStack 
        //since it creates a varied size of a stack state (bounded by 3, otherwise Pex would get stuck by the infinite loop)
        //the elements in the stack are 0, 1, 2, 3, 4, ... what if a fault can be exposed when an element is -1 (e.g., for the TestIsEmptyTop pex method)?
        //what if a fault can be exposed when these elements being pushed have duplication?
        /*
        [PexFactoryMethod(typeof(UIntStack))]
        public static UIntStack CreateVarSizeFixedSElemsStack(int size)
        {
            PexAssume.IsTrue(size <= 3);
            UIntStack uIntStack = new UIntStack();
            for (int i = 0; i < size; i++)
                uIntStack.Push(i);
            return uIntStack;
        }
         */

        //The factory method below is the best! You can see that you can also apply the maximum generalization principle to
        //your factory method!
        //It creates a varied size of a stack state (bounded by 3, otherwise Pex would get stuck by the infinite loop)
        //the elements in the stack are any integers
        //It can find a fault with the TestIsEmptyTop pex method by finding an assertion violation!
        [PexFactoryMethod(typeof(UIntStack))]
        public static UIntStack CreateVariedSizeAnyElemsStack(int[] elems)
        {
            PexAssume.IsNotNull(elems);
            UIntStack uIntStack = new UIntStack();
            PexAssume.IsTrue(elems.Length <= (uIntStack.MaxSize() + 1));

            for (int i = 0; i < elems.Length; i++)
                uIntStack.Push(elems[i]);
            return uIntStack;
        }
    }
}
