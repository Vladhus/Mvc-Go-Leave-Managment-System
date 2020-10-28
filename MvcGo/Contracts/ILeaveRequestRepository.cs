using MvcGo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MvcGo.Contracts
{
    public interface ILeaveRequestRepository : IRepositoryBase<LeaveRequest>
    {
        //ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeId);
        Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeid);
    }
}
