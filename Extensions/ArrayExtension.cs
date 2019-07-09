namespace hnyhny.Extensions
{
    public static class ArrayExtension
    {
        public static void Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
        }
        public static T[] DeepCopy<T>(this T[] array)
            {
            var result = new T[array.Length];
            for (int index = 0; index < array.Length; index++)
                result[index] = array[index];

            return array;
        }

    }
}