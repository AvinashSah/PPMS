

set identity_insert [dbo].[OperationMaster] on
If not exists(Select 'X' from OperationMaster where ID=1)Insert into OperationMaster ([ID],[OperationName],[Description]) values(1,'Dashboard','Operation to view dashboard')
If not exists(Select 'X' from OperationMaster where ID=2)Insert into OperationMaster ([ID],[OperationName],[Description]) values(2,'ManageCustomer','OpOperation to allow manage customer')
If not exists(Select 'X' from OperationMaster where ID=3)Insert into OperationMaster ([ID],[OperationName],[Description]) values(3,'ManageFuel','Operation to allow manage fuel')
If not exists(Select 'X' from OperationMaster where ID=4)Insert into OperationMaster ([ID],[OperationName],[Description]) values(4,'ManageMeters','Operation to allow manage meters')
If not exists(Select 'X' from OperationMaster where ID=5)Insert into OperationMaster ([ID],[OperationName],[Description]) values(5,'ManageTanks','Operation to allow manage Tanks')
If not exists(Select 'X' from OperationMaster where ID=6)Insert into OperationMaster ([ID],[OperationName],[Description]) values(6,'ViewReports','Operation to allow view reports')
If not exists(Select 'X' from OperationMaster where ID=7)Insert into OperationMaster ([ID],[OperationName],[Description]) values(7,'CreateSale','Operation to allow create Sales')
set identity_insert [dbo].[OperationMaster] off


set identity_insert [dbo].[RoleMaster] on
If not exists(Select 'X' from RoleMaster where ID=1)Insert into RoleMaster ([ID],[RoleName],[Description])values(1,'SysAdmin','Access to all roads')
If not exists(Select 'X' from RoleMaster where ID=2)Insert into RoleMaster ([ID],[RoleName],[Description])values(2,'Admin','Admin having access to operations defined by SysAdmin')
If not exists(Select 'X' from RoleMaster where ID=3)Insert into RoleMaster ([ID],[RoleName],[Description])values(3,'EndUser','Can generate and view bills')
set identity_insert [dbo].[RoleMaster] off


insert into RoleOperationMapping
values 
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),
(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7),
(3,1),(3,6),(3,7)


set identity_insert [dbo].[UserMaster] on
Insert into UserMaster ([ID], [UserName],[FirstName],[LastName],[EmailId],[Mobile],[IsActive],[CreatedOn],[UpdatedOn],[CreatedBy],[UpdatedBy],[EmpId],[password])
values(1,'SysAdmin','Sys','Admin','','',1,GETDATE(),GETDATE(),NULL,NULL,NUll,'8V/mNuXxvB/P69tO3HNQ36PPlctB3tMG8sF3btvQwCsyfmG5zDjZjGnRJEVJT+BL'),
(2,'UIAdmin','UI','Admin','','',1,GETDATE(),GETDATE(),1,1,NUll,'8V/mNuXxvB/P69tO3HNQ36PPlctB3tMG8sF3btvQwCsyfmG5zDjZjGnRJEVJT+BL')
,(3,'EndUser1','Test','User1','','',1,GETDATE(),GETDATE(),1,1,NUll,'jAmDbTYloMK3+qnNF+meSw==')

set identity_insert [dbo].[UserMaster] off

Insert into UserRoleMapping
values(1,1),(2,2),(3,3)


--insert into Fuel
--values
--('XPPetrol','Xtra Premium Petrol',1,1,1,GETDATE(),GETDATE(),'Petrol')


--insert into DailyFuelCost
--values(1,'76.62',GETDATE(),1,1,1,GETDATE(),GETDATE())