using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

static class ConsoleUtilities
{
    public static void WaitForKeyPress()
    {
        WriteLine("(Press any key to continue.)");
        ReadKey(true);
    }
}