﻿using Microsoft.EntityFrameworkCore;
using MvcGo.Contracts;
using MvcGo.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGo.Repository
{
    //public class LeaveRequestRepository : ILeaveRequestRepository
    //{
    //    private readonly ApplicationDbContext _db;

    //    public LeaveRequestRepository(ApplicationDbContext db)
    //    {
    //        _db = db;
    //    }
    //    public bool Create(LeaveRequest entity)
    //    {
    //        _db.LeaveRequests.AddAsync(entity);
    //        return  Save();
    //    }

    //    public bool Delete(LeaveRequest entity)
    //    {
    //        _db.LeaveRequests.Remove(entity);
    //        return Save();
    //    }

    //    public ICollection<LeaveRequest> FindAll()
    //    {
    //        return  _db.LeaveRequests.Include(q=>q.RequestingEmployee).Include(q=>q.ApprovedBy).Include(q=>q.LeaveType).ToList();
    //    }

    //    public LeaveRequest FindById(int id)
    //    {
    //        return _db.LeaveRequests.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).FirstOrDefault(q=>q.Id == id);
    //    }

    //    public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeId)
    //    {
    //        return FindAll().Where(q=>q.RequestingEmployeeId ==  employeeId).ToList();
    //    }

    //    public bool isExists(int id)
    //    {
    //        var exists = _db.LeaveRequests.Any(q => q.Id == id);
    //        return exists;
    //    }

    //    public bool Save()
    //    {
    //        return _db.SaveChanges() > 0;
    //    }

    //    public bool Update(LeaveRequest entity)
    //    {
    //        _db.LeaveRequests.Update(entity);
    //        return Save();
    //    }
    //}

    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(LeaveRequest entity)
        {
            await _db.LeaveRequests.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveRequest>> FindAll()
        {
            var leaveRequests = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> FindById(int id)
        {
            var leaveRequest = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeid)
        {
            var leaveRequests = await FindAll();
            return leaveRequests.Where(q => q.RequestingEmployeeId == employeeid)
            .ToList();
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.LeaveRequests.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return await Save();
        }
    }
}
