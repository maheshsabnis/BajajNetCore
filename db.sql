Create Database BajajCompany;

USe BajajCompany;

CReate Table Department
(
  DeptUniqueId int identity Primary Key,
  DeptNo varchar(20) Not Null,
  DeptName varchar(100) Not Null,
  Capacity int Not null,
  Location varchar(100) Not null
)

Create Table Employee
(
  EmpUniqueId int Identity Primary Key,
  EmpNo varchar(20) Not Null,
  EmpName varchar(100) Not Null,
  Designation varchar(100) not null,
  Salary int Not Null,
  DeptUniqueId int  references Department (DeptUniqueId) 
)


 
INsert into Department Values('Dept-20', 'HRD',15,'Pune')
INsert into Department Values('Dept-30', 'SALES',20,'Pune')

select * from Department

Insert into Employee Values('EmpNo-1002', 'Tejas', 'Manager',2222,1);
Insert into Employee Values('EmpNo-1003', 'Vikram', 'Director',142222,2);
Insert into Employee Values('EmpNo-1004', 'Suprotim', 'Manager',42222,2);
Insert into Employee Values('EmpNo-1005', 'Manish', 'Director',622222,3);
Insert into Employee Values('EmpNo-1006', 'Praveen', 'Manager',82222,3);

select * from Employee
