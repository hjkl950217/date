use StudentManageDB
go

--修改类型
if exists(select top 1 1 from sysobjects  where name='Students' )
begin
	alter table Students 
		alter column StudentName varchar(30) null
	print '修改类型-OK'
end

--其它
https://blog.csdn.net/lyelyelye/article/details/77574960