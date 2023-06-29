using Bogus;
using Online_Musical_Equipment_Shop_DAL.Entities;
using Online_Musical_Equipment_Shop_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Generator
{
    public class Seeding
    {
        public IEnumerable<Categories> Categories { get; set; } = new List<Categories>();
        public IEnumerable<Countries> Countries { get; set; } = new List<Countries>();
        public IEnumerable<Manufacturer> Manufacturer { get; set; } = new List<Manufacturer>();
        public IEnumerable<Instruments> Instruments { get; set; } = new List<Instruments>();
        public IEnumerable<Items> Items { get; set; } = new List<Items>();

        public Seeding()
        {
            Categories = GenerateCategoriesData();
            Countries = GenerateCountriesData(5);
            Manufacturer = GenerateManufacturerData(50, Countries);
            Instruments = GenerateInstrumentsData(150, Manufacturer, Categories);
            Items = GenerateItemsData(100, Countries, Instruments);
        }

        private IEnumerable<Categories> GenerateCategoriesData(int SIZE = 10)
        {
            var categories = new Faker<Categories>().Generate(SIZE);

            var categoriesEnums = Enum.GetNames(typeof(CategoriesEnumTypes));

            for (int i = 0; i < categories.Count; i++) 
            { 
                categories[i].CategoryTitle = categoriesEnums[i]; 
            }
            
            return categories;
        }

        private IEnumerable<Countries> GenerateCountriesData(int SIZE)
        {
            var countries = new Faker<Countries>()
                .RuleFor(x => x.CountriesTitle, f => f.Address.Country())
                .Generate(SIZE);

            return countries;
        }

        private IEnumerable<Manufacturer> GenerateManufacturerData(int SIZE, IEnumerable<Countries> countries)
        {
            var manufacturer = new Faker<Manufacturer>()
                .RuleFor(x => x.Title, f => f.Company.CompanyName())
                .RuleFor(x => x.CountriesId, f => f.PickRandom(countries).Id)
                .Generate(SIZE);

            return manufacturer;
        }

        private IEnumerable<Instruments> GenerateInstrumentsData(int SIZE, IEnumerable<Manufacturer> manufacturers, IEnumerable<Categories> categories)
        {
            var instrument = new Faker<Instruments>()
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.CategoriesId, f => f.PickRandom(categories).Id)
                .RuleFor(x => x.ManufacturerId, f => f.PickRandom(manufacturers).Id)
                .RuleFor(x => x.InstrumentTitle, f => f.PickRandom<InstrumentsEnumTypes>().ToString())
                .Generate(SIZE);

            return instrument;
        }

        private IEnumerable<Items> GenerateItemsData(int SIZE, IEnumerable<Countries> countries, IEnumerable<Instruments> instruments)
        {
            var items = new Faker<Items>()
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Finance.Amount())
                .RuleFor(x => x.CreatedDateTime, f => f.Date.Past())
                .RuleFor(x => x.InstrumentsId, f => f.PickRandom(instruments).Id)
                .RuleFor(x => x.CountriesId, f => f.PickRandom(countries).Id)
                .Generate(SIZE);

            return items;
        }
    }
}
