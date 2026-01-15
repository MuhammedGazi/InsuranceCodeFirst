using InsuranceCodeFirst.DTO.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCodeFirst.Business.Services.CategoryServices
{
    public interface ICategoryService:IGenericService<CreateCategoryDto,UpdateCategoryDto,ResulCategoryDto>
    {
    }
}
