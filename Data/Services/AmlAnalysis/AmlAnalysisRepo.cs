using Data.Data.AmlAnalysis;

namespace Data.Services.AmlAnalysis;

public class AmlAnalysisRepo : BaseRepo<AmlAnalysisContext,ArtAmlAnalysisViewTb>, IAmlAnalysisRepo 
{
    public AmlAnalysisRepo(AmlAnalysisContext context) : base(context)
    {
    }
}