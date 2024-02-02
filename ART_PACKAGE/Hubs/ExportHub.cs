using ART_PACKAGE.Helpers;
using Microsoft.AspNetCore.SignalR;
namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {

        private readonly UsersConnectionIds connections;

        public ExportHub(UsersConnectionIds connections)
        {
            this.connections = connections;
        }

        public override Task OnConnectedAsync()
        {
            string? user = Context.User.Identity.Name;
            connections.AddConnctionIdFor(user, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task KeepAlive()
        {
            await Clients.Caller.SendAsync("iAmAlive");
        }


        //
        // private async Task ExportSegOutliers(ExportDto<object> para, List<string> @params)
        // {
        //     int monthKey = Convert.ToInt32(@params.First());
        //     string desc = @params[1];
        //     string seg = @params[2];
        //     IQueryable<ArtAllSegmentsOutliersTb> data = _seg.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == monthKey.ToString() && x.PartyTypeDesc == desc && x.SegmentSorted == seg);
        //     await _csvSrv.ExportAllCsv<ArtAllSegmentsOutliersTb, AllSegmentsOutliersNewController, object>(data, Context.User.Identity.Name, para);
        // }
        // private async Task ExportForAuditTrial(ExportDto<object> para)
        // {
        //     IQueryable<ArtTiEcmAuditReport> data = _fti.ArtTiEcmAuditReports.AsQueryable().CallData(para.Req).Data;
        //     var res = data.AsEnumerable().OrderBy(x => x.EcmReference).GroupBy(x => new { x.EcmReference, x.FtiReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
        //     IEnumerable<ExportDto> after = res.Select(x =>
        //     {
        //         IQueryable<string?>? ListOfMatchingEcm = ti.Masters.Where(c => c.MasterRef == x.Key.FtiReference)?.Join(ti.Notes, c => c.Key97, co => co.MasterKey, (c, co) => co.NoteText);
        //         return new ExportDto
        //         {
        //             Record = x.FirstOrDefault(),
        //             Note = ListOfMatchingEcm?.Select(e => e).ToList(),
        //
        //         };
        //
        //     });
        //     MemoryStream stream = new();
        //     using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
        //     using (CsvWriter cw = new(sw, CultureInfo.CurrentCulture))
        //     {
        //
        //
        //         sw.Write("");
        //         System.Reflection.PropertyInfo[] props = typeof(ArtTiEcmAuditReport).GetProperties();
        //
        //         foreach (System.Reflection.PropertyInfo item in props)
        //         {
        //             cw.WriteField(item.Name);
        //         }
        //
        //         cw.WriteField("Note");
        //
        //
        //         cw.NextRecord();
        //         foreach (ExportDto? elm in after)
        //         {
        //             foreach (System.Reflection.PropertyInfo prop in props)
        //             {
        //                 cw.WriteField(prop.GetValue(elm.Record));
        //             }
        //
        //             cw.NextRecord();
        //             for (int i = 0; i < elm.Note.Count; i++)
        //             {
        //                 foreach (System.Reflection.PropertyInfo prop in props)
        //                 {
        //                     cw.WriteField("");
        //                 }
        //
        //                 cw.WriteField(elm.Note[i]);
        //
        //                 cw.NextRecord();
        //             }
        //             cw.NextRecord();
        //         }
        //     }
        //     string FileName = nameof(EcmAuditTrialController).Replace("Controller", "") + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //     await Clients.Caller
        //                       .SendAsync("csvRecevied", stream.ToArray(), FileName);
        // }
        //
        //
        // private async Task ExportCustomReport(ExportDto<object> exportDto)
        // {
        //     //string orderBy = exportDto.Req.Sort is null ? null : string.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
        //     //ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == exportDto.Req.Id);
        //     //List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == exportDto.Req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
        //     //dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
        //     //string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
        //     //ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
        //     //{
        //     //    name = x.Column,
        //     //    type = x.JsType,
        //     //    isNullable = x.IsNullable,
        //     //}).ToArray();
        //     //string filter = exportDto.Req.Filter.GetFiltersString(dbtype, columns);
        //     //List<ChartData<dynamic>> chartsdata = charts is not null && charts.Count > 0 ? dbInstance.GetChartData(charts, filter) : null;
        //
        //     //List<List<object>> filterCells = exportDto.Req.Filter.GetFilterTextForCsv();
        //
        //     //DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, exportDto.Req.Take, exportDto.Req.Skip, orderBy);
        //     //byte[] bytes = KendoFiltersExtentions.ExportCustomReportToCSV(data.Data, chartsdata?.Select(x => x.Data).ToList(), filterCells);
        //     //string FileName = Report.Name + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //     //await Clients.Clients(connections.GetConnections(Context.User.Identity.Name))
        //     //                    .SendAsync("csvRecevied", bytes, FileName);
        // }
        //
        // private async Task ExportForWorkflowProg(ExportDto<object> para)
        // {
        //
        //     IQueryable<ArtTiEcmWorkflowProgReport> data = _fti.ArtTiEcmWorkflowProgReports.AsQueryable().CallData(para.Req).Data;
        //     var res = data.AsEnumerable().OrderBy(x => x.EcmReference).GroupBy(x => new { x.EcmReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
        //     IEnumerable<ExportDtoWorkflowProg> after = res.Select(x =>
        //     {
        //         IQueryable<ArtTiEcmWorkflowProgReportOld>? ListOfMatchingEcm = _fti.ArtTiEcmWorkflowProgReportOlds.Where(o => o.EcmReference == x.Key.EcmReference && x.Key.CaseStatCd == o.CaseStatCd && x.Key.EventSteps == o.EventSteps && x.Key.StepStatus == o.StepStatus);
        //         return new ExportDtoWorkflowProg
        //         {
        //             Record = x.FirstOrDefault(),
        //             Comments = ListOfMatchingEcm?.Select(e => e.Comments).ToList(),
        //             Note = ListOfMatchingEcm?.Select(e => e.Note).ToList(),
        //             NoteCreationTime = ListOfMatchingEcm?.Select(e => e.NoteCreationTime).ToList()
        //         };
        //
        //     });
        //     MemoryStream stream = new();
        //     using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
        //     using (CsvWriter cw = new(sw, CultureInfo.CurrentCulture))
        //     {
        //
        //
        //         sw.Write("");
        //         System.Reflection.PropertyInfo[] props = typeof(ArtTiEcmWorkflowProgReport).GetProperties();
        //
        //         foreach (System.Reflection.PropertyInfo item in props)
        //         {
        //             cw.WriteField(item.Name);
        //         }
        //         cw.WriteField("Comments");
        //         cw.WriteField("Note");
        //         cw.WriteField("NoteCreationTime");
        //
        //         cw.NextRecord();
        //         foreach (ExportDtoWorkflowProg? elm in after)
        //         {
        //             foreach (System.Reflection.PropertyInfo prop in props)
        //             {
        //                 cw.WriteField(prop.GetValue(elm.Record));
        //             }
        //
        //             cw.NextRecord();
        //             for (int i = 0; i < elm.Comments.Count; i++)
        //             {
        //                 foreach (System.Reflection.PropertyInfo prop in props)
        //                 {
        //                     cw.WriteField("");
        //                 }
        //                 cw.WriteField(elm.Comments[i]);
        //                 cw.WriteField(elm.Note[i]);
        //                 cw.WriteField(elm.NoteCreationTime[i]);
        //                 cw.NextRecord();
        //             }
        //         }
        //     }
        //     string FileName = nameof(EcmAuditTrialController).Replace("Controller", "") + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //     await Clients.Caller
        //                       .SendAsync("csvRecevied", stream.ToArray(), FileName);
        // }
        //
        //
        // public override Task OnDisconnectedAsync(Exception? exception)
        // {
        //     string? user = Context.User.Identity.Name;
        //     connections.RemoveConnection(user, Context.ConnectionId);
        //     return base.OnDisconnectedAsync(exception);
        // }
        //
        // public class ExportDto
        // {
        //     public ArtTiEcmAuditReport Record { get; set; }
        //
        //     public List<string> Note { get; set; }
        //
        // }
        // public class ExportDtoWorkflowProg
        // {
        //     public ArtTiEcmWorkflowProgReport Record { get; set; }
        //     public List<string> Comments { get; set; }
        //     public List<string> Note { get; set; }
        //     public List<DateTime?> NoteCreationTime { get; set; }
        // }
    }
}
