use StudentManageDB
go

--�޸�����
if exists(select top 1 1 from sysobjects  where name='Students' )
begin
	alter table Students 
		alter column StudentName varchar(30) null
	print '�޸�����-OK'
end

--����
https://blog.csdn.net/lyelyelye/article/details/77574960