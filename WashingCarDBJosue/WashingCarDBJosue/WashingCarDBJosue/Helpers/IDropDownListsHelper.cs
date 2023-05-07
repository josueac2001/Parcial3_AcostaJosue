using Microsoft.AspNetCore.Mvc.Rendering;

namespace WashingCarDBJosue.Helpers
{
    public interface IDropDownListsHelper
    {
        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();
    }
}
