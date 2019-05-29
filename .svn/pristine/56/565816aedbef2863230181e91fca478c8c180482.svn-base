using OM.Lib.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Atman.Chakra
{
    public class SiseStorage
    {
        private static SiseStorage instance = new SiseStorage();
        public static SiseStorage Instance
        {
            get
            {
                return instance;
            }
        }

        private Dictionary<string, ConcurrentQueue<CurrentPrice>> prices =
            new Dictionary<string, ConcurrentQueue<CurrentPrice>>();

        public Dictionary<string, ConcurrentQueue<CurrentPrice>> Prices
        {
            get
            {
                return prices;
            }
        }
    }
}
