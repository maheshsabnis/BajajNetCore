# C# Iterations
1. for..loop
	- Indexed based
2. foreach..loop
	- object / item based in collection
	- THis starts reading the collection till end-of-collection does not occur
	- No Indexex are needed and no condition is required to evaluate the loop
	- more powerful
3. while..loop
	- COndition BAse
4. do..while..loop
	- Condition based but executes at leas once

# COnditions
- if statement
- if..else
- if..else..if 
- if ... if ... if , nested if
- switch..case..default

# OOPs
- DEfault Access Specifier of the class is 'internal'
- Class can contain Multiple COnstrctors with different parameters
	- THis is known as 'COnstructor Overloading'
- The class must be instantiated then only, the memory will be allocated to it
	- SYntax
		- ClassNAme obj = new ClassNAme();
			- Initialize all Data Mamers of the class
			- All Methods will be allocated in 'Code-Segment'
- Methods
	- Reusable functions those are responsible to Abstract the class behavior
	- The may habe input Parameters and also can return data using Output Parameters 
	- The method that does not return anything is define as 'void'
	- Method parameters
		- pass by val
			- int x,y;
			- Define method	
				- void m1(int a,int b)
			- call method
				- m1(x,y);
			- x and y are actual parameters and a,b are formal parameters

# Generics
- Typesafe collections to stre data in-memory
- System.Collections.Generics namespace
	- List<T>
	- LinkedList<T>
	- Statck<T>
	- Queue<T>
	- DIctionary<T,U>
- THe 'T' is a TYpe-Parameter aka the data type for which the current class will be used
- ALl These classes implements  'IEnumerable<T>' interface
	- This is used to read each entry from the Generic Collection
	- This is possible using foreach..lopp
- We can use Language-INtegrated-Query (LINQ)	to read data from Collection using following aprrocahes
	- Combination of Extension Methods having following two input paramters to them
		- Action | Action<T> delegate
			- The Action delegate as void as output parameter
			- The Action<T> is the delegate having T as input parameter 
		- Func<T,U> delegate 
			- T is type and U is condition to evaluate the expression
	- Extension Methods						- Keywords
		- Select()							- select
		- Where()							- where
		- OrderBy()							- orderby 
		- OrderByDescending()				- orderby [proeprty-name] desc
		- GroupBy()							- group [property-name] by 
		- ...

	- Scalar Methods
		- Sum(), Max(), Min(), Average()
	- Method to Take and Skip records based on its indexed
		- Take(), Skip()
		- TakeAny(), SkipAny()
- LINQ to Object aka OLinq
	- Executing Queries over the Collection (COllection / Generics)
- LINQ to XML aka XLinq
	- Executing LINQ on the Xml files
- LINQ to Data aka DLinq
	- Executing LINQ queries on Data BAse programming
		- Included in Entity Framework Core aka (EF Core)

- Handling Errors using 'Exception-Handling'
	- try{...}catch() {} finally {}
		- The 'Exception' is a Highest-Level class for Error Handling using 'System' Namespace
		- NuffReferenceException
		- SqlException
		- FileNotFoundException
		- InvalidOPerationException
		-....
	- Mandatory blocks
		- try{...}.catch(){...}
		- finally is always executed
	- Multiple catch for one try{...} block
		- try {......}catch(ex1){....}catch(ex2){....}
			- Make ure that the 'Exception' is used in last catch(){...} block
	- Nested try{.. try {... try {....}}}catch(){....}
	- COditionaly exception can be thrown using 'throw' keword
		- if(condition) {throw new Exception("");}
 	
		
# USing Files
- System.IO namespace
	- File
		- Contains static methdo for 
			- CReate, Read, Append, Copy, Move, Delete
	- FileInfo 
		- COntains methods similar with the File class but instance is required
			- FileInfo f = new FileINfo();
	- Directory and DirectoryInfo
		- Managing directories
	- The 'Stream'
		- Work over a stream of data that will be Read and Written from and to following
			- FileStream
				- Text and Binary Files
			- MemoryStream
				- Data stored in Memory
			- NetworkStream
				- Share Stream Data Across Network
				- E.g.
					- File Upload and Download
		- Reader and Writer classes
			- StreaReader and StreamWriter
			- TextReader and TextWriter
			- BinaryReader and BinaryWriter
		- All these are 'UnManaged' objects, the CLR or dotnet.exe is not resposnible for controlling them

# Using EF COre
- Install FOllowig PAckages
	- Microsoft.EntityFrameworkCore
		- BAse Package for Using EF COre in Appliation
		- Provide classes for Establishing Conenction with DB
	- Microsoft.EntityFrameworkCore.SqlServer
		- Use for Managing Operations with SQL Server
	- Microsoft.EntityFrameworkCore.Ralational
		- Used for Managing DB Operations (aka Transactions) based on Ralationship across Tables
	- Microsoft.EntityFrameworkCore.Tools
		- Provides Command-Line Tool to generate Classes from Tables
	- Microsoft.EntityFrameworkCore.Desgin
		- USed to make sure that the Geerated Class DEsign mapped with the actual Table DEsign with Ralations
- Installing Packages for the project
	- using Visual Studio
		- Right-CCLick on Project NAme --> Select Managed NuGet PAckagegs--> THis will open the table for NuGet Pakage --> Search Package from the Search TextBox --> Once the package in DIsplayed -> Select its version and install it
	- USing ommand LIne Interface (CLI)
		- OPen Command Prompt
		- Navigate to the Project Folder
		- Run the Comman
			- dotnet add package [PACKAGE-NAME] -v [VERSION-NO]
			- e.g.
				- dotnet add package Microsoft.EntityFrameworkCore -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.Tools -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.Relational -v 6.0.11

- Generate Model classes aka Entity classes from Database (Db-First Approach)
	- Make sure that the dotnet ef core in installed on the machine
		- dotnet tool install --global dotnet-ef
	- Run the following from the Project path
		- dotnet ef dbcontext scaffold "[CONNECTION-STRING]" Microsoft.EntityFrameworkCore.SqlServer -o Models
		- e.g.
			- dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=BajajCompany;Integrated Security=SSPI" Microsoft.EntityFrameworkCore.SqlServer -o Models
				- The project will be added with 'Models' flder with classes mapped with all tables from BajajCompany database as well as the DbContext class which will be used for Connection Management, Table Mapping with classes and Transactions 

			- dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=BajajCompany;Integrated Security=SSPI" Microsoft.EntityFrameworkCore.SqlServer -o Models

			- dotnet ef dbcontext scaffold "Data Source=.\SqlExpress;Initial Catalog=BajajCompany;User Id=sa;Password=P@ssw0rd_" Microsoft.EntityFrameworkCore.SqlServer -o Models

			- SQL Express w/o User id and Password
			- dotnet ef dbcontext scaffold "Data Source=.\SqlExpress;Initial Catalog=BajajCompany;Integrated Security=SSPI" Microsoft.EntityFrameworkCore.SqlServer -o Models
	- EF Core Object Model
		- DbContext
			- The base class for EF COre
			- Managed Connection with the DB Server
			- Manages Entity Class Mapping with Database Tables usig 'DbSet<T>'
				- T is the Entity CLass mapped with table name 'T'
			- Manages DB Transactions using 'SaveChanges()' and 'SaveChangesAsync()' methods
		- DbSet<T>
			- T is Entity Class mapped with DB Table NAmed 'T'
			- Represents the Cursor for performing Read/Write OPerations
	- Pseudo
		- Consider 'ctx' is an instance of DbContext
		- Consider 'Employee' is Entity class
		- Consider DbSet<Employee is 'Employees'

	- To REad all Employees
		- var emps = ctx.Employees.ToList(); OR ctx.Employees.ToListAsync();
			- For TOListAsync(), Microsot.EntityFrameworkCore MUST be used in Code-File
	- TO Search Record based in Primary Key
		- var emp = ctx.Employees.Find(PK VALUE); OR ctx.Employess.FindAsync(PK Value);
	- To Add New Record
		- Create an Instance of ENtity Class
			- var emp = new EMployee();
		- Set all of its Properties
			- emp.EmpNo="EMp-101"; emp.EmpNAme="DDD";...
		- Add this object into DbSet<Employee>
			- ctx.Employees.Add(emp); OR ctx.Employees.AddAsync(emp);
		- Commit Transaction
			- ctx.SaveChanges(); OR ctx.SaveChangesAsync();
	- Adding Mutiple Records
		- Craete an Array/List of Entity Class
		- Set value for each employee in the Array/List
		- Add it in the DbSet<Employee>
		- ctx.Employees.AddRange(LIST/ARRAY); OR  ctx.Employees.AddRangeAsync(LIST/ARRAY);
		- Commit Transaction
			- ctx.SaveChanges(); OR ctx.SaveChangesAsync();
	- To Update Record
		- Search Record based on Primay Key
			- var emp = ctx.Employees.Find(PK Value); SYnc /  Async
		- Update emp values
		- Commit Transaction
			- ctx.SaveChanges(); OR ctx.SaveChangesAsync();
	- To Delete REcord
		- Search Record based on Primay Key
			- var emp = ctx.Employees.Find(PK Value); SYnc /  Async
		- Remove the record from DbSet
			- ctx.Employees.Remove(emp);
		- Commit Transaction
			- ctx.SaveChanges(); OR ctx.SaveChangesAsync();

	- To Search on Key other than Primary Key
		- Use LINQ




# ASP.NET Core 6

