using HRMS.Web.Models.LeaveAllocations;

namespace HRMS.Web.Services.LeaveAllocations
{
    public interface IleaveAllocationsService
    {
       Task AllocateLeave(string employeeId); 

        Task<List<LeaveAllocation>> GetAllocations(string? userId);

        Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);

        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId);
        Task<List<EmployeeListVM>> GetEmployees();

        Task EditAllocation(LeaveAllocationEditVM allocationEditVm);
        Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId);

    }
}
