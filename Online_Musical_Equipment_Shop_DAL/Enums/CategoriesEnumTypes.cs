using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoriesEnumTypes
    {
        Guitars = 1,

        Keyboards = 2,
        
        Drums = 3,
        
        Strings = 4,
        
        Winds = 5,
        
        Percussion = 6,
        
        Amplifiers = 7,
        
        Accessories = 8,

        DJEquipment = 9,
        
        RecordingEquipment = 10
    }
}
