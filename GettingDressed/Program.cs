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
        /// <summary>
        /// method to process the input 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) {
                return "Fail. Bad Input";
            }
            var resultClothes = new List<string>();
            var inputArray = GetInputArray(input);
            if (Enum.IsDefined(typeof(Temperatures), inputArray?[0]))
            {
                var temperature = inputArray[0];
                var clothes = new Clothes();
                for (int i = 1; i < inputArray.Length; i++)
                {
                    var value = int.Parse(inputArray[i]);
                    var item = RuleHandler.IsFail(inputArray, i, temperature, resultClothes) 
                            ? "fail" 
                            : clothes.GetClothesAt(value, temperature);
                    
                    resultClothes.Add(item);
                    if (item == "fail")
                    {
                        break;
                    }

                }
            }
            return resultClothes.Count == 0 ? "Fail. Bad Input" : string.Join(", ", resultClothes);

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
    }
}

