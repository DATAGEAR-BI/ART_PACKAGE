using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Models;
using Data.Constants.StoredProcs;
using Data.Data.ARTAUDIT;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ART_PACKAGE.Controllers.ARTAUDIT
{
    public class HierarchicalWorkflowController : BaseController
    {
        private readonly ARTAUDITContext ArtAudit;
        private readonly IConfiguration _config;
        private readonly string CustomerNumber;

        public HierarchicalWorkflowController(ARTAUDITContext ArtAudit, UserManager<AppUser> um, IConfiguration config) : base(um)
        {
            this.ArtAudit = ArtAudit;
            _config = config;
            CustomerNumber = _config.GetValue<string>("CustomerNumber").ToUpper();

        }

        public async Task<IActionResult> GetData()
        {


            IEnumerable<ArtStHierarchicalWorkFlow> hierarchicalWorkFlowData = Enumerable.Empty<ArtStHierarchicalWorkFlow>().AsQueryable();
            //List<HierarchicalWorkFlow> result = new();

            AppUser currentUser = await GetUser();

            //if (currentUser.DgUserId != null)
            //{

                IEnumerable<System.Data.Common.DbParameter> Params = new List<System.Data.Common.DbParameter>()
                {
                new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output),
                new OracleParameter("CUSTOMER_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input) { Value = CustomerNumber }
                };

                hierarchicalWorkFlowData = ArtAudit.ExecuteProc<ArtStHierarchicalWorkFlow>(ORACLESPName.ART_ST_DGAML_HIERARCHICAL_WORKFLOW, Params.ToArray());

            //foreach (ArtStHierarchicalWorkFlow data in hierarchicalWorkFlowData)
            //{
            //    if (data != null && data.node_id != null)
            //    {

            //        result.Add(new() { id = data.node_id, name = data.node_id, parentId = data.parent_id, title = data.role, expanded = true });
            //    }

            //}
            //}
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(hierarchicalWorkFlowData.ToList(), new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
