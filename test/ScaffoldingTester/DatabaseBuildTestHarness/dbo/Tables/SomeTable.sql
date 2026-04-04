/*
Projection read model summarizing the current state of a BinReplenishment aggregate.
One row per ItemId & BinNodeIdToReplenish.
*/
GO
CREATE TABLE dbo.SomeTable (
    SomeTableId INT            NOT NULL IDENTITY (1, 1),
    ColumnWithDefault     BIGINT         NOT NULL CONSTRAINT DF_dbo_SomeTable_ColumnWithDefault DEFAULT (0),
    CONSTRAINT PK_dbo_SomeTable PRIMARY KEY CLUSTERED (SomeTableId) WITH (OPTIMIZE_FOR_SEQUENTIAL_KEY = ON)
);
GO

EXEC sp_addextendedproperty
    @name = N'MS_Description',
    @value = N'The location''s address',
    @level0type = N'SCHEMA', @level0name = N'dbo',
    @level1type = N'TABLE',  @level1name = N'SomeTable',
    @level2type = N'COLUMN', @level2name = N'ColumnWithDefault';
GO