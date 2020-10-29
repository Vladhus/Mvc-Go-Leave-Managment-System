using MvcGo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MvcGo.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        Task<ICollection<LeaveType>> GetEmployeesByLeaveType(int id);
    }
}
