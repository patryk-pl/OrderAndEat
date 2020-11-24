using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Core
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryDto> GetAllCategory();

    }
}
