namespace AspAirlinesWebApp.ViewModels
{
    public enum PropertySort
    {
        Airline,
        Departure,
        Arrival,
        Date
    }
    public class SortViewModel
    {
        public bool DirectionSort { get; set; }
        public PropertySort PropertySort { get; set; }

        public SortViewModel(PropertySort propertySort, bool directionSort)
        {
            PropertySort = propertySort;
            DirectionSort = directionSort;
        }
    }
}
