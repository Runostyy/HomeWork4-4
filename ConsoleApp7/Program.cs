using System;

namespace StaticClassExample
{
    // Статичний клас з методами пошуку
    public static class ArrayHelper
    {
        // Метод лінійного пошуку максимального і мінімального елементів в масиві
        public static (int min, int max) FindMinMax(int[] array)
        {
            int min = array[0];
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }

                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return (min, max);
        }

        // Метод для двійкового пошуку елемента в відсортованому масиві
        public static int BinarySearch(int[] sortedArray, int target)
        {
            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (sortedArray[middle] == target)
                {
                    return middle; // Повертаємо індекс знайденого елементу
                }
                else if (sortedArray[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1; // Якщо елемент не знайдений, повертаємо -1
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Масив для лінійного пошуку
            int[] array = { 4, 5, 2, 3, 8, 7, 6, 1 };

            // Викликаємо метод для пошуку мінімального та максимального елементів
            var (min, max) = ArrayHelper.FindMinMax(array);
            Console.WriteLine($"Мінімальний елемент: {min}");
            Console.WriteLine($"Максимальний елемент: {max}");

            // Масив для двійкового пошуку (масив повинен бути відсортований)
            int[] sortedArray = new int[100];
            for (int i = 0; i < sortedArray.Length; i++)
            {
                sortedArray[i] = i + 1; // Заповнення масиву числами від 1 до 100
            }

            // Шукаємо елемент 73 у відсортованому масиві
            int target = 73;
            int index = ArrayHelper.BinarySearch(sortedArray, target);

            if (index != -1)
            {
                Console.WriteLine($"Елемент {target} знайдено на індексі {index}.");
            }
            else
            {
                Console.WriteLine($"Елемент {target} не знайдено.");
            }

            Console.ReadKey();
        }
    }
}
