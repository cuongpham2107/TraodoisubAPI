using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momo
{
    public static class Extensions
    {
        public static void WriteLine(string body, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(body);
            Console.ResetColor();
        }
    }
}
