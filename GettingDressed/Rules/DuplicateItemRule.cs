using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    /// <summary>
    /// this rule makes sure the user does not wear the same item twice
    /// </summary>
    public class DuplicateItemRule : Rule
    {
        public DuplicateItemRule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
            : base(inputArr, curIndex, temperature, curClothes)
        {
        }

        public override bool IsFail()
        {
            var curValue = int.Parse(inputArray[currentIndex]);
            var currentItem = new Clothes().GetClothesAt(curValue, currentTemperature);
            if (currentClothes.Contains(currentItem))
            {
                return true;
            }
            return base.IsFail();
        }
    }
}
