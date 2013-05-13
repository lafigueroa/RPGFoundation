using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGTEST
{
    public class Skills
    {

        int improv;
        int dodge;
        int grapple;

        public Skills(int newi, int newd, int newg)
        {
            improv = newi;
            dodge = newd;
            grapple = newg;
        }

        public void setImprov(int newi)
        {
            improv = newi;
        }
        public void setDodge(int newd)
        {
            dodge = newd;
        }
        public void setGrapple(int newg)
        {
            grapple = newg;
        }

    }
}