using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp3AfterDeletingRoamingAndLocalAppData
{
    public class UIntStack
    {
	    private int[] elems;
	    private int numberOfElements; 
	    private int max;

    	public UIntStack() {
		    numberOfElements = 0;
		    max = 2;
		    elems = new int[max];
	    }

	    public void Push(int k) {
		    int index;
		    bool alreadyMember;

		    alreadyMember = false;

		    for(index=0; index<numberOfElements; index++) {
			    if(k==elems[index]) {
				    alreadyMember = true;
				    break;
			    }
		    }
    		
		    if (alreadyMember) {
			    for (int j=index; j<numberOfElements-1; j++) {
				    elems[j] = elems[j+1];
			    }
			    elems[numberOfElements-1] = k;
		    }
		    else {
			    if (numberOfElements < max) {
				    elems[numberOfElements] = k;
				    numberOfElements++;
				    return;
			    } else {
				    Console.WriteLine("Stack full, cannot push");
				    return;
			    }
		    }
	    }

	    public void Pop() {
		    numberOfElements --;
	    }

	    public int Top() {
		    if (numberOfElements < 1) {
			     Console.WriteLine("Empty Stack");
			    return -1;
		    } else 
			    return elems[numberOfElements-1];
	    }

	    public bool IsEmpty() {
		    if (numberOfElements==0)
			    return true;
		    else
			    return false;
	    }

	    public int MaxSize() {
		    return max;
	    }

	    public bool IsMember(int k) {
		    for(int index=0; index<numberOfElements; index++)
			    if( k==elems[index])
				    return true;
		    return false;			
	    }

        public bool Equals(UIntStack s)
        {		
		    if (s.MaxSize() != max)
			    return false;
		    if (s.GetNumberOfElements() != numberOfElements)
			    return false;		
		    int [] sElems = s.GetArray();		
		    for (int j=0; j<numberOfElements; j++)	{
			    if ( elems[j] != sElems[j])
				    return false;
		    }
		    return true;
	    }

	    public int[] GetArray() {
		    int [] a;
		    a = new int[max];
		    for (int j=0; j<numberOfElements; j++)
			    a[j] = elems[j];
		    return a;
	    }
    	
	    public int GetNumberOfElements() {
		    return numberOfElements;
	    }
    	
	    public bool IsFull() {
		    return numberOfElements == max;
        }	
    }
}
