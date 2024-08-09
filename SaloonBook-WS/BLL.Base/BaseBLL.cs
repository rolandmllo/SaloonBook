using BLL.Contracts.Base;
using DAL.Contracts.Base;

namespace BLL.Base;

public abstract class BaseBLL<TOUW> : IBaseBLL
where TOUW : IBaseUOW
{
    
    protected readonly TOUW Uow;

    protected BaseBLL(TOUW uow)
    {
        Uow = uow;
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await Uow.SaveChangesAsync();
    }
}