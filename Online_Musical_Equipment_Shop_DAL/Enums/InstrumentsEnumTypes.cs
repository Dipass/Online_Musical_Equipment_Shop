using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Online_Musical_Equipment_Shop_DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InstrumentsEnumTypes
    {
        AcousticGuitar = 1,

        ElectricGuitar = 2,
        
        BassGuitar = 3,
        
        DigitalPiano = 4,
        
        Keyboard = 5,
        
        DrumSet = 6,
        
        Violin = 7,
        
        Cello = 8,
        
        Flute = 9,
        
        Saxophone = 10
    }
}
