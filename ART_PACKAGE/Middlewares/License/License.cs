namespace ART_PACKAGE.Middlewares.License
{
    public class License
    {
        public string Client { get; set; } = null!;
        public long ValidUnti { get; set; }
        public DateTime ExpireDate => DateTimeOffset.FromUnixTimeMilliseconds(ValidUnti).DateTime;

        public int RemainingDays => (int)DaysRemaining();


        public bool IsValid()
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(ValidUnti).DateTime.ToUniversalTime() > DateTime.UtcNow.ToUniversalTime();
        }


        public long DaysRemaining()
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(ValidUnti).DateTime.ToUniversalTime().Subtract(DateTime.UtcNow.ToUniversalTime()).Days;
        }

        public override string ToString()
        {
            return $"Client : {Client}  , ValidTo : {ValidUnti} , isValid : {IsValid()} , DaysRemaining : {DaysRemaining()}";
        }
    }
}
