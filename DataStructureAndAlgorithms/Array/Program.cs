using System;

namespace Array
{
    class Program
    {
        static bool IsPaired(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((i % 2 == 0 && input[i] % 2 == 0) || (i % 2 == 1 && input[i] % 2 == 1))
                    return false;
            }
            return true;
        }

        static int maxDistance(int input)
        {
            int minFactor = 0, maxFactor = 0;
            for (int i = 2; i <= input / 2; i++)
            {
                if (input % i == 0)
                {
                    if (minFactor == 0)
                        minFactor = i;
                    maxFactor = i;
                }
            }
            return (minFactor == 0) ? -1 : (maxFactor - minFactor);
        }

        static void updateMileageCounter(int[] a, int miles)
        {
            for (int i = 0; i < miles; i++)
            {
                increaseNumber(a, 0);
            }
        }

        static void increaseNumber(int[] a, int index)
        {
            if (index >= a.Length)
                return;
            a[index]++;
            if (a[index] > 9)
            {
                a[index] = 0;
                increaseNumber(a, index + 1);
            }
        }

        static int isHollow(int[] a)
        {
            int nonZeroNumberCount = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != 0)
                    nonZeroNumberCount++;
                else
                    break;
            }

            int zeroCount = 0;
            int followingNonZeroNumberIndex = a.Length;
            for (int i = nonZeroNumberCount; i < a.Length; i++)
            {
                if (a[i] == 0)
                {
                    zeroCount++;
                }
                else
                {
                    followingNonZeroNumberIndex = i;
                    break;
                }
            }

            if (zeroCount < 3)
                return 0;
            if ((a.Length - followingNonZeroNumberIndex) != nonZeroNumberCount)
                return 0;
            for (int i = followingNonZeroNumberIndex; i < a.Length; i++)
            {
                if (a[i] == 0)
                    return 0;
            }
            return 1;
        }

        static int isConsectiveFactored(int n)
        {
            if (n <= 0)
                return 0;
            for (int i = 2; i <= n / 2; i++)
            {
                if ((n % i == 0) && (n % (i + 1) == 0))
                    return 1;
            }
            return 0;
        }

        static int nextPerfectSquare(int n)
        {
            if (n < 0)
                return 0;
            double sqrt = Math.Sqrt(n);
            double ceiling = Math.Ceiling(sqrt);
            if (ceiling == sqrt)
                ceiling++;
            return (int)(ceiling * ceiling);
        }

        static int nUpCount(int[] a, int n)
        {
            int upCount = 0;
            int partialSum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int nextPartialSum = partialSum + a[i];
                if (partialSum <= n && nextPartialSum > n)
                    upCount++;
                partialSum = nextPartialSum;
            }
            return upCount;
        }

        static bool isPrime(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= n / 2; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        static int primeCount(int start, int end)
        {
            int count = 0;
            for (int i = start; i <= end; i++)
            {
                if (isPrime(i))
                    count++;
            }
            return count;
        }

        static int isMadhavArray(int[] a)
        {
            int length = 2;
            int start = 1, end = 2;
            while (end < a.Length)
            {
                int sum = 0;
                for (int i = start; i <= end; i++)
                    sum += a[i];

                if (a[0] != sum)
                {
                    return 0;
                }
                else
                {
                    length++;
                    start = end + 1;
                    end = start + (length - 1);
                }
            }
            if (start < a.Length && end >= a.Length)
                return 0;
            return 1;
        }

        static int isInertial(int[] a)
        {
            int minOddValue = int.MaxValue;
            int maxValue = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 1)
                {
                    if (a[i] < minOddValue)
                        minOddValue = a[i];
                }
                if (a[i] > maxValue)
                    maxValue = a[i];
            }
            if (minOddValue == int.MaxValue)
                return 0; // Could not find odd value
            if (maxValue % 2 == 1)
                return 0; // Max value which is odd

            int maxEvenValue = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0 && a[i] > maxEvenValue && a[i] < maxValue)
                    maxEvenValue = a[i];
            }
            if (minOddValue < maxEvenValue)
                return 0;
            return 1;
        }

        static string TestBoolFunction(bool result, bool expect)
        {
            return (result == expect) ? "PASS" : "FAILED";
        }

        static string TestIntFunction(int result, int expect)
        {
            return (result == expect) ? "PASS" : "FAILED";
        }

        static string TestArray(int[] result, int[] expect)
        {
            for (int i = 0; i < result.Length; i++)
                if (result[i] != expect[i])
                    return "FAILED";
            return "PASS";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Case 1.1: " + TestBoolFunction(IsPaired(new int[] { 1, 4, 7 }), true));
            Console.WriteLine("Case 1.2: " + TestBoolFunction(IsPaired(new int[] { 1, 4, 45, 6, 12 }), false));
            Console.WriteLine("Case 1.3: " + TestBoolFunction(IsPaired(new int[] { 1, 4, 45, 6, 11, -8 }), true));

            Console.WriteLine("Case 2.1: " + TestIntFunction(maxDistance(12), 4));
            Console.WriteLine("Case 2.2: " + TestIntFunction(maxDistance(49), 0));
            Console.WriteLine("Case 2.3: " + TestIntFunction(maxDistance(0), -1));
            Console.WriteLine("Case 2.4: " + TestIntFunction(maxDistance(1), -1));
            Console.WriteLine("Case 2.5: " + TestIntFunction(maxDistance(2), -1));
            Console.WriteLine("Case 2.6: " + TestIntFunction(maxDistance(3), -1));
            Console.WriteLine("Case 2.7: " + TestIntFunction(maxDistance(4), 0));
            Console.WriteLine("Case 2.8: " + TestIntFunction(maxDistance(5), -1));
            Console.WriteLine("Case 2.9: " + TestIntFunction(maxDistance(6), 1));
            Console.WriteLine("Case 2.10: " + TestIntFunction(maxDistance(13), -1));

            int[] case3 = new int[] { 8, 9, 9, 5, 0 };
            updateMileageCounter(case3, 1);
            Console.WriteLine("Case 3.1: " + TestArray(case3, new int[] { 9, 9, 9, 5, 0 }));
            case3 = new int[] { 8, 9, 9, 5, 0 };
            updateMileageCounter(case3, 2);
            Console.WriteLine("Case 3.2: " + TestArray(case3, new int[] { 0, 0, 0, 6, 0 }));
            case3 = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            updateMileageCounter(case3, 1);
            Console.WriteLine("Case 3.3: " + TestArray(case3, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            case3 = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            updateMileageCounter(case3, 13);
            Console.WriteLine("Case 3.4: " + TestArray(case3, new int[] { 2, 1, 0, 0, 0, 0, 0, 0, 0, 0 }));

            Console.WriteLine("Case 4.1: " + TestIntFunction(isHollow(new int[] { 1, 2, 0, 0, 0, 3, 4 }), 1));
            Console.WriteLine("Case 4.2: " + TestIntFunction(isHollow(new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 2, 1, 2, 18 }), 1));
            Console.WriteLine("Case 4.3: " + TestIntFunction(isHollow(new int[] { 1, 2, 0, 0, 3, 4 }), 0));
            Console.WriteLine("Case 4.4: " + TestIntFunction(isHollow(new int[] { 1, 2, 0, 0, 0, 3, 4, 5 }), 0));
            Console.WriteLine("Case 4.5: " + TestIntFunction(isHollow(new int[] { 3, 8, 3, 0, 0, 0, 3, 3 }), 0));
            Console.WriteLine("Case 4.6: " + TestIntFunction(isHollow(new int[] { 1, 2, 0, 0, 0, 3, 4, 0 }), 0));
            Console.WriteLine("Case 4.7: " + TestIntFunction(isHollow(new int[] { 0, 1, 2, 0, 0, 0, 3, 4 }), 0));
            Console.WriteLine("Case 4.8: " + TestIntFunction(isHollow(new int[] { 0, 0, 0 }), 1));

            Console.WriteLine("Case 5.1: " + TestIntFunction(isConsectiveFactored(24), 1));
            Console.WriteLine("Case 5.2: " + TestIntFunction(isConsectiveFactored(105), 0));
            Console.WriteLine("Case 5.3: " + TestIntFunction(isConsectiveFactored(90), 1));
            Console.WriteLine("Case 5.4: " + TestIntFunction(isConsectiveFactored(23), 0));
            Console.WriteLine("Case 5.5: " + TestIntFunction(isConsectiveFactored(15), 0));
            Console.WriteLine("Case 5.6: " + TestIntFunction(isConsectiveFactored(2), 0));
            Console.WriteLine("Case 5.7: " + TestIntFunction(isConsectiveFactored(0), 0));
            Console.WriteLine("Case 5.8: " + TestIntFunction(isConsectiveFactored(-12), 0));

            Console.WriteLine("Case 6.1: " + TestIntFunction(nextPerfectSquare(6), 9));
            Console.WriteLine("Case 6.2: " + TestIntFunction(nextPerfectSquare(36), 49));
            Console.WriteLine("Case 6.3: " + TestIntFunction(nextPerfectSquare(0), 1));
            Console.WriteLine("Case 6.4: " + TestIntFunction(nextPerfectSquare(-5), 0));

            Console.WriteLine("Case 7.1: " + TestIntFunction(nUpCount(new int[] { 2, 3, 1, -6, 8, -3, -1, 2 }, 5), 3));
            Console.WriteLine("Case 7.2: " + TestIntFunction(nUpCount(new int[] { 6, 3, 1 }, 6), 1));
            Console.WriteLine("Case 7.3: " + TestIntFunction(nUpCount(new int[] { 1, 2, -1, 5, 3, 2, -3 }, 20), 0));

            Console.WriteLine("Case 8.1: " + TestIntFunction(primeCount(10, 30), 6));
            Console.WriteLine("Case 8.2: " + TestIntFunction(primeCount(11, 29), 6));
            Console.WriteLine("Case 8.3: " + TestIntFunction(primeCount(20, 22), 0));
            Console.WriteLine("Case 8.4: " + TestIntFunction(primeCount(1, 1), 0));
            Console.WriteLine("Case 8.5: " + TestIntFunction(primeCount(5, 5), 1));
            Console.WriteLine("Case 8.6: " + TestIntFunction(primeCount(6, 2), 0));
            Console.WriteLine("Case 8.7: " + TestIntFunction(primeCount(-10, 6), 3));

            Console.WriteLine("Case 9.1: " + TestIntFunction(isMadhavArray(new int[] { 2, 1, 1 }), 1));
            Console.WriteLine("Case 9.2: " + TestIntFunction(isMadhavArray(new int[] { 2, 1, 1, 4, -1, -1 }), 1));
            Console.WriteLine("Case 9.3: " + TestIntFunction(isMadhavArray(new int[] { 6, 2, 4, 2, 2, 2, 1, 5, 0, 0 }), 1));
            Console.WriteLine("Case 9.4: " + TestIntFunction(isMadhavArray(new int[] { 18, 9, 10, 6, 6, 6 }), 0));
            Console.WriteLine("Case 9.5: " + TestIntFunction(isMadhavArray(new int[] { -6, -3, -3, 8, -5, -4 }), 0));
            Console.WriteLine("Case 9.6: " + TestIntFunction(isMadhavArray(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, -2, -1 }), 1));
            Console.WriteLine("Case 9.7: " + TestIntFunction(isMadhavArray(new int[] { 3, 1, 2, 3, 0 }), 0));

            Console.WriteLine("Case 10.1: " + TestIntFunction(isInertial(new int[] { 1 }), 0));
            Console.WriteLine("Case 10.2: " + TestIntFunction(isInertial(new int[] { 2 }), 0));
            Console.WriteLine("Case 10.3: " + TestIntFunction(isInertial(new int[] { 1, 2, 3, 4 }), 0));
            Console.WriteLine("Case 10.4: " + TestIntFunction(isInertial(new int[] { 1, 1, 1, 1, 1, 1, 2 }), 1));
            Console.WriteLine("Case 10.5: " + TestIntFunction(isInertial(new int[] { 2, 12, 4, 6, 8, 11 }), 1));
            Console.WriteLine("Case 10.6: " + TestIntFunction(isInertial(new int[] { 2, 12, 12, 4, 6, 8, 11 }), 1));
            Console.WriteLine("Case 10.7: " + TestIntFunction(isInertial(new int[] { -2, -4, -6, -8, -11 }), 0));
            Console.WriteLine("Case 10.8: " + TestIntFunction(isInertial(new int[] { 2, 3, 5, 7 }), 0));
            Console.WriteLine("Case 10.9: " + TestIntFunction(isInertial(new int[] { 2, 4, 6, 8, 10 }), 0));
        }
    }
}
