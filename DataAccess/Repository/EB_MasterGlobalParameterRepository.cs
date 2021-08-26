using DataAccess.Interface;
using DataAccess.Model;
using DataAccess.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EB_MasterGlobalParameterRepository : RepoSQLDBRepository<EB_MasterGlobalParameter>
    {
        public EB_MasterGlobalParameterRepository(IUnitofWork uow) : base(uow) { }
    }
}
