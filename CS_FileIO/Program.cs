// See https://aka.ms/new-console-template for more information
Console.WriteLine("File IO Apps");

try
{
	string filePath = @"C:\BajajNetApps\MyFile.txt";

	if (!File.Exists(filePath))
	{
		// Create a file and acquire an Access on it so that not othe object can use it for
		// other operations e.g. Read/Write/Move/Copy, etc.
		// If the file is already exist it will be overwrriten
		FileStream fs = File.Create(filePath);

		// Close the File so that other object can acces it
		fs.Close();
		fs.Dispose(); // Free the fs object

		string data = "THis is the Data written into the using File Object";

		//File.WriteAllText(filePath, data);

		File.AppendAllText(filePath, "dkjfhkaehge;rhgerhgqe'orihgoqeirghoqeirg");

		Console.WriteLine("Data is Written in File");
	}
	else
	{
		// REad Data from the File
		var fileData = File.ReadAllLines(filePath);
		foreach (string str in fileData)
		{
            Console.WriteLine($"Data frm File = {str}");
        }
		
	}

}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadLine(); 
