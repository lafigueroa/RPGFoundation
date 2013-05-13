using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTextTest
{
    public class Response
    {
        string responseLine;
        int[] nextLineRefs; // next Line
        int numLines;
        int refNum; // reference number

        

        public Response( int numLines, string newLine, int newRefNum)
        {
         
            nextLineRefs = new int[numLines];
            responseLine = newLine;
            numLines = 0;
            refNum = newRefNum;
        }

        public void addLine(CharLine newLine)
        {
            nextLineRefs[numLines] = newLine.GetRefNum();
            numLines++;
        }
        public int getRef()
        {
            return refNum;
        }
        public string getLine()
        {
            return responseLine;
        }

    }
}
