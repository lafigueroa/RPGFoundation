using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTextTest
{
       public class CharLine
    {

        
        int refNum;
        string mainLine;
        int[] responseRefs;
        int numResponses;




        public CharLine(int newRef, int numResponses, string newLine = "")
        {
            mainLine = newLine;
            refNum = newRef;
            responseRefs = new int[numResponses];
            numResponses = 0;
        }
        
        

        
        public void NewMainLine(string newMainLine)
        {
            mainLine = newMainLine;
        }

    
        public void PrintMailLine()
        {
            System.Console.WriteLine(mainLine);
        }
        public void AddResponse(Response newResponse)
        {
            responseRefs[numResponses] = newResponse.getRef();
        }
        public int GetRefNum()
        {
            return refNum;
        }
 



    }
}
