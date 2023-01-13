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