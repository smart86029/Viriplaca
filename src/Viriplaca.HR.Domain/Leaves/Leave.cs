namespace Viriplaca.HR.Domain.Leaves;

public class Leave : AggregateRoot
{
    private Leave()
    {
    }

    public Leave(LeaveType type, DateTimeOffset startedAt, DateTimeOffset endedAt, string reason, Guid employeeId)
    {
        type.MustBeDefined();

        Type = type;
        StartedAt = startedAt;
        EndedAt = endedAt;
        Reason = reason;
        EmployeeId = employeeId;
    }

    public LeaveType Type { get; private set; }

    public DateTimeOffset StartedAt { get; private set; }

    public DateTimeOffset EndedAt { get; private set; }

    public string Reason { get; private set; } = string.Empty;

    public ApprovalStatus ApprovalStatus { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;

    public Guid EmployeeId { get; private set; }

    public void Approve()
    {
        if (ApprovalStatus != ApprovalStatus.Pending)
        {
            return;
        }

        ApprovalStatus = ApprovalStatus.Approved;
    }

    public void Reject()
    {
        if (ApprovalStatus != ApprovalStatus.Pending)
        {
            return;
        }

        ApprovalStatus = ApprovalStatus.Rejected;
    }
}
