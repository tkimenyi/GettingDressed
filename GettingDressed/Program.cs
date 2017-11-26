using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingDressed
{
    public static class Program
    {
        private enum Temperatures { HOT, COLD }

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(ProcessInput(input));
            Console.ReadLine();
        }

        public static string ProcessInput(string input)
        {

            var resultClothes = new List<string>();
            var inputArray = GetInputArray(input);
            if (Enum.IsDefined(typeof(Temperatures), inputArray[0]))
            {
                var temperature = inputArray[0];
                var clothes = new Clothes();
                for (int i = 1; i < inputArray.Length; i++)
                {
                    var value = int.Parse(inputArray[i]);
                    var item = clothes.GetClothesAt(value, temperature);

                    //check that we are removing the PJ's first
                    if (i == 1 && value != 8) {
                        item = "fail";
                    }

                    // check that we are leaving the house at last
                    if (i == input.Length - 1 && value != 7) {
                        item = "fail";
                    }

                    // check that item has already been put on
                    if (resultClothes.Contains(item)) {
                        item = "fail";
                    }

                    // socks must be put on before footwear
                    if (item == "boots" && !resultClothes.Contains("socks")) {
                        item = "fail";
                    }

                    // pants must be put on before footwear
                    if (
                        (item == "boots" && !resultClothes.Contains("pants")) ||
                        (item == "sandals" && !resultClothes.Contains("shorts"))
                        ) {
                        item = "fail";
                    }
                    // the shirt must be put on before a headwear or jacket
                    if (
                        (item == "jacket" || item == "hat" || item == "sunglasses")
                        && !resultClothes.Contains("shirt")
                        )
                    {
                        item = "fail";
                    }

                    // todo make sure we have put on everything before leaving
                    if (item == "leaving house" && !BeforeLeaving(resultClothes, temperature == "HOT"))
                    {
                        item = "fail";
                    }

                    resultClothes.Add(item);
                    if (item == "fail")
                    {
                        break;
                    }

                }
            }
            return resultClothes.Count == 0 ? "fail" : string.Join(", ", resultClothes);

        }
        /// <summary>
        /// This method makes sure that we can accept inputs that are separated by a comma and space
        /// and inputs that are only separated by a comma.
        /// There must be a space between the temperature and the inputs though.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] GetInputArray(string input)
        {
            char[] delimitChars = { ' ', ',' };
            string[] inputArrayWithSpaces = input.Split(delimitChars);
            string[] inputArray = inputArrayWithSpaces.Where(c => !string.IsNullOrWhiteSpace(c)).ToArray();
            return inputArray;
        }
        /// <summary>
        /// Check if we have all the clothes necessary vbefore leaving the house
        /// </summary>
        /// <param name="listOfClothes"></param>
        /// <param name="hot"></param>
        /// <returns></returns>
        public static bool BeforeLeaving(List<string> listOfClothes, bool hot)
        {
            string[] coldClothes = {"Removing PJs", "boots", "hat", "socks", "shirt", "jacket", "pants" };
            string[] hotClothes = { "Removing PJs", "sandals", "sunglasses", "shirt", "shorts" };
            var result = false;
           
            if (hot)
            {
                result = new HashSet<string>(listOfClothes).SetEquals(hotClothes);

            } else {
                result = new HashSet<string>(listOfClothes).SetEquals(coldClothes);
            }
            return result;
        }
    }
}

