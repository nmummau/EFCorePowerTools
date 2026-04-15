using System.Linq;
using ErikEJ.EntityFrameworkCore.SqlServer.Scaffolding;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class SqlServerStoredProcedureResultSetFactoryTests
    {
        [Test]
        public void CanParseResultSetFromProcedureDefinitionWithTempTable()
        {
            const string definition = @"
CREATE PROCEDURE dbo.StoGetSomeData
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #Temp
    (
        SomeName NVARCHAR(100),
        SomeValue NVARCHAR(100)
    );

    SELECT
        SomeName,
        SomeValue
    FROM #Temp;

    DROP TABLE #Temp;
END;";

            var resultSets = SqlServerStoredProcedureResultSetFactory.CreateFromDefinition(definition, singleResult: true);

            Assert.That(resultSets, Has.Count.EqualTo(1));
            Assert.That(resultSets[0], Has.Count.EqualTo(2));

            var someName = resultSets[0].Single(c => c.Name == "SomeName");
            var someValue = resultSets[0].Single(c => c.Name == "SomeValue");

            Assert.That(someName.StoreType, Is.EqualTo("nvarchar"));
            Assert.That(someName.MaxLength, Is.EqualTo(100));
            Assert.That(someName.Nullable, Is.True);

            Assert.That(someValue.StoreType, Is.EqualTo("nvarchar"));
            Assert.That(someValue.MaxLength, Is.EqualTo(100));
            Assert.That(someValue.Nullable, Is.True);
        }

        [Test]
        public void CanParseResultSetFromProcedureDefinitionWithParameters()
        {
            const string definition = @"
CREATE PROCEDURE dbo.StoGetSomeData
    @CategoryId INT,
    @SearchTerm NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #Temp
    (
        CategoryId INT NOT NULL,
        SearchTerm NVARCHAR(50) NULL,
        Amount DECIMAL(10,2) NOT NULL
    );

    SELECT
        CategoryId,
        SearchTerm,
        Amount
    FROM #Temp;
END;";

            var resultSets = SqlServerStoredProcedureResultSetFactory.CreateFromDefinition(definition, singleResult: true);

            Assert.That(resultSets, Has.Count.EqualTo(1));
            Assert.That(resultSets[0], Has.Count.EqualTo(3));

            var categoryId = resultSets[0].Single(c => c.Name == "CategoryId");
            var searchTerm = resultSets[0].Single(c => c.Name == "SearchTerm");
            var amount = resultSets[0].Single(c => c.Name == "Amount");

            Assert.That(categoryId.StoreType, Is.EqualTo("int"));
            Assert.That(categoryId.Nullable, Is.False);

            Assert.That(searchTerm.StoreType, Is.EqualTo("nvarchar"));
            Assert.That(searchTerm.MaxLength, Is.EqualTo(50));
            Assert.That(searchTerm.Nullable, Is.True);

            Assert.That(amount.StoreType, Is.EqualTo("decimal"));
            Assert.That(amount.Precision, Is.EqualTo(10));
            Assert.That(amount.Scale, Is.EqualTo(2));
            Assert.That(amount.Nullable, Is.False);
        }

        [Test]
        public void CanParseMultipleResultSetsFromProcedureDefinitionWithParameters()
        {
            const string definition = @"
CREATE PROCEDURE dbo.StoGetSomeData
    @CategoryId INT
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #Summary
    (
        CategoryId INT NOT NULL,
        TotalCount INT NOT NULL
    );

    CREATE TABLE #Details
    (
        CategoryId INT NOT NULL,
        ItemName NVARCHAR(100) NULL
    );

    SELECT
        CategoryId,
        TotalCount
    FROM #Summary;

    SELECT
        CategoryId,
        ItemName
    FROM #Details;
END;";

            var resultSets = SqlServerStoredProcedureResultSetFactory.CreateFromDefinition(definition, singleResult: false);

            Assert.That(resultSets, Has.Count.EqualTo(2));

            Assert.That(resultSets[0].Select(c => c.Name), Is.EqualTo(new[] { "CategoryId", "TotalCount" }));
            Assert.That(resultSets[1].Select(c => c.Name), Is.EqualTo(new[] { "CategoryId", "ItemName" }));

            var itemName = resultSets[1].Single(c => c.Name == "ItemName");
            Assert.That(itemName.StoreType, Is.EqualTo("nvarchar"));
            Assert.That(itemName.MaxLength, Is.EqualTo(100));
            Assert.That(itemName.Nullable, Is.True);
        }

        [Test]
        public void CanParseSysnameColumnsFromProcedureDefinition()
        {
            const string definition = @"
CREATE PROCEDURE dbo.StoGetSomeData
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #Temp
    (
        ObjectName SYSNAME NOT NULL
    );

    SELECT
        ObjectName
    FROM #Temp;
END;";

            var resultSets = SqlServerStoredProcedureResultSetFactory.CreateFromDefinition(definition, singleResult: true);

            Assert.That(resultSets, Has.Count.EqualTo(1));
            Assert.That(resultSets[0], Has.Count.EqualTo(1));

            var objectName = resultSets[0].Single(c => c.Name == "ObjectName");

            Assert.That(objectName.StoreType, Is.EqualTo("nvarchar"));
            Assert.That(objectName.MaxLength, Is.EqualTo(128));
            Assert.That(objectName.Nullable, Is.False);
        }

        [Test]
        public void CanParseDirectLiteralTypeMatrixFromProcedureDefinition()
        {
            const string definition = @"
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
END;";

            var resultSets = SqlServerStoredProcedureResultSetFactory.CreateFromDefinition(definition, singleResult: true);

            Assert.That(resultSets, Has.Count.EqualTo(1));
            Assert.That(resultSets[0], Has.Count.EqualTo(15));

            var decimalValue = resultSets[0].Single(c => c.Name == "DecimalValue");
            Assert.That(decimalValue.StoreType, Is.EqualTo("decimal"));
            Assert.That(decimalValue.Precision, Is.EqualTo(10));
            Assert.That(decimalValue.Scale, Is.EqualTo(2));

            var numericValue = resultSets[0].Single(c => c.Name == "NumericValue");
            Assert.That(numericValue.StoreType, Is.EqualTo("decimal"));
            Assert.That(numericValue.Precision, Is.EqualTo(12));
            Assert.That(numericValue.Scale, Is.EqualTo(4));

            var maxStringValue = resultSets[0].Single(c => c.Name == "MaxStringValue");
            Assert.That(maxStringValue.StoreType, Is.EqualTo("nvarchar"));
            Assert.That(maxStringValue.MaxLength, Is.EqualTo(int.MaxValue));

            var dateValue = resultSets[0].Single(c => c.Name == "DateValue");
            Assert.That(dateValue.StoreType, Is.EqualTo("date"));

            var timeValue = resultSets[0].Single(c => c.Name == "TimeValue");
            Assert.That(timeValue.StoreType, Is.EqualTo("time"));

            var binaryValue = resultSets[0].Single(c => c.Name == "BinaryValue");
            Assert.That(binaryValue.StoreType, Is.EqualTo("varbinary"));
            Assert.That(binaryValue.MaxLength, Is.EqualTo(2));

            var maxBinaryValue = resultSets[0].Single(c => c.Name == "MaxBinaryValue");
            Assert.That(maxBinaryValue.StoreType, Is.EqualTo("varbinary"));
            Assert.That(maxBinaryValue.MaxLength, Is.EqualTo(-1));
        }
    }
}
