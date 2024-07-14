using Services.Shoot;
using UI.Core;

namespace UI.Shoot
{
    public class ShootController : UiController<ShootButtonView>
    {
        private readonly IShootService _shootService;

        public ShootController(
            ShootButtonView view, 
            IShootService shootService
        ) : base(view)
        {
            _shootService = shootService;
        }

        protected override void OnInitialize()
        {
            View.Shoot += Shoot;
        }

        public override void Dispose()
        {
            View.Shoot -= Shoot;
        }

        private void Shoot()
        {
            _shootService.Shoot();
        }
    }
}