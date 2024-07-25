using AutoMapper;
using HRMS.Web.Models.LeaveAllocations;
using HRMS.Web.Services.LeaveAllocations;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Web.Services.LeaveAllocations
{
    public class LeaveAllocationService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager, IMapper _mapper) : IleaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            var leaveTypes = await _context.LeaveTypes
           .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
           .ToListAsync();

            var currentDate = DateTime.Now;

            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);

            var monthRemaining = period.EndDate.Month - currentDate.Month;

            foreach (var leaveType in leaveTypes)
            {
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);

                var leaveAllocation = new LeaveAllocation { EmployeeId = employeeId, LeaveTypeId = leaveType.Id, PeriodId = period.Id, Days = Convert.ToInt32(Math.Ceiling(accuralRate * monthRemaining)) };

                _context.Add(leaveAllocation);
            }

            _context.SaveChanges(); 
           

        }

        public async Task EditAllocation(LeaveAllocationEditVM allocationEditVm)
        {
            await _context.LeaveAllocations
         .Where(q => q.Id == allocationEditVm.Id)
         .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVm.Days));
        }

        public async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {

            string employeeId = string.Empty;
            if(string.IsNullOrEmpty(userId))
            {
                employeeId = userId;
            }
            else
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
                employeeId = user.Id;
            }
           

            var currentDate = DateTime.Now;

            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Period)
                .Where(q => q.EmployeeId == employeeId && q.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
               .Include(q => q.LeaveType)
               .Include(q => q.Employee)
               .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

            return model;
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {

            var user = string.IsNullOrEmpty(userId) ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User) : await _userManager.FindByIdAsync(userId);

            var allocations = await GetAllocations(user.Id);
            var allocationVmList = _mapper.Map<List<LeaveAllocation>,List<LeaveAllocationVM>>(allocations);

            var leaveTypesCount = await _context.LeaveTypes.CountAsync();



            var employeeVm = new EmployeeAllocationVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationVmList,
                IscompletedAllocation = leaveTypesCount == allocations.Count
            };

            return employeeVm;

        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());

            return employees;

        }


        private async Task<bool> AllocationExists(string userId, int periodId, int leaveTypeId)
        {
            var exists = await _context.LeaveAllocations.AnyAsync(q =>
                q.EmployeeId == userId
                && q.LeaveTypeId == leaveTypeId
                && q.PeriodId == periodId
            );

            return exists;
        }

    }


}
