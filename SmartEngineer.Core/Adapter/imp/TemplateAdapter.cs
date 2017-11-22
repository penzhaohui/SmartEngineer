using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.IO;

namespace SmartEngineer.Core.Adapter
{
    public class TemplateAdapter : ITemplateAdapter
    {
        private static IRazorEngineService _razorEngineService;

        private IRazorEngineService RazorEngine
        {
            get {

                if (_razorEngineService == null)
                {
                    var templatePath = "Templates\\Email";
                    // Find templates in a web application
                    var webPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", templatePath);
                    // Find templates from a unit test or console application
                    var libraryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, templatePath);

                    var config = new TemplateServiceConfiguration
                    {
                        TemplateManager = new ResolvePathTemplateManager(new[] { webPath, libraryPath }),
                        DisableTempFileLocking = true
                    };

                    _razorEngineService = RazorEngineService.Create(config);
                }

                return _razorEngineService;
            }
        }

        public string RenderEmailBody(string templateKey)
        {
            return RenderEmailBody(templateKey, null);
        }

        public string RenderEmailBody(string templateKey, dynamic model)
        {
            var key = _razorEngineService.GetKey(templateKey);
            return _razorEngineService.RunCompile(key, null, model);
        }
    }
}
