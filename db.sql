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


