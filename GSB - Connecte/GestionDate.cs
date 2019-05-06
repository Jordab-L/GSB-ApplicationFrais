using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connecté
{
    class GestionDate
    {
        DateTime datelocale = DateTime.Now;

        public int getMoisCourant()
        {
            return datelocale.Month;
        }

        public int getMoisPrecedent()
        {
            if (datelocale.Month == 1)
            {
                return 12;
            }
            else
            {
                return datelocale.Month - 1;
            }
        }

        public int getMoisSuivant()
        {
            if (datelocale.Month == 12)
            {
                return 1;
            }
            else
            {
                return datelocale.Month + 1;
            }
        }

    }
}
