select * from Times


--==========================================

CREATE PROCEDURE ExcluirTimePorId
(
	@TimeId int
)

AS

begin
	Delete From Times where TimeId = @TimeId
end



--exec ExcluirTimePorId @TimeId = 2

--==========================================

CREATE PROCEDURE AtualizarTime
(
	@TimeId int,
	@Time nvarchar(100),
	@Estado char(2),
	@Cores nvarchar(50)
)

AS

begin
	Update Times set Time =  @Time, Estado =  @Estado, Cores = @Cores where TimeId = @TimeId
end



--==========================================


CREATE PROCEDURE IncluirTime
(	
	@Time nvarchar(100),
	@Estado char(2),
	@Cores nvarchar(50)
)

AS

begin
	Insert Times (Time, Estado, Cores) Values (@Time, @Estado, @Cores) 
end


--==========================================--


CREATE PROCEDURE ObterTimes

AS

begin
	select TimeId, Time, Estado, Cores from Times
end