using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    public class LeaveHouseLastRule : Rule
    {
        public LeaveHouseLastRule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
            : base(inputArr, curIndex, temperature, curClothes)
        {
        }

        public override bool IsFail()
        {
            var curValue = int.Parse(inputArray[currentIndex]);
            if (currentIndex == inputArray.Length - 1 && curValue != 7)
            {
                return true;
            }
            return base.IsFail();
        }
    }
}
