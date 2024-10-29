using System;
public class BinarySearch<T> where T : IComparable<T>
{
    // تابع البحث الثنائي التكراري
    public int IterativeBinarySearch(T[] array, T value)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid].CompareTo(value) == 0)
            {
                return mid; // القيمة موجودة في منتصف المصفوفة
            }
            else if (array[mid].CompareTo(value) < 0)
            {
                left = mid + 1; // البحث في الجزء الأيمن
            }
            else
            {
                right = mid - 1; // البحث في الجزء الأيسر
            }
        }

        return -1; // القيمة غير موجودة في المصفوفة
    }

    // تابع البحث الثنائي العودي
    public int RecursiveBinarySearch(T[] array, T value)
    {
        return RecursiveBinarySearch(array, value, 0, array.Length - 1);
    }

    private int RecursiveBinarySearch(T[] array, T value, int left, int right)
    {
        if (left > right)
        {
            return -1; // القيمة غير موجودة في المصفوفة
        }

        int mid = left + (right - left) / 2;

        if (array[mid].CompareTo(value) == 0)
        {
            return mid; // القيمة موجودة في منتصف المصفوفة
        }
        else if (array[mid].CompareTo(value) < 0)
        {
            return RecursiveBinarySearch(array, value, mid + 1, right); // البحث في الجزء الأيمن
        }
        else
        {
            return RecursiveBinarySearch(array, value, left, mid - 1); // البحث في الجزء الأيسر
        }
    }
}

// Example مثال على الصفوف
public class Program
{
    public static void Main()
    {
        BinarySearch<int> binarySearch = new BinarySearch<int>();
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int iterativeResult = binarySearch.IterativeBinarySearch(array, 5);
        Console.WriteLine("النتيجة باستخدام الأسلوب التكراري: " + 
            (iterativeResult != -1 ? $"القيمة موجودة في الفهرس {iterativeResult}" : "القيمة غير موجودة"));

        int recursiveResult = binarySearch.RecursiveBinarySearch(array, 5);
        Console.WriteLine("النتيجة باستخدام الأسلوب العودي: " + 
            (recursiveResult != -1 ? $"القيمة موجودة في الفهرس {recursiveResult}" : "القيمة غير موجودة"));
    }
}

