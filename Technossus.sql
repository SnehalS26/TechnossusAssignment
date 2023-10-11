create table Student
(
id int primary key identity(1,1),
stud_name varchar(50),
father_name varchar(50),
mother_name varchar(50),
age int,
address varchar(100),
registration_date date,
isActive int 
)
select * from Student
