using System;

namespace CompScie.Core
{
    public class Generator
    {
        private static readonly Random random = new Random();

        public static int Generate(int min = 0, int max = 1) => random.Next(min, max);
    }
}
