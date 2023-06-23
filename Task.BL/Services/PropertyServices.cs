using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Task.CommonDefinitions.BaseRequest;
using Task.CommonDefinitions.DTOs;
using Task.CommonDefinitions.Responses;

namespace Task.BL.Services
{
    public class PropertyServices
    {
        public static BaseResponse<PropertyDTO> GetProperties(BaseRequest<PropertyDTO> request)
        {
            var response = new BaseResponse<PropertyDTO>();
            try
            {
                var query = request.Context.PropertysCategories.Select(Property => new PropertyDTO
                {
                    Description = Property.Property.Description,
                    ID= Property.Property.ID,
                    CategoryID = Property.Category.ID
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
        public static BaseResponse<PropertyDTO> GetProperty(BaseRequest<PropertyDTO> request)
        {
            var response = new BaseResponse<PropertyDTO>();
            try
            {
                var query = request.Context.PropertysCategories.Where(p => p.PropertyID == request.ID).Select(Property => new PropertyDTO
                {
                    Description = Property.Property.Description,
                    ID = Property.Property.ID
                }).FirstOrDefault();
                response.EntityDTO = query;
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

