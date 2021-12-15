using Begge.Models.DatabaseModels;
using Begge.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Begge.Services.Mappers
{
    public static class BeggerDTOExtensionMapper
    {
        public static ResponseAuthDTO GetAuthDTO(this Begger model)
        {
            return new ResponseAuthDTO
            {
                Email = model.Email,
                Role = model.Role.Name
            };
        }
    }
}
