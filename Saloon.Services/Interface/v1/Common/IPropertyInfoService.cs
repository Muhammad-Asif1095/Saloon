using System;
using System.Collections.Generic;
using Saloon.DataViewModels.Common;

namespace Saloon.Services.Interface.v1.Common
{
    public interface IPropertyInfoService
    {
        List<PropertyInfoVM> GetProperties(Guid TemplateTypeId);
    }
}
