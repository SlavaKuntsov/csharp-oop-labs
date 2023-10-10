namespace _3
{
    public partial class StatisticOperation<T>
    {
        public static int Sum(Set<int> set)
        {
            int sum = 0;

            foreach (int number in set)
                sum += number;

            return sum;
        }
        public static int Count(Set<T> set)
        {
            int count = 0;

            foreach (T number in set)
                count++;
            
            return count;
        }
        public static int Difference(Set<int> set)
        {

            int min = set.Min();
            int max = set.Max();

            int diff = max - min;

            return diff;
        }
    }
}
