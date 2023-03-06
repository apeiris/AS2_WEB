CREATE TABLE [dbo].[Partners] (
    [Partner_ID]  INT          IDENTITY (1, 1) NOT NULL,
    [PartnerName] VARCHAR (50) NULL,
    [AS2_ID]      VARCHAR (50) NULL,
    [X509_Alias]  VARCHAR (50) NULL,
    [Email]       VARCHAR (50) NULL,
    [LastCU_Time] DATETIME     DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Partner_ID] ASC)
);

