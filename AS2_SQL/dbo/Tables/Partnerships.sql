CREATE TABLE [dbo].[Partnerships] (
    [partnershipID]          INT          IDENTITY (1, 1) NOT NULL,
    [name]                   VARCHAR (50) NULL,
    [sender]                 VARCHAR (50) NULL,
    [receiver]               VARCHAR (50) NULL,
    [implementation_flavour] VARCHAR (50) NULL,
    [pollerConfig]           BIT          NULL,
    [LastCU_Time]            DATETIME     DEFAULT (getdate()) NULL
);


GO
CREATE CLUSTERED INDEX [ClusteredIndex-20230301-153358]
    ON [dbo].[Partnerships]([partnershipID] ASC);

