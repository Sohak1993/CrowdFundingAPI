using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Mapper
{
    public abstract class ObjectMapper
    {
        public virtual To MapModel<To, U>(U mappedModel)
        {
            var type = typeof(To);

            To obj = (To)Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties())
            {
                var propType = prop.PropertyType;
                if (propType == typeof(DateOnly))
                {
                    prop.SetValue(obj, DateOnly.Parse(mappedModel.GetType().GetProperty(prop.Name).GetValue(mappedModel).ToString().Substring(0, 8)));
                }
                else
                {
                    if (mappedModel.GetType().GetProperty(prop.Name) != null)
                    {
                        prop.SetValue(obj, mappedModel.GetType().GetProperty(prop.Name).GetValue(mappedModel));
                    }
                }
            }
            return obj;
        }
    }
}
