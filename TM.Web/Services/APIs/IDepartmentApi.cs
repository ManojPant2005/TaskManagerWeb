using Refit;
using TM.Shared.DTOs;

namespace TM.Web.Services.APIs
{
    [Headers("Authorization : Bearer")]

    public interface IDepartmentApi
    {
        [Post("/api/department")]
        Task<QuizApiResponse> SaveDepartmentAsync(DepartmentDto dto);
        [Get("/api/department")]
        Task<DepartmentDto[]> GetDepartmentAsync();

        [Get("/api/department/subjects")]
        Task<DepartmentDto[]> GetSubjectsAsync();
        [Post("/api/department/validate")]
        Task<bool> ValidateSubjectAccessAsync([Body] ValidateSubjectDto dto);


    }
}
