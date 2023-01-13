// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Extension");
StringOperations op = new StringOperations();

string str = ".NET Core is GReat";

Console.WriteLine($"Length of {str} is = {op.GetLength(str)}");
Console.WriteLine($" Upper case of {str} is = {op.Process(str, 'u')}" );
Console.WriteLine($" Lower case of {str} is = {op.Process(str, 'L')}");
Console.WriteLine($" Reverse of {str} is = {op.ReverseExt(str)}");
Console.WriteLine($" Nuber of Blankspaces in {str} is = {str.GetWhiteSpaces()}");
Console.ReadLine();


public sealed class StringOperations
{ 
    public int GetLength(string str)
    {
        return str.Length;
    }
    public string Process(string str, char option)
    {
        if(option == 'u' || option == 'U'  )
            return str.ToLower();

        if (option == 'l' || option == 'L')
            return str.ToUpper();
        return str;

    }
}

// Writing Extension Method
// Rules
// 1. The class that contains extension method MUST be static
// 2. The method which will be used as extension methos MUST be static
// 3. The First Parameter of the method MUST be 'this' referered reference
// of the class for which this method will be used as extension

public static class StringOperationsExtension
{
    public static string ReverseExt(this StringOperations op, string str)
    {
        string reverse = string.Empty;
        for (int i = str.Length - 1; i >=0; i--)
        {
            reverse += str[i];
        }

        return reverse;
    }

    public static int GetWhiteSpaces(this string str)
    {
        int whiteSpaceCount = 0;
        foreach (char c in str)
        {
            if (Char.IsWhiteSpace(c))
            {
                whiteSpaceCount++;
            }
        }
        return whiteSpaceCount;
    }
}


