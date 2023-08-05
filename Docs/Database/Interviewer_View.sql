DROP VIEW IF EXISTS dbo.Interviewer
go

CREATE VIEW dbo.Interviewer AS
SELECT 
	U.Id,
	U.UserName,      
	U.Email,
	U.FirstName,
	U.GenderId,
	U.Inactive,
	U.LastName,
	U.SexualOrientationId,
	U.SocialName,
	U.UsersTypeId
FROM 
	ASPNETUSERS U LEFT JOIN USERSTYPE T ON U.USERSTYPEID = T.ID 
WHERE 
	UPPER(TRIM(T.NAME)) = 'INTERVIEWER'
go