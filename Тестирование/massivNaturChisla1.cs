using System;
class GFG
{
    public static void Main()
    {
        int[] arr = { 2, 3, 3, 5, 4, 5, 2, 4, 3, 5, 2, 4, 4, 2 };
        int n = arr.Length;
        //Поиск элемента, встречаемого нечетное количество раз

        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res = res ^ arr[i];
        }
        Console.WriteLine($"\n" + res);
    }

}
