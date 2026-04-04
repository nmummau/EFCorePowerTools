CREATE PROCEDURE dbo.StoGetSomeData
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #SomeTempTable (
        SomeData  VARCHAR(10) NOT NULL
    );

    SELECT
        SomeData
    FROM #SomeTempTable;

END;
GO