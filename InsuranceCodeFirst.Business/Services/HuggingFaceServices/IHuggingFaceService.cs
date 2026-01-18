using InsuranceCodeFirst.DTO.DTOs.HugginFaceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCodeFirst.Business.Services.HuggingFaceServices
{
    public interface IHuggingFaceService
    {
        Task<ClassificationResult?> AnalizEtAsync(string metin);
    }
}
