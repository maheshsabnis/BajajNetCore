// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo Array Methods");

int[] arr = new int[] { 10,4,2,6,7,8,1,3,9,5 };

Console.WriteLine("Length of arr = " + arr.Length);

Console.WriteLine("Before Sort");
for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine(i +"th position = " + arr[i]);
}
Console.WriteLine();

// 1. Lets SOrt
// THis impact on the array itself and re-arrange it
Array.Sort(arr);
Console.WriteLine("After Sort");
for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine(i + "th position = " + arr[i]);
}
Console.WriteLine();
Array.Reverse(arr);
Console.WriteLine("After Reverse");
for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine(i + "th position = " + arr[i]);
}
Console.WriteLine();
string[] names = new string[] { "James Bond", "Ethan Hunt", "Jack Reacher", "Indiana Jones", "Jason Bourn", "Jack Ryan" };

Console.WriteLine("Before Sorting NAmes array");
foreach (string str in names)
{
    Console.WriteLine(str);
}
Console.WriteLine();

Console.WriteLine("After Sorting NAmes array");
Array.Sort(names);
foreach (string str in names)
{
    Console.WriteLine(str);
}
Console.WriteLine();
// Lets copy an array into other array
// AN INstance o the String Array Reference type
// THis will make sure that 'NewNAmes' will be allocated
// in memory and it can be used for processing
string[] NewNames = new string[names.Length];
Array.Copy(names, NewNames, names.Length);

Console.WriteLine("Data in NewNames");
foreach (string name in NewNames)
{
    Console.WriteLine(name);
}
Console.WriteLine();
int indexOf_4 = Array.IndexOf(arr, 4);
Console.WriteLine("Index of 4 = " + indexOf_4);


string[] matcher = new string[] { "nt", "nd","es", "an" };
foreach (string name in names)
{
    foreach (string mat in matcher)
    {
        // from 'name' read last two characters and save them in string
        // and match that string with 'mat' if matched print that 'name'

        string last = (name[name.Length-1]).ToString();
        string secondLast = (name[name.Length - 2]).ToString();
        string word = (secondLast+last).ToString();
        if (word == mat)
        {
            Console.WriteLine(name);
        }


    }
}






Console.ReadLine(); 
