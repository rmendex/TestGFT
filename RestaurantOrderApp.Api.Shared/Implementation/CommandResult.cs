using RestaurantOrderApp.Api.Shared.Enums;
using RestaurantOrderApp.Api.Shared.Interface;

namespace RestaurantOrderApp.Api.Shared.Implementation
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }
        public CommandResult(bool sucess, string message, RetornoApi codeReturn, object finalResult)
        {
            Sucess = sucess;
            Message = message;
            CodeReturn = (int)codeReturn;
            FinalResult = finalResult;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public int CodeReturn { get; set; }
        public object FinalResult { get; set; }
    }
}
