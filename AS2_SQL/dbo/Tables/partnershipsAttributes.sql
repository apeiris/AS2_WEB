CREATE TABLE [dbo].[partnershipsAttributes] (
    [AttributeID]   INT           IDENTITY (1, 1) NOT NULL,
    [PartnershipID] INT           NULL,
    [name]          VARCHAR (50)  NULL,
    [value]         VARCHAR (MAX) NULL
);

