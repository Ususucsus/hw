using System;

namespace Task13
{
    class Task13
    {
        private static void BubbleSort(float[] arrFloats)
        {
            for (var i = 0; i < arrFloats.Length; ++i)
            {
                for (var j = 1; j < arrFloats.Length - i; ++j)
                {
                    if (arrFloats[j - 1] > arrFloats[j])
                    {
                        SwapFloats(ref arrFloats[j - 1], ref arrFloats[j]);
                    }
                }
            }
        }

        private static void SwapFloats(ref float a, ref float b)
        {
            var t = a;
            a = b;
            b = t;
        }

        static void Main(string[] args)
        {
            var testArray = new float[10];
            var random = new Random();

            for (var i = 0; i < 10; ++i)
            {
                testArray[i] = random.Next(100);
                Console.WriteLine(testArray[i]);
            }

            BubbleSort(testArray);

            Console.WriteLine("Sorted:");
            foreach (var f in testArray)
            {
                Console.WriteLine(f);
            }
        }
    }
}
