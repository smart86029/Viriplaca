namespace Viriplaca.HR.App.Jobs.GetJobs;

public class JobDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool IsEnabled { get; set; }

    public int EmployeeCount { get; set; }
}
