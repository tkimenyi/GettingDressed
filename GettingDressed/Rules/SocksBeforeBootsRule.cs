using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    public class SocksBeforeBootsRule : Rule
    {
        public SocksBeforeBootsRule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
            : base(inputArr, curIndex, temperature, curClothes)
        {
        }

        public override bool IsFail()
        {
            var curValue = int.Parse(inputArray[currentIndex]);
            var currentItem = new Clothes().GetClothesAt(curValue, currentTemperature);
            if (currentItem == "boots" && !currentClothes.Contains("socks"))
            {
                return true;
            }
            return base.IsFail();
        }
    }
}
