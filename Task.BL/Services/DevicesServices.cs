using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Task.CommonDefinitions.BaseRequest;
using Task.CommonDefinitions.DTOs;
using Task.CommonDefinitions.Responses;
using Task.DAL.DB;

namespace Task.BL.Services
{
    public class DevicesServices
    {
        public static BaseResponse<DeviceDTO> GetDevices(BaseRequest<DeviceDTO> request)
        {
            var response = new BaseResponse<DeviceDTO>();
            try
            {
                var query = request.Context.Device.Select(Device => new DeviceDTO
                {
                    ID = Device.ID,
                    Memo = Device.Memo,
                    AcquisitionDate = Device.AcquisitionDate,
                    CategoryID = Device.CategoryID,
                    DeviceCategoryName = Device.Category.CategoryName,
                    DeviceName = Device.DeviceName,
                    SerialNo = Device.SerialNo,
                    DevicePropertiesDTOs = Device.DeviceProperties.Select(d=>new DevicePropertiesDTO
                    {
                        Value = d.Value,
                        PropertyName = d.Property.Description,
                        ID = d.Property.ID,
                    })
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

        public static BaseResponse<DeviceDTO> GetDevice(BaseRequest<DeviceDTO> request)
        {
            var response = new BaseResponse<DeviceDTO>();
            try
            {
                var query = request.Context.Device.Where(Device=> Device.ID == request.ID).Select(Device => new DeviceDTO
                {
                    ID = Device.ID,
                    Memo = Device.Memo,
                    AcquisitionDate = Device.AcquisitionDate,
                    CategoryID = Device.CategoryID,
                    DeviceCategoryName = Device.Category.CategoryName,
                    DeviceName = Device.DeviceName,
                    SerialNo = Device.SerialNo,
                    DevicePropertiesDTOs = Device.DeviceProperties.Select(d => new DevicePropertiesDTO
                    {
                        Value = d.Value,
                        PropertyName = d.Property.Description,
                        ID= d.Property.ID,
                    })
                });
                response.EntityDTO = query.FirstOrDefault();
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

        public static BaseResponse<DeviceDTO> CreateDevice(BaseRequest<DeviceDTO> request)
        {
            var response = new BaseResponse<DeviceDTO>();
            try
            {
                var PropIDs = request.EntityDTO.PropertyID.Split(',').Select<string, int>(int.Parse).ToList();
                var PropValues = request.EntityDTO.Value.Split(',').ToList();
                Device device = new Device
                {
                    AcquisitionDate = request.EntityDTO.AcquisitionDate,
                    CategoryID = request.EntityDTO.CategoryID,
                    Memo = request.EntityDTO.Memo,
                    SerialNo = request.EntityDTO.SerialNo,
                    DeviceName = request.EntityDTO.DeviceName
                };
                request.Context.Device.Add(device);
                request.Context.SaveChanges();

                for (int i = 0; i < PropIDs.Count; i++)
                {
                    if (!string.IsNullOrEmpty(PropValues[i]))
                    {
                        request.Context.DeviceProperties.Add(new DeviceProperties
                        {
                            PropertyID = PropIDs[i],
                            Value = PropValues[i],
                            DeviceID = device.ID,
                        });
                    }

                }
                request.Context.SaveChanges();
                response.Message = "Add Device Successfully";
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

        public static BaseResponse<DeviceDTO> EditDevice(BaseRequest<DeviceDTO> request)
        {
            var response = new BaseResponse<DeviceDTO>();
            try
            {
                var PropIDs = request.EntityDTO.PropertyID.Split(',').Select<string, int>(int.Parse).ToList();
                var PropValues = request.EntityDTO.Value.Split(',').ToList();
                var device = request.Context.Device.Find(request.EntityDTO.ID);
                if (device != null)
                {
                    device.AcquisitionDate = request.EntityDTO.AcquisitionDate;
                    device.Memo = request.EntityDTO.Memo;
                    device.SerialNo = request.EntityDTO.SerialNo;
                    device.DeviceName = request.EntityDTO.DeviceName;

                    var DeviceProperties = request.Context.DeviceProperties.Where(d => d.DeviceID == device.ID).ToList();

                    if (device.CategoryID == request.EntityDTO.CategoryID)
                    {
                        for (int i = 0; i < PropIDs.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(PropValues[i]))
                            {
                                DeviceProperties[i].Value = PropValues[i];
                            }
                        }
                    }
                    else
                    {
                        request.Context.DeviceProperties.RemoveRange(DeviceProperties);
                        request.Context.SaveChanges();
                        for (int i = 0; i < PropIDs.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(PropValues[i]))
                                request.Context.DeviceProperties.Add(new DeviceProperties
                                {
                                    PropertyID = PropIDs[i],
                                    Value = PropValues[i],
                                    DeviceID = device.ID,
                                });
                        }
                    }
                    device.CategoryID = request.EntityDTO.CategoryID;
                    request.Context.SaveChanges();
                    response.Message = "Edit Device Successfully";
                    response.Success = true;
                    response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Fild";
                    response.Success = false;
                }
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

