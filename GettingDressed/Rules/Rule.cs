using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    public abstract class Rule
    {
        private Rule nextRule;
        public string[] inputArray;
        public int currentIndex;
        public string currentTemperature;
        public List<string> currentClothes;

        public Rule(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
        {
            inputArray = inputArr;
            currentIndex = curIndex;
            currentTemperature = temperature;
            currentClothes = curClothes;
        }

        public void SetNextRule(Rule next)
        {
            nextRule = next;
        }

        public virtual bool IsFail()
        {
            if (nextRule != null) {
                return nextRule.IsFail();
            }
            return false;
        }
    }
}
