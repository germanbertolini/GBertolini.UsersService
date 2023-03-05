namespace GBertolini.UsersService.Models.Models.Implementations
{
    public class PremiumUser : User
    {
        private decimal ResolveGiftPercentage()
                => Money > 100 ? (decimal)2.00 : (decimal)0.00;

        public override void ApplyGift()
                => Money *= 1 + ResolveGiftPercentage();
    }
}
