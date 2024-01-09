using AutoMapper;
using Data.FCFCORE.SEG;

namespace ART_PACKAGE.Helpers.AutoMapperProfiles
{
    public class MebSegmentProfile : Profile
    {
        public MebSegmentProfile()
        {
            _ = CreateMap<MebSegmentsV3, MebSegmentsV3Bk>();
        }
    }
}
