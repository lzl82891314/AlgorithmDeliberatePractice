namespace practice
{
    public static class Sort
    {
        public static void QuickSort(this int[] array, int start, int end)
        {
            if (start >= end) return;
            var pivot = Partition(array, start, end);
            array.QuickSort(start, pivot - 1);
            array.QuickSort(pivot + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            var count = start;
            for (var i = start; i < end; i++)
            {
                if (array[i] < array[end])
                {
                    if (count != i)
                    {
                        var temp1 = array[count];
                        array[count] = array[i];
                        array[i] = temp1;
                    }
                    count++;
                }
            }
            var temp2 = array[count];
            array[count] = array[end];
            array[end] = temp2;
            return count;
        }
    }
}
