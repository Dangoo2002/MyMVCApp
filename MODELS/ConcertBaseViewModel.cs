public class ConcertBaseViewModel : ConcertAddViewModel
{
    public int ConcertId { get; set; }

    public string DaysToGo
    {
        get
        {
            var dtNow = DateTime.Now.Date;
            if (ConcertDate < dtNow)
                return "No longer available";

            var days = Math.Floor((ConcertDate - dtNow).TotalDays);
            return days == 1.0 ? "Tomorrow" : $"{days:n0} days to go";
        }
    }
}
