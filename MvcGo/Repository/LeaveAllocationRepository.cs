using Microsoft.EntityFrameworkCore;
using MvcGo.Contracts;
using MvcGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGo.Repository
{
    //public class LeaveAllocationRepository : ILeaveAllocationRepository
    //{
    //    private readonly ApplicationDbContext _db;

    //    public LeaveAllocationRepository(ApplicationDbContext db)
    //    {
    //        _db = db;
    //    }

    //    public bool CheckAllocation(int leavetypeId, string employeeId)
    //    {
    //        var period = DateTime.Now.Year;
    //        return FindAll().Where(q => q.EmployeeId == employeeId && q.LeaveTypeId == leavetypeId && q.Period == period).Any();
    //    }

    //    public bool Create(LeaveAllocation entity)
    //    {
    //        _db.LeaveAllocations.Add(entity);
    //        return Save();
    //    }

    //    public bool Delete(LeaveAllocation entity)
    //    {
    //        _db.LeaveAllocations.Remove(entity);
    //        return Save();
    //    }

    //    public ICollection<LeaveAllocation> FindAll()
    //    {
    //        return _db.LeaveAllocations.Include(q=>q.LeaveType).ToList();
    //    }

    //    public LeaveAllocation FindById(int id)
    //    {
    //        return _db.LeaveAllocations.Include(q=>q.Employee).Include(q=>q.LeaveType).FirstOrDefault(q=>q.Id == id);
    //    }

    //    public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id)
    //    {
    //        var period = DateTime.Now.Year;
    //        return FindAll()
    //            .Where(q => q.EmployeeId == id && q.Period == period)
    //            .ToList();
    //    }

    //    public LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string id, int leavetypeid)
    //    {
    //        var period = DateTime.Now.Year;
    //        return FindAll()
    //            .FirstOrDefault(q => q.EmployeeId == id && q.Period == period && q.LeaveTypeId == leavetypeid);
    //    }

    //    public bool isExists(int id)
    //    {
    //        var exists = _db.LeaveAllocations.Any(q => q.Id == id);
    //        return exists;
    //    }

    //    public bool Save()
    //    {
    //        return _db.SaveChanges() > 0;
    //    }

    //    public bool Update(LeaveAllocation entity)
    //    {
    //        _db.LeaveAllocations.Update(entity);
    //        return Save();
    //    }
    //}
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckAllocation(int leavetypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations.Where(q => q.EmployeeId == employeeid
                                        && q.LeaveTypeId == leavetypeid
                                        && q.Period == period)
                .Any();
        }

        public async Task<bool> Create(LeaveAllocation entity)
        {
            await _db.LeaveAllocations.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveAllocation>> FindAll()
        {
            var LeaveAllocations = await _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .ToListAsync();
            return LeaveAllocations;
        }

        public async Task<LeaveAllocation> FindById(int id)
        {
            var LeaveAllocation = await _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefaultAsync(q => q.Id == id);
            return LeaveAllocation;
        }

        public async Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string employeeid)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations.Where(q => q.EmployeeId == employeeid && q.Period == period)
                    .ToList();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid)
        {
            var period = DateTime.Now.Year;
            var allocations = await FindAll();
            return allocations.FirstOrDefault(q => q.EmployeeId == employeeid
                                                    && q.Period == period
                                                    && q.LeaveTypeId == leavetypeid);
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.LeaveAllocations.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return await Save();
        }
    }
}
