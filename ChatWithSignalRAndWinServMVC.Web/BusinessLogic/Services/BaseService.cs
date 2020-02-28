using ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork;

namespace ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services
{
    public class BaseService
    {
        protected readonly IBaseUnitOfWork _database;

        public BaseService(IBaseUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }
    }
}
