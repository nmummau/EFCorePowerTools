CREATE TABLE dbo.InventoryNode (
    InventoryNodeId        INT     NOT NULL IDENTITY (1, 1),
    InventoryNodeTypeCode  TINYINT NOT NULL,
    CONSTRAINT PK_dbo_InventoryNode PRIMARY KEY CLUSTERED (InventoryNodeId),
    CONSTRAINT FK_dbo_InventoryNode_InventoryNodeTypeLookup FOREIGN KEY (InventoryNodeTypeCode) REFERENCES dbo.InventoryNodeTypeLookup (InventoryNodeTypeCode)
);
GO

-- This unique index allows us to enforce the type code on dbo.Bin table via foreign key.
CREATE UNIQUE NONCLUSTERED INDEX UQ_dbo_InventoryNode_InventoryNodeId_InventoryNodeTypeCode
    ON dbo.InventoryNode (InventoryNodeId, InventoryNodeTypeCode);
GO