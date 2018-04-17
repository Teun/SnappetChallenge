namespace Nicollas.Dto.Realtime
{
    public enum ActionNeeded
    {
        DoCallback = 1,
        RefreshReducer = 2,
        RefreshByResponse = 3,

        Init = 4
    }
}
