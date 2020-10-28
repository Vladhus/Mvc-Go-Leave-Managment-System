using MvcGo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MvcGo.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        //ICollection<LeaveType> GetEmployeesByLeaveType(int id);
        Task<ICollection<LeaveType>> GetEmployeesByLeaveType(int id);
    }
}
