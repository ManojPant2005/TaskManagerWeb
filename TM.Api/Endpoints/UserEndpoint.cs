
using TM.Api.Services;
using TM.Shared;

namespace TM.Api.Endpoints
{
    public static class UserEndpoint
    {
        public static IEndpointRouteBuilder MapUserEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users")
                           .RequireAuthorization(p => p.RequireRole(nameof(UserRole.Admin)));

            group.MapGet("", async (UserApprovedFilter filter, int startIndex, int PazeSize, UserService service) =>
            Results.Ok(await service.GetUsersAsync(filter, startIndex, PazeSize)));

            group.MapPatch("{userId:int}/toggle-status", async (int userId, UserService service) =>
            {
                await service.ToggleUserApprovedStatus(userId);
                return Results.Ok();    
            });
            
            return app;
        }
    }
}
