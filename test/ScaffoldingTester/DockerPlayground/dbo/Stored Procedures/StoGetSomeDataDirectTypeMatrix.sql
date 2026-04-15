CREATE PROCEDURE dbo.StoGetSomeDataDirectTypeMatrix
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CAST(1 AS INT) AS IntValue,
        CAST(1 AS BIGINT) AS BigIntValue,
        CAST(123.45 AS DECIMAL(10,2)) AS DecimalValue,
        CAST(123.4567 AS NUMERIC(12,4)) AS NumericValue,
        CAST(N'Text' AS NVARCHAR(100)) AS StringValue,
        CAST('Text' AS VARCHAR(50)) AS AnsiStringValue,
        CAST(N'Text' AS NVARCHAR(MAX)) AS MaxStringValue,
        CAST(N'dbo.Table' AS SYSNAME) AS SysNameValue,
        CAST('2024-01-01' AS DATE) AS DateValue,
        CAST('2024-01-01T12:34:56.1234567' AS DATETIME2(7)) AS DateTime2Value,
        CAST('12:34:56.1234567' AS TIME(7)) AS TimeValue,
        CAST('6F9619FF-8B86-D011-B42D-00C04FC964FF' AS UNIQUEIDENTIFIER) AS GuidValue,
        CAST(1 AS BIT) AS BitValue,
        CAST(0x1234 AS VARBINARY(2)) AS BinaryValue,
        CAST(0x1234 AS VARBINARY(MAX)) AS MaxBinaryValue;
END;
GO
