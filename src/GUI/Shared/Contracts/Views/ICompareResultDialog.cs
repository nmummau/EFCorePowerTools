using System.Collections.Generic;
using EFCorePowerTools.Handlers.Compare;

namespace EFCorePowerTools.Contracts.Views;

public interface ICompareResultDialog : IDialog<object>
{
    public void AddComparisonResult(IEnumerable<CompareLogModel> result);
}