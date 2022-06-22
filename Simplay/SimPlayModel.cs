using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplay
{
    class SimPlayModel
    {
        public string _name;

        public int _ageLimit;

        public string _description;

        public int _price;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ageLimit
        {
            get { return _ageLimit; }
            set { _ageLimit = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
