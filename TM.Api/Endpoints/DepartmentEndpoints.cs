using TM.Api.Services;
using TM.Shared;
using TM.Shared.DTOs;

namespace TM.Api.Endpoints
{
    public static class DepartmentEndpoints
    {
        public static IEndpointRouteBuilder MapDepartmentEndpoint(this IEndpointRouteBuilder app)
        {
            var catGroup = app.MapGroup("/api/department");

            catGroup.MapGet("", async (DepartmentService deptService) =>
            Results.Ok(await deptService.GetDepartmentsAsync()));

            catGroup.MapPost("", async (DepartmentDto dto, DepartmentService service) =>
            Results.Ok(await service.SaveDepartmentAsync(dto))).RequireAuthorization(p => p.RequireRole(nameof(UserRole.Admin)));

            catGroup.MapGet("/subjects", async (DepartmentService deptService) =>
            Results.Ok(await deptService.GetDepartmentsAsync()));


            catGroup.MapPost("/validate", async (ValidateSubjectDto dto, DepartmentService deptService) =>
            {
                bool isValid = await deptService.ValidateSubjectAccessAsync(dto); 
                return Results.Ok(isValid);
            });



            return app;
        }
    }
}
