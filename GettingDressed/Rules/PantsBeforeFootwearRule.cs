using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    /// <summary>
    /// you must wear pants/shorts before boots/sandals
    /// </summary>
    public class PantsBeforeFootwearRule : Rule
    {
        public PantsBeforeFootwearRule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
            : base(inputArr, curIndex, temperature, curClothes)
        {
        }

        public override bool IsFail()
        {
            var curValue = int.Parse(inputArray[currentIndex]);
            var currentItem = new Clothes().GetClothesAt(curValue, currentTemperature);
            if (currentItem == "boots" && !currentClothes.Contains("pants")
                || (currentItem == "sandals" && !currentClothes.Contains("shorts")
                ))
            {
                return true;
            }
            return base.IsFail();
        }
    }
}
