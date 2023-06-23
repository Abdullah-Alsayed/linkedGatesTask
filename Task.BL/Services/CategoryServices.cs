using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Net;
using Task.CommonDefinitions.BaseRequest;
using Task.CommonDefinitions.DTOs;
using Task.CommonDefinitions.Responses;
using Task.DAL.DB;

namespace Task.BL.Services
{
    public class CategoryServices
    {
        public static BaseResponse<CategoryDTO> GetCategoryes(BaseRequest<CategoryDTO> request)
        {
            var response = new BaseResponse<CategoryDTO>();
            try
            {
                var query = request.Context.Category.Select(Category => new CategoryDTO
                {
                    ID = Category.ID,
                    CategoryName = Category.CategoryName,
                }).ToList();
                response.EntityDTOs = query;
                response.Message = HttpStatusCode.OK.ToString();
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}

