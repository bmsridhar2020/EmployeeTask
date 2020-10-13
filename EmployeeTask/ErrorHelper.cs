using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTask
{
    public static class ErrorHelper
    {
        public static string FormatErrorMessage(string errorCategory, string errorDescription)
        {
            var error = new ErrorMessage
            {
                ErrorCategory = errorCategory,
                ErrorDescription = errorDescription
            };
            return JsonConvert.SerializeObject(error);
        }
    }

    public class ErrorMessage
    {
        public string ErrorCategory { get; set; }
        public string ErrorDescription { get; set; }
    }
}
