using OM.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra.App
{
    public delegate void SiseDelegate(string item, CurrentPrice price);
    public class SiseEvents
    {
        private static SiseEvents instance = new SiseEvents();

        public static SiseEvents Instance
        {
            get
            {
                return instance;
            }
        }

        public event SiseDelegate SiseHandler;

        public void OnSiseHandler(string item, CurrentPrice price)
        {
            if (SiseHandler != null)
                SiseHandler(item, price);
        }
    }
}
