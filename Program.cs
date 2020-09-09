using System;

namespace coding
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "[()]{}[{(())]}()";
            Console.WriteLine(input);
            Console.WriteLine("balanced = {0}", balanced(input).ToString());
        }


        static bool balanced(string input)
        {

            int size = input.Length;

            // check opening vs closing count
            if ((size - input.Replace("(", "").Length) != (size - input.Replace(")", "").Length))
            {
                // 4 vs 4
                return false;
            }
            if ((size - input.Replace("[", "").Length) != (size - input.Replace("]", "").Length))
            {
                return false;
            }
            if ((size - input.Replace("{", "").Length) != (size - input.Replace("}", "").Length))
            {
                return false;
            }

            //check closing for every open

            // get opening
            string[] openB = input.Split("[");
            string[] openC = input.Split("{");
            string[] openP = input.Split("(");

            for (int i = 1; i < openC.Length; i++)
            {
                string[] closeC = openC[i].Split("}");
                if (closeC.Length == 1 && closeC[0] != "")
                {
                    return false;
                }
            }
            for (int i = 1; i < openP.Length; i++)
            {
                string[] closeP = openP[i].Split(")");
                if (closeP.Length == 1 && closeP[0] != "")
                {
                    return false;
                }
            }
            for (int i = 1; i < openB.Length; i++)
            {
                string[] closeB = openB[i].Split("]");
                if (closeB.Length == 1 && closeB[0] != "")
                {
                    return false;
                }
            }

            return true;
        }
    }
}
