using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Defines a contract for objects that can roll.
    /// </summary>
    public interface IRolleable
    {
        /// <summary>
        /// Performs the rolling action.
        /// </summary>
        void Roll();

    }
}
