# Property Maintenance ASP.NET Starter

This starter gives you a practical baseline for your dad's property maintenance platform with:

- ASP.NET Core 8 Web app
- Identity + role-based authorization (`Owner`, `Admin`, `Technician`, `Client`)
- EF Core `AppDbContext` with core domain entities
- SignalR `JobsHub` for real-time Kanban notifications
- API endpoint for updating job status and writing audit logs

## Suggested next steps

1. Install .NET 8 SDK and scaffold a solution around `PropertyMaintenance.Web`.
2. Add your connection string in `appsettings.json`.
3. Run EF Core migrations:
   - `dotnet ef migrations add InitialCreate`
   - `dotnet ef database update`
4. Add public MVC pages (`Home`, `Services`, `Contact`) and client/admin portals.
5. Implement quote, booking, invoicing, and attachment flows.
6. Add email/SMS notifications and a background worker.

## Key files

- `PropertyMaintenance.Web/Program.cs`: app composition, Identity, policies, role seeding.
- `PropertyMaintenance.Web/Data/AppDbContext.cs`: EF Core DbSets and relationships.
- `PropertyMaintenance.Web/Models/Entities.cs`: core entities and enums.
- `PropertyMaintenance.Web/Controllers/JobsController.cs`: role-protected status update endpoint with SignalR broadcast.
- `PropertyMaintenance.Web/Hubs/JobsHub.cs`: admin-group subscription for real-time Kanban updates.

Use this as MVP scaffolding, then split into `Core`, `Infrastructure`, and `Web` projects as the codebase grows.
