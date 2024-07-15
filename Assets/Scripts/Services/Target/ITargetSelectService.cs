using Models;
using Models.Entity;

namespace Services.Target
{
    public interface ITargetSelectService
    {
        GameEntity SelectTarget();
    }
}