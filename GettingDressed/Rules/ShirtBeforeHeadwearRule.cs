using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    /// <summary>
    /// you must wear shirt before any jacket/hat/sunglasses
    /// </summary>
    public class ShirtBeforeHeadwearRule : Rule
    {
        public ShirtBeforeHeadwearRule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
                    : base(inputArr, curIndex, temperature, curClothes)
        {
        }

        public override bool IsFail()
        {
            var curValue = int.Parse(inputArray[currentIndex]);
            var currentItem = new Clothes().GetClothesAt(curValue, currentTemperature);
            if (
                (currentItem == "jacket" || currentItem == "hat" || currentItem == "sunglasses")
                && !currentClothes.Contains("shirt")
                )
            {
                return true;
            }
            return base.IsFail();
        }
    }
}
