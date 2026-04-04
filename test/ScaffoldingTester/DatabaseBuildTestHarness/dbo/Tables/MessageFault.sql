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

CREATE TRIGGER dbo.TrMessageFaultAfterInsert ON dbo.MessageFault
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
END;
GO

CREATE TRIGGER dbo.TrMessageFaultAfterUpdate ON dbo.MessageFault
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
END;
GO