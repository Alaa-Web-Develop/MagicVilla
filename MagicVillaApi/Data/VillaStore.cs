using MagicVillaApi.Dto;

namespace MagicVillaApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto{Id=1,Name="Villa_one",Occupancy=1,sqfet=1},
            new VillaDto{Id=2,Name="Villa_two",Occupancy=10,sqfet=10},
            new VillaDto{Id=3,Name="Villa_three",Occupancy=100,sqfet=100},
            new VillaDto{Id=4,Name="Villa_four",Occupancy=1000,sqfet=1000}
        };
    }
}
