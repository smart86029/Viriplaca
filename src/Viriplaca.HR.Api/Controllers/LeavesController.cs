using Viriplaca.HR.App.Leaves.ApplyLeave;
using Viriplaca.HR.App.Leaves.CancelLeave;
using Viriplaca.HR.App.Leaves.GetLeave;
using Viriplaca.HR.App.Leaves.GetLeaves;
using Viriplaca.HR.App.Leaves.GetLeaveTypes;
using Viriplaca.HR.App.Leaves.UpdateApprovalStatus;

namespace Viriplaca.HR.Api.Controllers;

public class LeavesController : ApiController<LeavesController>
{
    [HttpGet("Types")]
    public async Task<IActionResult> GetLeaveTypes([FromQuery] GetLeaveTypesQuery query)
    {
        var result = await Sender.Send(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetLeaves([FromQuery] GetLeavesQuery query)
    {
        var result = await Sender.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLeave(Guid id)
    {
        var result = await Sender.Send(new GetLeaveQuery(id));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> ApplyLeave([FromBody] ApplyLeaveCommand command)
    {
        var result = await Sender.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelLeave(Guid id)
    {
        await Sender.Send(new CancelLeaveCommand(id));

        return Ok();
    }

    [HttpPut("{id}/ApprovalStatus")]
    public async Task<IActionResult> UpdateApprovalStatus(Guid id, [FromBody] UpdateApprovalStatusCommand command)
    {
        command = command with { Id = id };
        await Sender.Send(command);

        return Ok();
    }
}
