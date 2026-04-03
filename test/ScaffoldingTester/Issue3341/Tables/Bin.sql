CREATE TABLE dbo.Bin (
    BinId           INT NOT NULL IDENTITY (1, 1),
    InventoryNodeId INT NOT NULL,
    InventoryNodeTypeCode AS (CONVERT(TINYINT, 8)) PERSISTED NOT NULL,
    CONSTRAINT PK_dbo_Bin PRIMARY KEY CLUSTERED (BinId),
    CONSTRAINT FK_dbo_Bin_dbo_InventoryNodeTypeCode FOREIGN KEY (InventoryNodeTypeCode) REFERENCES dbo.InventoryNodeTypeLookup (InventoryNodeTypeCode),
    CONSTRAINT FK_dbo_Bin_InventoryNodeId_InventoryNodeTypeCode_dbo_InventoryNode FOREIGN KEY (InventoryNodeId, InventoryNodeTypeCode) REFERENCES dbo.InventoryNode (InventoryNodeId, InventoryNodeTypeCode),
);
GO