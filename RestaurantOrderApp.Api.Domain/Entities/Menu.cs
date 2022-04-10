namespace RestaurantOrderApp.Api.Domain.Entities
{
    public class Menu
    {
        public Menu()
        {

        }

        public Menu(int Id, int DishType, string TimeOfDay, string Meal)
        {
            this.Id = Id;
            this.DishType = DishType;
            this.TimeOfDay = TimeOfDay;
            this.Meal = Meal;
        }

        public int Id { get; set; }
        public int DishType { get; set; }
        public string TimeOfDay { get; set; }
        public string Meal { get; set; }

        public override bool Equals(object obj)
        {
            return this.Id == ((Menu)obj).Id &&
                   this.DishType == ((Menu)obj).DishType &&
                   this.TimeOfDay == ((Menu)obj).TimeOfDay &&
                   this.Meal == ((Menu)obj).Meal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
