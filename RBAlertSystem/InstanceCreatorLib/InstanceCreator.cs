//=============================================================================
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//============================================================================= 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace InstanceCreatorLib
{
    /// <summary>
    /// It creates and returns an instance of the required class
    /// </summary>
    public static class InstanceCreator
    {
        /// <summary>
        /// This function creates an instance of the specified class
        /// </summary>
        /// <param name="property"></param>
        /// <param name="name"></param>
        /// <returns>object of the specified class</returns>
        public static object Create_Instance(string property, string name)
        {
            string className = property + name+"Lib." + property +name+ "," + property+name + "Lib";
             Type type = Type.GetType(className);
            object instance = Activator.CreateInstance(type);
            return instance;
        }
    }
}
