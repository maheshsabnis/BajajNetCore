// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO String");
// An array of 'Char'
string str = "Mahesh Rameshrao Sabnis";

Console.WriteLine("Length of " + str + " is = " + str.Length);
Console.WriteLine("Upper Case of " + str + " is = " + str.ToUpper());
Console.WriteLine("LOwer Case of " + str + " is = " + str.ToLower());

// Get the 0 based inndex of 'e'

Console.WriteLine("Index of 'e' in " + str + " is = " + str.IndexOf('e'));

// Get the 0 based index of 'e' fro Last Ocurance
Console.WriteLine("Last Index of 'e' in " + str + " is = " + str.LastIndexOf('e'));
Console.WriteLine();
// indexed based
int count = 0;
for (int i = 0; i < str.Length; i++)
{
    // checking for 'blankspaces'
    
    if (str[i]==' ')
    {
        Console.WriteLine(str[i]);
        count++;
    }
    
}
Console.WriteLine("No. of blankspaces in " + str + " = " + count);


// use the foreach item based iteration
// The recommended way to find out characters TYpes (digits, whitespaces)
// in string use 'Char' type

count = 0;
foreach (char c in str)
{
    if (Char.IsWhiteSpace(c))
    {
        Console.WriteLine(c);
        count++;
    }
    
}
Console.WriteLine("No. of blankspaces in " + str + " = " + count);









Console.ReadLine();
