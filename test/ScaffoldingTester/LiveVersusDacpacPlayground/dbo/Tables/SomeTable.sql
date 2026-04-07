CREATE TABLE dbo.SomeTable (
    SomeTableId INT IDENTITY(1,1) NOT NULL,
    SomeBigInt BIGINT NOT NULL CONSTRAINT DF_dbo_SomeTable_SomeBigInt DEFAULT (0),
    CONSTRAINT PK_readModel_SomeTable PRIMARY KEY (SomeTableId)
);