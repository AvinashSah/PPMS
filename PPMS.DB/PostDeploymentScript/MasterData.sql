

set identity_insert [dbo].[OperationMaster] on
If not exists(Select 'X' from OperationMaster where Id=1) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(1,'Dashboard','Operation to view dashboard') END
If not exists(Select 'X' from OperationMaster where Id=2) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(2,'ManageCustomer','OpOperation to allow manage customer') END
If not exists(Select 'X' from OperationMaster where Id=3) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(3,'ManageFuel','Operation to allow manage fuel') END
If not exists(Select 'X' from OperationMaster where Id=4) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(4,'ManageMeters','Operation to allow manage meters') END
If not exists(Select 'X' from OperationMaster where Id=5) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(5,'ManageTanks','Operation to allow manage Tanks') END
If not exists(Select 'X' from OperationMaster where Id=6) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(6,'ViewSalesReports','Operation to allow view reports') END
If not exists(Select 'X' from OperationMaster where Id=7) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(7,'ViewInventoryReports','Operation to allow view reports') END
If not exists(Select 'X' from OperationMaster where Id=8) BEGIN Insert into OperationMaster ([Id],[OperationName],[Description]) values(8,'CreateSale','Operation to allow create Sales') END
set identity_insert [dbo].[OperationMaster] off


set identity_insert [dbo].[RoleMaster] on
If not exists(Select 'X' from RoleMaster where ID=1) BEGIN Insert into RoleMaster ([ID],[RoleName],[Description])values(1,'SysAdmin','Access to all roads') END
If not exists(Select 'X' from RoleMaster where ID=2) BEGIN Insert into RoleMaster ([ID],[RoleName],[Description])values(2,'Admin','Admin having access to operations defined by SysAdmin') END
If not exists(Select 'X' from RoleMaster where ID=3) BEGIN Insert into RoleMaster ([ID],[RoleName],[Description])values(3,'EndUser','Can generate and view bills') END
set identity_insert [dbo].[RoleMaster] off


set identity_insert [dbo].[RoleOperationMapping] on
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=1) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (1,1,1) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=2) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (2,1,2) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=3) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (3,1,3) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=4) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (4,1,4) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=5) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (5,1,5) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=6) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (6,1,6) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=7) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (7,1,7) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=8) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (8,1,8) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=9) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (9,2,1) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=10) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (10,2,2) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=11) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (11,2,3) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=12) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (12,2,4) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=13) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (13,2,5) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=14) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (14,2,6) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=15) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (15,2,7) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=16) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (16,2,8) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=17) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (17,3,1) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=18) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (18,3,6) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=19) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (19,3,7) END
If not exists(Select 'X' from [dbo].[RoleOperationMapping] where Id=20) BEGIN insert into [dbo].[RoleOperationMapping]([Id],[RoleId],[OperationId])values (20,3,8) END
set identity_insert [dbo].[RoleOperationMapping] off


set identity_insert [dbo].[UserMaster] on
If not exists(Select 'X' from [dbo].[UserMaster] where Id=1) BEGIN  Insert into UserMaster ([ID], [UserName],[FirstName],[LastName],[EmailId],[Mobile],[IsActive],[CreatedOn],[UpdatedOn],[CreatedBy],[UpdatedBy],[EmpId],[password])
values(1,'SysAdmin','Sys','Admin','','',1,GETDATE(),GETDATE(),NULL,NULL,NUll,'8V/mNuXxvB/P69tO3HNQ36PPlctB3tMG8sF3btvQwCsyfmG5zDjZjGnRJEVJT+BL') END

If not exists(Select 'X' from [dbo].[UserMaster] where Id=2) BEGIN Insert into UserMaster ([ID], [UserName],[FirstName],[LastName],[EmailId],[Mobile],[IsActive],[CreatedOn],[UpdatedOn],[CreatedBy],[UpdatedBy],[EmpId],[password])
values(2,'UIAdmin','UI','Admin','','',1,GETDATE(),GETDATE(),1,1,NUll,'8V/mNuXxvB/P69tO3HNQ36PPlctB3tMG8sF3btvQwCsyfmG5zDjZjGnRJEVJT+BL') END

If not exists(Select 'X' from [dbo].[UserMaster] where Id=3) BEGIN Insert into UserMaster ([ID], [UserName],[FirstName],[LastName],[EmailId],[Mobile],[IsActive],[CreatedOn],[UpdatedOn],[CreatedBy],[UpdatedBy],[EmpId],[password])
values(3,'EndUser1','Test','User1','','',1,GETDATE(),GETDATE(),1,1,NUll,'jAmDbTYloMK3+qnNF+meSw==') END

set identity_insert [dbo].[UserMaster] off

set identity_insert [dbo].[UserRoleMapping] on
If not exists(Select 'X' from [dbo].[UserRoleMapping] where Id=1) BEGIN Insert into UserRoleMapping([Id],[RoleId],[UserId])values(1,1) END
If not exists(Select 'X' from [dbo].[UserRoleMapping] where Id=2) BEGIN Insert into UserRoleMapping([Id],[RoleId],[UserId])values(2,2) END
If not exists(Select 'X' from [dbo].[UserRoleMapping] where Id=3) BEGIN Insert into UserRoleMapping([Id],[RoleId],[UserId])values(3,3) END
set identity_insert [dbo].[UserRoleMapping] off

