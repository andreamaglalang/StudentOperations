
using StudentOperations.Application.Services;

namespace StudentOperations.Infrastructure.Jobs;

public class EnrollmentJob
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentJob(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task ProcessEnrollmentAsync(int requestId)
    {
        await _enrollmentService.ProcessEnrollmentAsync(requestId);
    }

    public async Task SendConfirmationAsync(int requestId)
    {
        await _enrollmentService.SendConfirmationAsync(requestId);
    }

    public async Task ProcessPendingAsync()
    {
        await _enrollmentService.ProcessPendingAsync();
    }

    public async Task ProcessBatchAsync()
    {
        await _enrollmentService.ProcessBatchAsync();
    }
}
