using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestaurantOrderApp.Api.Infra.Resources.Queries
{
    public class GetDishesQuery : IRequest<string>
    {
        [JsonProperty("timeofday")]
        public string TimeOfDay { get; set; }
        [JsonProperty("dishtype")]
        public List<int> DishType { get; set; }
    }
}
