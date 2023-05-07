using WashingCarDBJosue.DAL.Entities;


namespace WashingCarDBJosue.DAL
{
    public class SeederDb
    {
        private readonly DatabaseContext _context;
        

        public SeederDb(DatabaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await populateServicesAsync();

            await _context.SaveChangesAsync();
        }

        private async Task populateServicesAsync()
        {
            if(!_context.Services.Any())
            {
                _context.Services.Add(new Service { Name = "Lavada simple", Price = 25000});
                _context.Services.Add(new Service { Name = "Lavada + Polishada", Price = 50000 });
                _context.Services.Add(new Service { Name = "Lavada + Aspiradora de cojinería", Price = 30000 });
                _context.Services.Add(new Service { Name = "Lavada Full", Price = 65000 });
                _context.Services.Add(new Service { Name = "Lavada en seco del motor", Price = 80000 });
                _context.Services.Add(new Service { Name = "Lavada Chasis", Price = 90000 });
            }
        }
    }
}
