using System;
using System.Collections.Generic;
using System.Text;

namespace polimorfidemo
{
    class Nocco : Product
    {
        private string _flavor;

        public string MyProperty
        {
            get { return _flavor; }
            set { _flavor = value; }
        }

    }
}
