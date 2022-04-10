namespace RestaurantOrderApp.Api.Shared.Enums
{
    public enum RetornoApi
    {
        Sucess = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        NotAcceptable = 406,
        UnsupportedMedia = 415,
        UnprocessableEntity = 422,
        TooManyRequests = 429,
        InternalServerError = 500,
        ServiceUnavailable = 503,
        TimeOut = 504
    }
}
