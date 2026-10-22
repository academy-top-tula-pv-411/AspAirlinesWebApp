namespace AspAirlinesWebApp.ViewModels
{
    public enum SortState
    {
        AirlineAsc,
        AirlineDesc,
        DepartureAsc,
        DepartureDesc,
        ArrivalAsc,
        ArrivalDesc,
        DateAsc,
        DateDesc
    }
    public class SortViewModel
    {
        public SortState AirlineState { get; set; }
        public SortState DepartureState { get; set; }
        public SortState ArrivalState { get; set; }
        public SortState DateState { get; set; }
        public SortState CurrentState { get; set; }
        public SortViewModel(SortState sortState)
        {
            AirlineState = SortState.AirlineAsc;
            DepartureState = SortState.DepartureAsc;
            ArrivalState = SortState.ArrivalAsc;
            DateState = SortState.DateAsc;

            CurrentState = sortState;

            //switch (sortState)
            //{
            //    case SortState.AirlineAsc:
            //        CurrentState = AirlineState = SortState.AirlineDesc;
            //        break;
            //    case SortState.AirlineDesc:
            //        CurrentState = AirlineState = SortState.AirlineAsc;
            //        break;
            //    case SortState.DepartureAsc:
            //        CurrentState = DepartureState = SortState.DepartureDesc;
            //        break;
            //    case SortState.DepartureDesc:
            //        CurrentState = DepartureState = SortState.DepartureAsc;
            //        break;
            //    case SortState.ArrivalAsc:
            //        CurrentState = ArrivalState = SortState.ArrivalDesc;
            //        break;
            //    case SortState.ArrivalDesc:
            //        CurrentState = ArrivalState = SortState.ArrivalAsc;
            //        break;
            //    case SortState.DateAsc:
            //        CurrentState = DateState = SortState.DateDesc;
            //        break;
            //    case SortState.DateDesc:
            //        CurrentState = DateState = SortState.DateAsc;
            //        break;
            //    default:
            //        break;
            //}

        }
    }
}
