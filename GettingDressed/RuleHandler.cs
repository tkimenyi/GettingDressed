using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    public static class RuleHandler
    {
        // using the chain of responsibiliy design pattern
        // http://www.dofactory.com/net/chain-of-responsibility-design-pattern


        public static bool Execute(string[] inputArr, int curIndex, string temperature, List<string> curClothes)
        {
            // set up our rules
            var removePjsRule = new RemovePJRule(inputArr, curIndex, temperature, curClothes);
            var beforeLeaving = new BeforeLeavingRule(inputArr, curIndex,temperature,curClothes);
            var duplicateItem = new DuplicateItemRule(inputArr, curIndex, temperature, curClothes);
            var leaveHouseLast = new LeaveHouseLastRule(inputArr, curIndex, temperature, curClothes);
            var pantsBeforeFootwear = new PantsBeforeFootwearRule(inputArr, curIndex, temperature, curClothes);
            var shirtBeforeHeadwear = new ShirtBeforeHeadwearRule(inputArr, curIndex, temperature, curClothes);
            var socksBeforeBoots = new SocksBeforeBootsRule(inputArr, curIndex, temperature, curClothes);

            // set up the chain of rules
            removePjsRule.SetNextRule(beforeLeaving);
            beforeLeaving.SetNextRule(duplicateItem);
            duplicateItem.SetNextRule(leaveHouseLast);
            leaveHouseLast.SetNextRule(pantsBeforeFootwear);
            pantsBeforeFootwear.SetNextRule(shirtBeforeHeadwear);
            shirtBeforeHeadwear.SetNextRule(socksBeforeBoots);
            socksBeforeBoots.SetNextRule(null);

            // execute chain of rules
            return removePjsRule.IsFail();
        }
    }
}
