CREATE TABLE dbo.MessageFault (
    MessageFaultId             INT              NOT NULL IDENTITY (1, 1),
    FaultedTimestamp           DATETIMEOFFSET   NOT NULL,
    MessageFaultStatusCode     TINYINT          NOT NULL,
    CreatedDate           DATETIMEOFFSET NOT NULL CONSTRAINT DF_dbo_MessageFault_CreatedDate DEFAULT SYSDATETIMEOFFSET(),
);
GO
CREATE NONCLUSTERED INDEX IX_dbo_MessageFault_MessageFaultStatusCode_FaultedTimestamp
    ON dbo.MessageFault (MessageFaultStatusCode, FaultedTimestamp DESC);
GO