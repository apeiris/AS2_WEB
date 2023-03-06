CREATE TABLE [dbo].[msg_metadata] (
    [ID]                        INT           IDENTITY (1, 1) NOT NULL,
    [MSG_ID]                    VARCHAR (512) NOT NULL,
    [PRIOR_MSG_ID]              TEXT          NULL,
    [MDN_ID]                    TEXT          NULL,
    [DIRECTION]                 VARCHAR (25)  NULL,
    [IS_RESEND]                 VARCHAR (1)   NULL,
    [RESEND_COUNT]              INT           NULL,
    [SENDER_ID]                 VARCHAR (255) NOT NULL,
    [RECEIVER_ID]               VARCHAR (255) NOT NULL,
    [STATUS]                    VARCHAR (255) NULL,
    [STATE]                     VARCHAR (255) NULL,
    [SIGNATURE_ALGORITHM]       VARCHAR (255) NULL,
    [ENCRYPTION_ALGORITHM]      VARCHAR (255) NULL,
    [COMPRESSION]               VARCHAR (255) NULL,
    [FILE_NAME]                 VARCHAR (255) NULL,
    [CONTENT_TYPE]              VARCHAR (255) NULL,
    [CONTENT_TRANSFER_ENCODING] VARCHAR (255) NULL,
    [MDN_MODE]                  VARCHAR (255) NULL,
    [MDN_RESPONSE]              TEXT          NULL,
    [STATE_MSG]                 TEXT          NULL,
    [CREATE_DT]                 DATETIME      NULL,
    [UPDATE_DT]                 DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [MSG_ID_UNIQUE]
    ON [dbo].[msg_metadata]([MSG_ID] ASC);

