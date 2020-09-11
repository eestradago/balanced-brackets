using System;

namespace coding
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("3*(z*(a-(x+3))/(y))");
            Console.WriteLine("balanced = {0}", balanced("3*(z*(a-(x+3))/(y))").ToString());
            Console.WriteLine("{[(])}");
            Console.WriteLine("balanced = {0}", balanced("{[(])}").ToString());
            Console.WriteLine("{{[[(())]]}}");
            Console.WriteLine("balanced = {0}", balanced("{{[[(())]]}}").ToString());
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
            return isEnclosed(input);
        }

        static bool isEnclosed(string input, bool result = true)
        {

            //input contains any bracket
            if (!(input.Contains("{") || input.Contains("[")||input.Contains("(") 
            || input.Contains("]")||input.Contains(")")|| input.Contains("}") )){
                return result;
            }

            // find most inner bracket
            int loB = Math.Max(input.LastIndexOf("["), Math.Max(input.LastIndexOf("{"), input.LastIndexOf("(")));
            string loStrB = input.Substring(loB, 1);
            string lcstrB;
            //determine corresponding closing bracket
            switch (loStrB)
            {
                case "[": lcstrB = "]"; break;
                case "{": lcstrB = "}"; break;
                case "(": lcstrB = ")"; break;
                default: lcstrB = "#"; break;
            }

            // select the trailing string from the most inner bracket
            string trail = input.Substring(loB + 1);

            // find most outer closing bracket
            int tfoB = trail.IndexOf("]") == -1 ? trail.Length : trail.IndexOf("]");
            int tfoC = trail.IndexOf("}") == -1 ? trail.Length : trail.IndexOf("}");
            int tfoP = trail.IndexOf(")") == -1 ? trail.Length : trail.IndexOf(")");
            int fcB = Math.Min(tfoB, Math.Min(tfoC, tfoP));
            string fcStrB = trail.Substring(fcB, 1);


            if (fcB == -1)
            {
                return false;
            }
            else if (lcstrB == fcStrB)
            {
                if (input.Length <= 2)
                {
                    return true;
                }
                else
                {
                    string new_input = input.Remove(loB,(loB+1)+(fcB+1)-loB);
                    return isEnclosed(new_input, true);                    
                }
            }
            else
            {
                return false;
            }
        }
    }
}
