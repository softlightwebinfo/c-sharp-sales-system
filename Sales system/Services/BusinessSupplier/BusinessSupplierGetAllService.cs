using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sales_system.Exceptions.Business;
using Sales_system.Interfaces.Services.Business;
using Sales_system.Models;
using Sales_system.Models.Response;
using Sales_system.Models.ResponseModel;

namespace Sales_system.Services.BusinessSupplier
{
    public class BusinessSupplierGetAllService : IBusinessSuppliersService
    {
        public BusinessSuppliersResponse GetAll(long id)
        {
            var response = new BusinessSuppliersResponse();
            using var db = new salesSystemContext();
            var lst = db.BusinessSuppliers
                .Where(e => e.FkBusinessId == id)
                .Where(e => !e.FkSupplier.DeletedAt.HasValue)
                .Select(supplier => new BusinessSupplierItem
                {
                    Id = supplier.FkSupplier.Id,
                    Email = supplier.FkSupplier.Email,
                    Phone = supplier.FkSupplier.Phone,
                    Name = supplier.FkSupplier.SupplierName,
                    UpdatedAt = supplier.FkSupplier.UpdatedAt
                })
                .ToList();

            if (lst.Count == 0)
            {
                throw new BusinessExection("No se ha encontrado ningun proveedor asociado a esta empresa");
            }

            response.Count = lst.Count;
            response.List = lst;
            response.Total = lst.Count;
            return response;
        }
    }
}