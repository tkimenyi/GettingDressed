using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    public class Clothes
    {
       
        private readonly Dictionary<int, string> _hotClothes = new Dictionary<int, string>
        {
            { 1, "sandals" },
            { 2, "sunglasses" },
            { 3, "fail" },
            { 4, "shirt" },
            { 5, "fail" },
            { 6, "shorts" },
            { 7, "leaving house" },
            { 8, "Removing PJs" }
        };

        private readonly Dictionary<int, string> _coldClothes = new Dictionary<int, string>
        {
            { 1, "boots" },
            { 2, "hat" },
            { 3, "socks" },
            { 4, "shirt" },
            { 5, "jacket" },
            { 6, "pants" },
            { 7, "leaving house" },
            { 8, "Removing PJs" }
        };


        public string GetClothesAt(int key, string temperature) {
            if (key > 8 || key < 1) {
                return "fail";
            }
            if (temperature.ToLower().Trim() == "hot")
            {
                return _hotClothes[key];
            }
            else {
                return _coldClothes[key];
            }
        }

    }
}
