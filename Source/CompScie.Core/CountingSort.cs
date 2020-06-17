namespace CompScie.Core
{
    public class CountingSort
    {
        public void Sort(int[] array, int max, int min)
        {
            var frequencies = new int[max - min + 1];
            var length = array.Length;
            var sorted = new int[length];

            for (var i = 0; i < length; i++)
                frequencies[array[i] - min]++;

            for (var i = 1; i < frequencies.Length; i++)
                frequencies[i] += frequencies[i - 1];

            for (var i = length - 1; i >= 0; i--)
                sorted[--frequencies[array[i] - min]] = array[i];
            
            for (var i = 0; i < length; i++)
                array[i] = sorted[i];
        }
    }
}
