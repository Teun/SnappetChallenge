namespace SnappetChallenge.SqlQuerys
{
	public static class Querys
	{
		public static string CompareDayToLastWeek(DateTime moment)
		{
			return $@"
                ;with wdtp as (select 
				[Subject]
				,Domain
				,LearningObjective
				,ISNULL(avg(CAST(Progress as float)), 0) as AvgProgressForDay
  
				from Workdata 
				  
				 where cast('{moment}' as DATE) = cast(SubmitDateTime as DATE)
						and SubmitDateTime < '{moment}'
						and Progress <> 0

				  group by Subject, Domain, LearningObjective
				  ),
  
				wdtlwp as (select 
				[Subject]
				,Domain
				,LearningObjective
               ,ISNULL(avg(CAST(Progress as float)), 0) as AvgProgressForLastWeek
  
               from Workdata 
              
				where DATEPART(""ww"", SubmitDateTime) = DATEPART(""ww"", '{moment}') - 1
				and Progress<> 0

			  group by Subject, Domain, LearningObjective
              )

              select
					wdtp.Subject
					,wdtp.Domain
					,wdtp.LearningObjective
					,wdtp.AvgProgressForDay
					,wdtlwp.AvgProgressForLastWeek
					,(wdtp.AvgProgressForDay - wdtlwp.AvgProgressForLastWeek) as ProgressChange


			  from wdtp LEFT JOIN wdtlwp
			   on wdtp.Subject = wdtlwp.Subject and wdtp.Domain = wdtlwp.Domain and wdtp.LearningObjective = wdtlwp.LearningObjective

					";
		}


		public static string CompareDayToAll(DateTime moment)
		{
			return $@"
				 ;with wdtp as (select 
				[Subject]
				,Domain
				,LearningObjective
                ,ISNULL(avg(CAST(Progress as float)), 0) as AvgProgressForDay
  
              from Workdata 

              where cast('{moment}' as DATE) = cast(SubmitDateTime as DATE)
						and SubmitDateTime < '{moment}'
						and Progress <> 0

			  group by Subject, Domain, LearningObjective
              ),
  
				allwdp as (select 
				[Subject]
				,Domain
				,LearningObjective
                ,ISNULL(avg(CAST(Progress as float)), 0) as AvgProgressForAll
  
              from Workdata 
              where cast(SubmitDateTime as DATE) < cast('{moment}' as DATE)
                and Progress <> 0

			  group by Subject, Domain, LearningObjective
              )

              select 
                 wdtp.Subject
				 ,wdtp.Domain
				 ,wdtp.LearningObjective
                 , wdtp.AvgProgressForDay
                 , allwdp.AvgProgressForAll
				 ,(wdtp.AvgProgressForDay - allwdp.AvgProgressForAll) as ProgressChange
                
               from wdtp LEFT JOIN allwdp
			   on wdtp.Subject = allwdp.Subject and wdtp.Domain = allwdp.Domain and wdtp.LearningObjective = allwdp.LearningObjective
					";
		}
	}
}
