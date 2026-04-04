CREATE TABLE dbo.MessageFault (
    MessageFaultId             INT              NOT NULL IDENTITY (1, 1),
    FaultedTimestamp           DATETIMEOFFSET   NOT NULL,
    MessageFaultStatusCode     TINYINT          NOT NULL
);
GO
CREATE NONCLUSTERED INDEX IX_dbo_MessageFault_MessageFaultStatusCode_FaultedTimestamp
    ON dbo.MessageFault (MessageFaultStatusCode, FaultedTimestamp DESC);
GO