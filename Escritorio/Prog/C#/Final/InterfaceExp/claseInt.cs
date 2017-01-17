using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceExp
{
    public class claseInt: ExpInterface
    {

        bool ExpInterface.algo
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
