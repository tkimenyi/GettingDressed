using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    /// <summary>
    /// this rule is to make sure that user removed PJs before wearing putting on anything else
    /// </summary>
    public class RemovePJRule : Rule
    {
        public RemovePJRule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
            : base(inputArr, curIndex, temperature, curClothes)
        {
        }

        public override bool IsFail()
        {
            var curValue = int.Parse(inputArray[currentIndex]);
            if (currentIndex == 1 && curValue != 8)
            {
                return true;
            }
            return base.IsFail();
        }
    }
}
