using System;
using System.Collections.Generic;
using System.Text;

namespace UtilHelper.TimeModuleAndUniqueIds
{
    class UniqueIdGenerator
    {
        public static Guid GenerateUuid()
        {
            return System.Guid.NewGuid();
        }
    }
}
