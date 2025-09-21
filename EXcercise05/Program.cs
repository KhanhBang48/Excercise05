internal class Excercise05
{
    static void Main(string[] args)
    {
        Ex1();
        Ex2();
    }
    /*Create a random integer values array, then create functions that:
1.to calculate the average value of array elements.
2.to test if an array contains a specific value.
3.to find the index of an array element.
4.to remove a specific element from an array.
5.to find the maximum and minimum value of an array.
6.to reverse an array of integer values.
7.to find duplicate values in an array of values.
8.to remove duplicate elements from an array.*/
    static void Ex1()
    {
        // Tạo mảng ngẫu nhiên gồm 10 phần tử trong khoảng [1..100]
        int[] numbers = CreateRandomArray(10, 1, 100);
        Console.WriteLine("Array elements: " + string.Join(", ", numbers));

        // 1. Tính trung bình
        double avg = CalculateAverage(numbers);
        Console.WriteLine("Average value = " + avg);

        // 2. Kiểm tra có chứa giá trị hay không
        Console.Write("Enter a number to search: ");
        int searchValue = int.Parse(Console.ReadLine());

        bool contains = ContainsValue(numbers, searchValue);
        Console.WriteLine("Contains " + searchValue + "-> " + contains);

        // 3. Tìm vị trí index của phần tử
        int index = FindIndex(numbers, searchValue);
        if (index != -1)
            Console.WriteLine("Index of " + searchValue + " = " + index);
        else
            Console.WriteLine(searchValue + " not found in array.");

        // 4. Xóa phần tử cụ thể
        Console.Write("Enter a number to remove: ");
        int removeValue = int.Parse(Console.ReadLine());
        int[] removedArray = RemoveElement(numbers, removeValue);
        Console.WriteLine("Array after removing " + removeValue + ": " + string.Join(", ", removedArray));

        // 5. Tìm max & min
        int max = FindMax(numbers);
        int min = FindMin(numbers);
        Console.WriteLine("Max = " + max + ", Min = " + min);

        // 6. Đảo ngược mảng
        int[] reversed = ReverseArray(numbers);
        Console.WriteLine("Reversed array: " + string.Join(", ", reversed));

        // 7. Tìm các giá trị trùng lặp
        int[] duplicates = FindDuplicates(numbers);
        if (duplicates.Length > 0)
        {
            Console.WriteLine("Duplicate values: " + string.Join(", ", duplicates));
        }
        else
        {
            Console.WriteLine("Duplicate values: None");
        }
        // 8. Xóa các phần tử trùng lặp
        int[] noDuplicates = RemoveDuplicates(numbers);
        Console.WriteLine("Array without duplicates: " + string.Join(", ", noDuplicates));
    }
    // Tạo mảng số nguyên ngẫu nhiên
    static int[] CreateRandomArray(int size, int min, int max)
    {
        Random rnd = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = rnd.Next(min, max + 1);
        }
        return arr;
    }
    // 1. Hàm tính trung bình
    static double CalculateAverage(int[] arr)
    {
        if (arr.Length == 0) return 0;
        double sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }
        return sum / arr.Length;
    }
    // 2. Hàm kiểm tra có chứa giá trị
    static bool ContainsValue(int[] arr, int value)
    {
        foreach (int num in arr)
        {
            if (num == value) return true;
        }
        return false;
    }
    // 3. Hàm tìm index
    static int FindIndex(int[] arr, int value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == value) return i; // trả về index đầu tiên tìm thấy
        }
        return -1; // không tìm thấy
    }
    // 4. Xóa phần tử
    static int[] RemoveElement(int[] arr, int value)
    {
        List<int> list = new List<int>(arr);
        list.Remove(value); // chỉ xóa lần xuất hiện đầu tiên
        return list.ToArray();
    }
    // 5. Tìm max
    static int FindMax(int[] arr)
    {
        int max = arr[0];
        foreach (int num in arr)
            if (num > max) max = num;
        return max;
    }
    // 5. Tìm min
    static int FindMin(int[] arr)
    {
        int min = arr[0];
        foreach (int num in arr)
            if (num < min) min = num;
        return min;
    }
    // 6. Đảo ngược mảng
    static int[] ReverseArray(int[] arr)
    {
        int[] reversed = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            reversed[i] = arr[arr.Length - 1 - i];
        return reversed;
    }
    // 7. Tìm giá trị trùng lặp
    static int[] FindDuplicates(int[] arr)
    {
        List<int> duplicates = new List<int>();
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in arr)
        {
            if (!seen.Add(num) && !duplicates.Contains(num))
                duplicates.Add(num);
        }
        return duplicates.ToArray();
    }
    // 8. Xóa trùng lặp
    static int[] RemoveDuplicates(int[] arr)
    {
        HashSet<int> unique = new HashSet<int>(arr);
        return new List<int>(unique).ToArray();
    }

    /*Create a C# program that
-requests 10 integers from the user and orders them by implementing the bubble sort algorithm.
-Request a sentence from the user, then ask to enter a word. Search if the word appears in the phrase using the linear search algorithm.*/
    static void Ex2()
    {
        //Bubble Sort 
        int[] arr = new int[10];
        Console.WriteLine("Enter 10 integers:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Number " + (i + 1) + ": ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Array after sorting (ascending): " + string.Join(", ", arr));

        //Linear Search 
        Console.Write("\nEnter a sentence: ");
        string sentence = Console.ReadLine();

        Console.Write("Enter a word to search: ");
        string word = Console.ReadLine();

        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        bool found = false;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Equals(word, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"The word \"{word}\" appears at position {i} in the sentence.");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine($"The word \"{word}\" was not found in the sentence.");
        }
    }
}

