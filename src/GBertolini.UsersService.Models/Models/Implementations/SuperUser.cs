namespace GBertolini.UsersService.Models.Models.Implementations
{
    public class SuperUser : User
    {
        private decimal ResolveGiftPercentage()
                => Money > 100 ? (decimal)0.20 : (decimal)0.00;

        public override void ApplyGift()
                => Money *= 1 + ResolveGiftPercentage();
    }
}
