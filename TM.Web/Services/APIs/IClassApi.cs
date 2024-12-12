using Refit;
using TM.Shared.DTOs;

namespace TM.Web.Services.APIs
{
    [Headers("Authorization : Bearer")]
    public interface IClassApi
    {
        [Get("/api/classes/{departmentId}")]
        Task<ClassDto[]> GetClassesByDepartmentAsync(int departmentId);

        [Post("/api/classes")]
        Task SaveClassAsync([Body] ClassDto dto);

        [Delete("/api/classes/{id}/{departmentId}")]
        Task DeleteClassAsync(int id, int departmentId);
    }
}