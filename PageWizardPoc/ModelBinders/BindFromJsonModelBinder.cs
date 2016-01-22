using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PageWizardPoc.Attributes;

namespace PageWizardPoc.ModelBinders
{
    public class BindFromJsonModelBinder : DefaultModelBinder
    {
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.Attributes.OfType<Attribute>().Any(x => (x is BindFromJsonAttribute)))
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
                return JsonConvert.DeserializeObject(value, propertyDescriptor.PropertyType);
            }

            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    }
}