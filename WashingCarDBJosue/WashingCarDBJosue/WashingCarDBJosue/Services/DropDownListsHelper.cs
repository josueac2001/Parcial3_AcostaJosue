using WashingCarDBJosue.DAL;
using WashingCarDBJosue.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WashingCarDBJosue.Services
{
    public class DropDownListsHelper : IDropDownListsHelper
    {
        private readonly DatabaseContext _context;

        public DropDownListsHelper(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLServicesAsync()
        {
            List<SelectListItem> listServices = await _context.Services
                .Select(s => new SelectListItem
                {
                    Text = s.Name, //Col
                    Value = s.Id.ToString(), //Guid                    
                })
                .ToListAsync();

            listServices.Insert(0, new SelectListItem
            {
                Text = "Selecione un servicio...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listServices;
        }
    }
}
