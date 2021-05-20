
using SYS.Models;

namespace SYS.Repositories
{
    public class AirplaneRepository : RepositoryBase<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(contextclass contextClass)
            : base(contextClass)
        {
        }
    

    }
}
