USE [Devskill]
GO
/****** Object:  StoredProcedure [dbo].[spGetProduct]    Script Date: 3/13/2020 1:37:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetProduct]
	@pageIndex int = 0,
	@pageSize int = 10,
	@orderBy nvarchar(50) = NULL,
	@searchString nvarchar(50) = NULL,
	@filteredCount int output
AS 
BEGIN
	declare @sql nvarchar(max),
	@filtr nvarchar(max),
	@params nvarchar(max),
	@frstparams nvarchar(max),
	@searchRegex nvarchar(max)
	set nocount on;
	set @searchRegex = '%'+@searchString+'%'

	set @sql = 'select * from product where name like @searchRegex or Description like @searchRegex ';
	set @filtr = 'select @filteredCount = count(0) from ('+@sql+')';
	set @filteredCount = (select count(*) from Product where Name like @searchRegex or Description like @searchRegex) ;
	
	set @sql = @sql+' order by '+@orderBy+' offset  @pageIndex  rows fetch next @pageSize rows only';
	

	set @params = '@searchRegex nvarchar(max), @pageIndex int, @pageSize int';

	exec sp_executesql @sql,@params,@searchRegex,@pageIndex,@pageSize;

END
--@pageSize*(@pageIndex-1)