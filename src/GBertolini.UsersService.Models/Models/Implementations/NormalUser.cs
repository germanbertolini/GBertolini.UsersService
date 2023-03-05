namespace GBertolini.UsersService.Models.Models.Implementations
{
    public class NormalUser : User
    {
        private decimal ResolveGiftPercentage()
                => Money > 100 ? (decimal)0.12 :
                   Money > 10 && Money < 100 ? (decimal)0.8 :
                                                (decimal)0.00;

        public override void ApplyGift()
                => Money *= 1 + ResolveGiftPercentage();
    }
}
