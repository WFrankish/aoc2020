using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Inputs
{
    public static class InputHelper
    {
        public static IReadOnlyCollection<string> Open(int dayNumber)
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var fileName = $"day{dayNumber:00}.txt";

            var fullPath = Path.Combine(directory, fileName);

            return File.ReadAllLines(fullPath);
        }
    }
}
