USE [isatmsdb]
GO

/****** Object:  Table [dbo].[DaysOff]    Script Date: 12/07/2023 17:39:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DaysOff](
	[Id] [uniqueidentifier] NOT NULL,
	[InterviewerId] [nvarchar](450) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Inactive] [bit] NOT NULL,
	[InactiveDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DaysOff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[DaysOff]  WITH CHECK ADD  CONSTRAINT [FK_DaysOff_Interviewer_InterviewerId] FOREIGN KEY([InterviewerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DaysOff] CHECK CONSTRAINT [FK_DaysOff_Interviewer_InterviewerId]
GO
