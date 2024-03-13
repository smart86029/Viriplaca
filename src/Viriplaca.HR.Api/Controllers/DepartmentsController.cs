using Viriplaca.HR.App.Departments.GetDepartment;
using Viriplaca.HR.App.Departments.GetDepartmentOptions;
using Viriplaca.HR.App.Departments.GetDepartments;

namespace Viriplaca.HR.Api.Controllers;

public class DepartmentsController : ApiController<DepartmentsController>
{
    [HttpGet("Options")]
    public async Task<IActionResult> GetDepartmentOptions([FromQuery] GetDepartmentOptionsQuery query)
    {
        var result = await Sender.Send(query);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments([FromQuery] GetDepartmentsQuery query)
    {
        var result = await Sender.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartment([FromRoute] Guid id)
    {
        var result = await Sender.Send(new GetDepartmentQuery(id));

        return Ok(result);
    }
}
