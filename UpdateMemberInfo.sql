/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [UserName], CHARINDEX('.', [UserName]), SUBSTRING([UserName],0, CHARINDEX('.', [UserName])), SUBSTRING([UserName],CHARINDEX('.', [UserName])+1, len([UserName]))
  FROM [SmartEngineer].[dbo].[admin_Member]

  update [SmartEngineer].[dbo].[admin_Member] 
			set [UserName] = [EmailAddress]
			where [UserName] = ''

			update [SmartEngineer].[dbo].[admin_Member]  set [UserName] = lower([UserName]), [EmailAddress] = lower([EmailAddress])

  update [SmartEngineer].[dbo].[admin_Member]
  set FirstName = SUBSTRING([UserName],0, CHARINDEX('.', [UserName])),
      LastName = SUBSTRING([UserName],CHARINDEX('.', [UserName])+1, len([UserName])),
	  [Signature] = SUBSTRING([UserName],0, CHARINDEX('.', [UserName]))


	  select  STUFF( FirstName,1,1,UPPER(SUBSTRING(FirstName,1,1))), STUFF( LastName,1,1,UPPER(SUBSTRING(LastName,1,1)))  FROM [SmartEngineer].[dbo].[admin_Member]

	    update [SmartEngineer].[dbo].[admin_Member]
		set FirstName = STUFF( FirstName,1,1,UPPER(SUBSTRING(FirstName,1,1))),
		    LastName = STUFF( LastName,1,1,UPPER(SUBSTRING(LastName,1,1))),
			[Signature] = STUFF( [Signature],1,1,UPPER(SUBSTRING([Signature],1,1))),
			[DisplayName] = FirstName + ' ' + LastName,
			[EmailAddress] = [UserName] + '@missionsky.com'

			

			select [UserName] from    [SmartEngineer].[dbo].[admin_Member] group by [UserName] having count(*) > 1