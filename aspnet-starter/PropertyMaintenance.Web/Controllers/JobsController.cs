using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PropertyMaintenance.Web.Data;
using PropertyMaintenance.Web.DTOs;
using PropertyMaintenance.Web.Hubs;
using PropertyMaintenance.Web.Models;

namespace PropertyMaintenance.Web.Controllers;

[ApiController]
[Route("api/jobs")]
[Authorize(Roles = "Owner,Admin,Technician")]
public class JobsController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IHubContext<JobsHub> _hub;

    public JobsController(AppDbContext db, IHubContext<JobsHub> hub)
    {
        _db = db;
        _hub = hub;
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateJobStatusDto dto)
    {
        var job = await _db.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        if (job is null)
        {
            return NotFound();
        }

        if (job.Status == dto.Status)
        {
            return Ok(new { message = "Status unchanged." });
        }

        var oldStatus = job.Status;
        job.Status = dto.Status;

        _db.JobStatusLogs.Add(new JobStatusLog
        {
            JobId = job.Id,
            OldStatus = oldStatus,
            NewStatus = dto.Status,
            ChangedByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system"
        });

        await _db.SaveChangesAsync();
        await _hub.Clients.Group("admins").SendAsync("JobStatusChanged", job.Id, dto.Status.ToString());

        return Ok(new { job.Id, NewStatus = dto.Status.ToString() });
    }
}
