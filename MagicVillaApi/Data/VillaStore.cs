using MagicVillaApi.Dto;

namespace MagicVillaApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto{Id=1,Name="Villa_one"},
            new VillaDto{Id=2,Name="Villa_two"},
            new VillaDto{Id=3,Name="Villa_three"},
            new VillaDto{Id=4,Name="Villa_four"},

        };
    }
}
