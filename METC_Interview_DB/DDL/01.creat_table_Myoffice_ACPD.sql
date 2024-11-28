USE [BackendExamHub]
GO


CREATE TABLE [dbo].[Myoffice_ACPD](
	[acpd_sid] [char](20) NOT NULL,
	[acpd_cname] [nvarchar](60) NULL,
	[acpd_ename] [nvarchar](40) NULL,
	[acpd_sname] [nvarchar](40) NULL,
	[acpd_email] [nvarchar](60) NULL,
	[acpd_status] [tinyint] NULL,
	[acpd_stop] [bit] NULL,
	[acpd_stopMemo] [nvarchar](600) NULL,
	[acpd_LoginID] [nvarchar](30) NULL,
	[acpd_LoginPW] [nvarchar](60) NULL,
	[acpd_memo] [nvarchar](120) NULL,
	[acpd_nowdatetime] [datetime] NULL,
	[appd_nowid] [nvarchar](20) NULL,
	[acpd_upddatetitme] [datetime] NULL,
	[acpd_updid] [nvarchar](20) NULL,
 CONSTRAINT [PK_Myoffice_ACPD] PRIMARY KEY CLUSTERED 
(
	[acpd_sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
