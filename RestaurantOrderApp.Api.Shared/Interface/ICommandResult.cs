namespace RestaurantOrderApp.Api.Shared.Interface
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        string Message { get; set; }
        int CodeReturn { get; set; }
        object FinalResult { get; set; }
    }
}
