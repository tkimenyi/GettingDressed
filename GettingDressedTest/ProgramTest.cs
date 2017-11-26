using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingDressed;

namespace GettingDressedTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ProcessInputTest()
        {
            // testing a valid HOT input
            string hot = "HOT 8, 6, 4, 2, 1, 7";
            string expectedHot = "Removing PJs, shorts, shirt, sunglasses, sandals, leaving house";
            string getHot = Program.ProcessInput(hot);
            Assert.AreEqual(expectedHot, getHot);

            //testing a valid COLD input
            string cold = "COLD 8, 6, 3, 4, 2, 5, 1, 7";
            string getCold = Program.ProcessInput(cold);
            string expectedCold = "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house";
            Assert.AreEqual(expectedCold, getCold);

            //testing an invalid COLD
            Assert.AreEqual("fail", Program.ProcessInput("COLD 6"));

            //no socks on a HOT day
            Assert.AreEqual("Removing PJs, shorts, fail", 
                Program.ProcessInput("HOT 8, 6, 3"));

            //can't wear two items of the same type
            Assert.AreEqual("Removing PJs, shorts, fail",
                Program.ProcessInput("HOT 8, 6, 6"));

            //make sure we have all the clothes before leaving the house
            Assert.AreEqual("Removing PJs, pants, socks, shirt, hat, jacket, fail",
                Program.ProcessInput("COLD 8, 6, 3, 4, 2, 5, 7"));
        }
    }
}
