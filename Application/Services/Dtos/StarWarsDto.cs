using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StarWars.App.Services.Dtos
{
    [DataContract]
    public class StarWarsDto
    {
        [DataMember(Name = "next")]
        public string NextPageUrl { get; set; }

        [DataMember(Name = "results")]
        public List<StarShipDto> StarShips { get; set; }
    }

    [DataContract]
    public class StarShipDto
    {
        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "MGLT")]
        public string Megalights { get; private set; }

        [DataMember(Name = "consumables")]
        public string Consumables { get; private set; }
    }
}
