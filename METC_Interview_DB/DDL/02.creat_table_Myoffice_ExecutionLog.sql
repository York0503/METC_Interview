USE [BackendExamHub]
GO


CREATE TABLE [dbo].[Myoffice_ExecutionLog](
	[DeLog_AuthID] [int] NOT NULL,
	[DeLog_StoredPrograms] [nvarchar](120) NULL,
	[DeLog_GroupID] [uniqueidentifier] NULL,
	[DeLog_isCustomDebug] [bit] NULL,
	[DeLog_ExecutionProgram] [nvarchar](120) NULL,
	[DeLog_ExecuteionInfo] [nvarchar](max) NULL,
	[DeLog_VerifyNeeded] [bit] NULL,
	[exelog_nowdatetime] [datetime] NULL,
 CONSTRAINT [PK_Myoffice_ExecutionLog] PRIMARY KEY CLUSTERED 
(
	[DeLog_AuthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


