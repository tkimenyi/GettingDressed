using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    /// <summary>
    /// this rule is to make sure the user have put on all items of clothing before leaving the house
    /// </summary>
    public class BeforeLeavingRule : Rule
    {

        public BeforeLeavingRule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
                    : base(inputArr, curIndex, temperature, curClothes)
        {
        }

        public override bool IsFail()
        {
            var curValue = int.Parse(inputArray[currentIndex]);
            var currentItem = new Clothes().GetClothesAt(curValue, currentTemperature);
            if (currentItem == "leaving house" && !BeforeLeaving(currentClothes, currentTemperature == "HOT"))
            {
                return true;
            }
            return base.IsFail();
        }

        /// <summary>
        /// Check if we have all the clothes necessary before leaving the house
        /// </summary>
        /// <param name="listOfClothes"></param>
        /// <param name="isHot"></param>
        /// <returns></returns>
        private bool BeforeLeaving(List<string> listOfClothes, bool isHot)
        {
            string[] coldClothes = { "Removing PJs", "boots", "hat", "socks", "shirt", "jacket", "pants" };
            string[] hotClothes = { "Removing PJs", "sandals", "sunglasses", "shirt", "shorts" };

            return isHot 
                ? new HashSet<string>(listOfClothes).SetEquals(hotClothes)
                : new HashSet<string>(listOfClothes).SetEquals(coldClothes);
        }
    }
}
