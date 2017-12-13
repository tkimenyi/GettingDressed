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

            string input;
            do
            {
                Console.WriteLine("Please Enter A New Command; To Exit, Type Exit or Quit");
                input = Console.ReadLine();
                string output = (ProcessInput(input));
                Console.WriteLine(output);
            } while (input != "Exit" && input != "Quit");
           
        }
        /// <summary>
        /// method to process the input 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ProcessInput(string input)
        {
            var failMessage = "Fail. Bad Input";
            if (string.IsNullOrWhiteSpace(input)) {
                return failMessage;
            }
            var inputArray = GetInputArray(input);
            if (inputArray.Length == 0) {
                return failMessage;
            }

            var resultClothes = new List<string>();

            if (Enum.IsDefined(typeof(Temperatures), inputArray[0]))
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
            return resultClothes.Count == 0 ? failMessage : string.Join(", ", resultClothes);

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
            input = input.Replace("\"", "").Replace("\'", "");
            string[] inputArrayWithSpaces = input.Split(delimitChars);
            string[] inputArray = inputArrayWithSpaces.Where(c => !string.IsNullOrWhiteSpace(c)).ToArray();
            return inputArray;
        }
    }
}

