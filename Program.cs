using System.Globalization;
using System.Threading;

namespace NtypeMatrix
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Menu m = new Menu();
            m.Run();
        }
    }
}
