namespace EFCorePowerTools.Common.DAL;

public interface ITelemetryAccess
{
    public void TrackPageView(string key);
}