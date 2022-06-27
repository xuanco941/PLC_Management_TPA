CREATE DATABASE PLC_MANAGEMENT_TPA
GO
USE PLC_MANAGEMENT_TPA
GO

CREATE TABLE Employee (
Employee_ID INT IDENTITY(1,1) PRIMARY KEY,
Employee_FullName NVARCHAR(100),
Employee_Username VARCHAR(100) UNIQUE NOT NULL,
Employee_Password VARCHAR(100) default 'plc_management_tpa',
Employee_Department NVARCHAR(100),
Employee_IsAdmin BIT default 0
)
GO

CREATE TABLE Activity(
Activity_ID INT IDENTITY(1,1) PRIMARY KEY,
Activity_Name NVARCHAR(2000),
Activity_Time DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE Result(
Result_ID INT IDENTITY(1,1) PRIMARY KEY,
Result_ApSuatNap FLOAT,
Result_TheTichNap FLOAT,
Result_LoaiKhi NVARCHAR(100),
Result_ApSuatLayMau NVARCHAR(100),
Result_LuuLuongLayMau NVARCHAR(100),
Result_ThoiGian Time ,
Result_CreateAt DATETIME DEFAULT GETDATE()
)
GO

CREATE TABLE ThongSoMay (
ID int DEFAULT 1,
ApSuat FLoat,
ThoiGianNapGioiHan TIME,
UpdateAt DateTime
)
GO

/* Procedure */
 -- Them result
CREATE PROC AddResult @Result_ApSuatNap FLOAT,@Result_TheTichNap FLOAT,@Result_LoaiKhi nvarchar(100),@Result_ApSuatLayMau NVARCHAR(100), @Result_LuuLuongLayMau NVARCHAR(100),@Result_ThoiGian TIME
as begin
INSERT INTO Result(Result_ApSuatNap,Result_TheTichNap,Result_LoaiKhi,Result_ApSuatLayMau,Result_LuuLuongLayMau,Result_ThoiGian) 
values(@Result_ApSuatNap,@Result_TheTichNap,@Result_LoaiKhi,@Result_ApSuatLayMau,@Result_LuuLuongLayMau,@Result_ThoiGian)
end
GO

--phan trang, lất tất cả
 create proc paginationResult (@startfrom int ,@endto int) as
SELECT * FROM ( 
  SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result 
 ) a WHERE a.row > @startfrom and a.row <= @endto
 GO


 --Tim kiem Result theo khoang ngay
create proc paginationResultByDay (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime) as
SELECT * FROM ( 
  SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result WHERE 
Result_CreateAt BETWEEN
@Time1 AND
 @Time2
 ) as a WHERE a.row > @startfrom and a.row <= @endto 
 GO

CREATE PROC FindResultDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT * FROM Result WHERE 
Result_CreateAt BETWEEN
@Time1 AND
 @Time2 order by Result.Result_ID DESC
end
GO


 --pagination paraID and day
 create proc paginationResultByDayAndParameter @startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime,@Oxi nvarchar(100), @Nitor nvarchar(100) 
 as begin 
  select * from (SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result WHERE 
(Result_CreateAt BETWEEN
@Time1 AND
 @Time2) AND (Result_LoaiKhi = @Oxi OR Result_LoaiKhi = @Nitor )) as a WHERE a.row > @startfrom and a.row <= @endto  
 end
 GO

 CREATE PROC FindResultDayToDayByParameter @Time1 DateTime , @Time2 DateTime,@Oxi nvarchar(100), @Nitor nvarchar(100)
as begin
SELECT * FROM Result WHERE( 
Result_CreateAt BETWEEN
@Time1 AND
 @Time2) and (Result_LoaiKhi = @Oxi OR Result_LoaiKhi = @Nitor) order by Result.Result_ID DESC
end
GO

--Dem result theo ngay, theo parameter
CREATE PROC CountResultByParameterAndDay @Time1 DateTime, @Time2 DateTime, @Oxi nvarchar(100), @Nitor nvarchar(100)
as begin
select count(*) from Result where (Result.Result_LoaiKhi = @Oxi OR Result.Result_LoaiKhi = @Nitor) and (Result.Result_CreateAt between @Time1 and @Time2) 
end
GO

--count by day
CREATE PROC CountResultDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT count(*) FROM Result WHERE 
Result_CreateAt BETWEEN
@Time1 AND
 @Time2
end
GO

 -- delete result by ID
 CREATE proc DeleteResultByIDAndParameter (@startID int, @endID int, @Oxi nvarchar(100), @Nitor nvarchar(100))
 as begin
 Delete From Result Where (Result.Result_ID >= @startID and Result.Result_ID <= @endID) and (Result.Result_LoaiKhi = @Oxi OR Result_LoaiKhi = @Nitor) 
 end
 GO








--Update Thông số máy
CREATE PROC UpdateThongSoMay @ApSuat FLoat, @ThoiGianNapGioiHan Time
as begin
Update ThongSoMay SET ApSuat = @ApSuat, ThoiGianNapGioiHan = @ThoiGianNapGioiHan, UpdateAt = GETDATE()
where ID = 1
end
GO




















--Tìm kiếm nhân viên theo tên tài khoản
CREATE PROC FindEmployeeByUsername @Username varchar(100)
as begin 
Select * From Employee Where Employee.Employee_Username = @Username;
end
GO

--Tìm kiếm nhân viên theo MaNV
CREATE PROC FindEmployeeByID @ID int
as begin 
Select * From Employee Where Employee.Employee_ID = @ID;
end
GO

--Tìm kiếm nhân viên với họ tên bất kỳ
CREATE PROC FindEmployeeByFullName @FullName nvarchar(100)
as begin 
Select * From Employee Where Employee.Employee_FullName like '%'+@FullName+'%';
end
GO

-- Thêm nhân viên
CREATE PROC AddEmployee @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100) , @Department NVARCHAR(100), @IsAdmin Bit
as begin
Insert into Employee values (@FullName,@Username,@Password,@Department,@IsAdmin);
end
GO

--Cap nhat thong tin nhan vien
CREATE PROC UpdateEmployee @ID int, @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100), @Department NVARCHAR(100) , @IsAdmin Bit
as begin
Update Employee SET Employee_FullName = @FullName, Employee_Username = @Username, Employee_Password = @Password, Employee_Department=@Department ,Employee_IsAdmin = @IsAdmin
where Employee_ID = @ID
end
GO


--Xóa tài khoản nhân viên theo MaNV
CREATE PROC DeleteEmployee @ID int
as begin
Delete FROM Employee WHERE Employee.Employee_ID = @ID;
end
GO

--Tim kiem Activity theo khoang ngay
CREATE PROC FindActivityDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT * FROM Activity WHERE 
Activity_Time BETWEEN
@Time1 AND
 @Time2 order by Activity.Activity_ID DESC
end
GO

--Đếm Activity theo ngày
CREATE PROC CountActivityDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT count(*) FROM Activity WHERE 
Activity_Time BETWEEN
@Time1 AND
 @Time2
end
GO

--phan trang 
create proc paginationActivity (@startfrom int ,@endto int) as
SELECT * FROM ( 
  SELECT *, ROW_NUMBER() OVER (ORDER BY Activity_ID desc) as row FROM Activity 
 ) a WHERE a.row > @startfrom and a.row <= @endto
 GO

 -- phan trang theo ngay
 create proc paginationActivityByDay (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime) as begin
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY Activity_ID desc) as row FROM Activity WHERE 
Activity_Time BETWEEN
@Time1 AND
 @Time2 ) as a WHERE a.row > @startfrom and a.row <= @endto
 end
 GO




exec AddEmployee N'Đỗ Văn Xuân', 'admin','123',N'Kế toán', 1

exec AddResult 100,23.4,'Oxi','1000',3004,'00:00:15'
GO
