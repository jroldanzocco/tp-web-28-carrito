using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Common
{
    public static class Validations
    {
        public static bool DataAnnotations(object obj)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(obj, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, results, true);

            return isValid;
        }
    }
}
