# ASP.NET Core MVC
- ASP.NET Core Runtime Package
	- Microsoft.AspNetCore.App
		- PAckage that is used to Host and RUn the ASP.NET Core App

- Folder Structure
	- Controllers
		- Contains all MVC Controller Classes
		- Each Controller class MUST end with 'Controller' word. e.g. DepartmentController
	- Views
		- Contains sub-folders that match with each MVC controller class in 'Controllers' folder 
		- Views for each action method in Controller will be created/generated in this matching name folder
		- e.g.
			- If Controller NAme is DepartmentController, then Views folder will have Sub-FOlder named 'Department'. This folder will contain Veiws those matches with Each action method from DepartmentController class
		- The 'Shared' sub-folder contains standard views as follows
			- _Layout.cshtml , the master page for all views aka this contains standard 'layout' e.g. Header, Footer for all Views for each controller.
			- Error.cshtml, a standard Error View that can be used for Global Error-Handling
		- Direct View Files in Views folder
			- _ViewImports.cshtml
					- This is used to import the standard namespace that is used by ASP.NET COre 'Tag-Helpers'
						- Microsoft.AspNetCore.Mvc.TagHelpers
			- _ViewStart.cshtml
				- Loads the _Layout.chtml page for each View that is returned from COntroller's Action method
	- Models
		- FOlder that contains Models classes
	- Area
		- THis specifies Views for Identity (This is provided with "Individual User Accounts" options for Security)
	- Data
		- THis is provided for Individual User Accounts
		- THis contains Migration classed for Creating Identity Tabales for Security in Database
	- wwwroot
		- Contains Files thse are provided to Browser
			- css, js, images, etc.
			
# Important Class Files
- appsettings.json
	- DEfines an aplication level conifgurations tose are used by the code
		- e.g .
			- DB Connection Strings
			- Signeture those are required for JWT Tokens
			- Other configurations
	- This file is read using 'ConfigurationManager' class in ASP.NET Core. This implements 'IConfiguration' interface
- Program.cs
	- An ENtrypoint to APplication

# D.I. Object Activation
	- SIngleton
		- Global Object for all Requests
	- Scopped
		- An Instance for each new Session
		- THis objet will be shared across all requests for the same session till session is not closed
	- Transient
		- An objet will be reated for each new request and will be destroyed when response is given or generated or completed
	- IServiceCollection, is the interface that manages DI Container and Registration of all object in it as 'Singleton', 'Scopped', 'Transient'.
		- THis uses the 'ServiecDescriptor' class to Discover, Resolve ad Register depednenies in DI Container 

# View COncept

```` csharp
- RazorPage<TModel>
````
	- This is a base class for MVC Razor View
	- TModel is the TYpe of The Model class passed to View when the View is generated
	- E.g.
		- If View Template is  List and Model class is Department then TModel will be 
```` csharp
       IEnumerable<Department>
````
	- The 'Model' property is used to access public properties of the Model class on View
	- The 'ViewData' propert is used to pass additional data from Actio MEthod to View which is not included in Model class(?)
		- "One View Can be passed with only-One Model class object"

# MVC Programming
- Data VAlidations
	- USing Sstem.COmponentModel.DataAnnotations
		- ValidationAttribute Abstract base class
			- IsValid(object value) virtual method, return boolean
				- true: Valid
				- false: Invalid
		- RequiredAttribute
		- StringLengthAttribute
		- CompareAttribute
		- RangeAttribute
		- RegExAttribute
		- ....
	- In Action Method use the following to check if the Model send to action method using POST is vaid or not
		- if(ModelState.IsValid)
	- TO write a custom Model Validator, create a class which is derived from ValiationAttribute base class and override its 'IsVAlid()' method 
- Process Validations aka Exception Handling
	- Try..Catch block for Each Method
	- Global Exception Handlign Object
		- USing 'Action Filters'
	- RouteData
		- THis is Property of the type RouteData class in ControllerBAse clas
			- This is used to Read the URL or current Route Expression using 'Values' property
- Action Filters
	- We can create a Custom Action Filters by creating class which is derived from ActionFilterAttribute class and by overriding is followign methods
		- OnActionExecuting(ActionExecutingContext )
		- OnActionExecuted(ActionExecutedContext)
		- OnResulrExecuting(ResultExecutingContext )
		- OnResultExecuted(ResultExecutedContext)
	- ALl these context classes are derived from FilterContext and The FilterContext is deried from ActionContext base class
		- Hence these methos will be executed when the filter is applied on 'Controller' class or on ActionMethod
	- For Exception, the class MUST implement 'IExceptionFilter' interface and implement it 'OnExceptionMethod(ExceptionContext )'
- Sharing Data Across Controllers
	- Sessions
	- TempData