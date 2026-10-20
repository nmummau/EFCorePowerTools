using System.Collections.Generic;
using EFCorePowerTools.Common.Models;

namespace EFCorePowerTools.DAL;

public interface ICredentialStore
{
    public bool DeleteCredential(string name);

    public List<DatabaseConnectionModel> GetStoredDatabaseConnections();

    public bool SaveCredential(DatabaseConnectionModel connectionModel);
}