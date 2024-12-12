using TM.Api.Services;
using TM.Shared.DTOs;

namespace TM.Api.Endpoints
{
    public static class ClassEndpoints
    {
        public static IEndpointRouteBuilder MapClassEndpoints(this IEndpointRouteBuilder app)
        {
            var classGroup = app.MapGroup("/api/classes");

            classGroup.MapGet("/{departmentId:int}", async (int departmentId, ClassService service) =>
            {
                return Results.Ok(await service.GetClassesByDepartmentAsync(departmentId));
            });

            classGroup.MapPost("", async (ClassDto dto, ClassService service) =>
            {
                await service.SaveClassAsync(dto);
                return Results.Ok();
            });

            classGroup.MapDelete("/{id:int}/{departmentId:int}", async (int id, int departmentId, ClassService service) =>
            {
                await service.DeleteClassAsync(id, departmentId);
                return Results.Ok();
            });

            return app;
        }
    }
}