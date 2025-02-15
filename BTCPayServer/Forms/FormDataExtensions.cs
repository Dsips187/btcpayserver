using BTCPayServer.Abstractions.Form;
using BTCPayServer.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTCPayServer.Forms;

public static class FormDataExtensions
{
    public static void AddForms(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<FormDataService>();
        serviceCollection.AddSingleton<FormComponentProviders>();
        serviceCollection.AddSingleton<IFormComponentProvider, HtmlInputFormProvider>();
        serviceCollection.AddSingleton<IFormComponentProvider, HtmlFieldsetFormProvider>();
    }
    
    public static JObject Deserialize(this FormData form) 
    {
        return JsonConvert.DeserializeObject<JObject>(form.Config);
    }

    public static string Serialize(this JObject form)
    {
        return JsonConvert.SerializeObject(form);
    }
}
