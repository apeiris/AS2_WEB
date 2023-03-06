CREATE TABLE [dbo].[Partner] (
    [Partner_ID]  INT            IDENTITY (1, 1) NOT NULL,
    [PartnerName] NVARCHAR (MAX) NOT NULL,
    [AS2_ID]      NVARCHAR (MAX) NOT NULL,
    [X509_Alias]  NVARCHAR (MAX) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [LastCU_Time] DATETIME       CONSTRAINT [DF_Partner_LastCU_Time] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED ([Partner_ID] ASC)
);

