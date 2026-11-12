namespace TaskA
{
    internal class Program
    {
        public static string ExpirationStatus(DateTime? expirationDate, DateTime today)
        {
            if (expirationDate == null)
            {
                throw new ArgumentException("Missing expiration date");
            }

            int days = (expirationDate.Value.Date - today.Date).Days;

            if (days < 0)
            {
                return "EXPIRED";
            }
            else if (days == 0)
            {
                return "USE_TODAY";
            }
            else if (days >= 1 && days <= 3)
            {
                return "USE_SOON";
            }
            else
            {
                return "OK";
            }
        }
    }
}
