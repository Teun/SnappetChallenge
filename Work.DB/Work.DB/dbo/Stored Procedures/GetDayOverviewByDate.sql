CREATE PROCEDURE [dbo].[GetDayOverviewByDate]
	@tillDateTime DateTime
AS
  if exists (select id from DayOverview where TillDateTime = @tillDateTime)
	begin
		select top 1
		Id,
		TillDateTime,
		NumberOfSubmission,
		SumOfProgress,
		NumberOfProgresseddPupil,
		NumberOfWorkedPupil
		from DayOverview where TillDateTime = @tillDateTime
	end
 else
	begin
	declare @numberOfSubmission int, @sumOfProgress int, @numberOfProgresseddPupil int, @numberOfWorkedPupil int, @Id int 
		select @numberOfSubmission = count(SubmittedAnswerId), @sumOfProgress = sum(Progress) from Work where SubmitDateTime > convert(date, @tillDateTime) and SubmitDateTime < @tillDateTime
		--select @numberOfWorkedPupil = count(UserId) from Work where SubmitDateTime > convert(date, @tillDateTime) and SubmitDateTime < @tillDateTime group by UserId
		
		Create table #Tmp(
			Prog int
			)
		insert into #Tmp
		SELECT sum(Progress)  
			FROM [Work] where SubmitDateTime > convert(date, @tillDateTime) and SubmitDateTime < @tillDateTime group by UserId 
		select @numberOfProgresseddPupil = count(Prog) from #Tmp where Prog > 0
		select @numberOfWorkedPupil = count(Prog) from #Tmp
		drop table #Tmp
		insert into DayOverview (
			TillDateTime,
			NumberOfSubmission,
			SumOfProgress,
			NumberOfProgresseddPupil,
			NumberOfWorkedPupil
		) values (
			@tillDateTime,
			@numberOfSubmission,
			@sumOfProgress,
			@numberOfProgresseddPupil,
			@numberOfWorkedPupil
		)
		select @Id = SCOPE_IDENTITY()
		select Id,
		TillDateTime,
		NumberOfSubmission,
		SumOfProgress,
		NumberOfProgresseddPupil,
		NumberOfWorkedPupil
		from DayOverview where Id = @Id
	end

RETURN 0
