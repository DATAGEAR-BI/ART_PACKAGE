using AutoMapper;
using Data.Data.Segmentation;
using Data.FCFCORE.SEG;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SEG
{
    [AllowAnonymous]
    public class AutomateSegmentationController : Controller
    {
        private readonly SegmentationContext _segContext;
        private readonly IHostEnvironment _environment;
        private readonly FCFCORESeg _fcfcorSeg;
        private readonly IMapper _mapper;
        private readonly string _path;//$"C:\\Users\\sasinst\\PycharmProjects\\MEB_V2\\MEB_Segmentation\\Segmentation_{DateTime.Now.ToString("yyyy-MM-dd")}.csv";
        //Segmentation_2023-11-29.csv
        //C:\\Users\\sasinst\\PycharmProjects\\MEB_V2\\MEB_Segmentation\\Segmentation_{}.csv  //DateTime.Now:yyyy-MM-dd
        public AutomateSegmentationController(IHostEnvironment environment, SegmentationContext segContext, FCFCORESeg fcfcorSeg, IMapper mapper)
        {
            _environment = environment;
            _path = $"C:\\Users\\sasinst\\PycharmProjects\\TestVenv\\Segmentation_2023-11-29.csv"; //Path.Combine(_environment.ContentRootPath, "Segmentation_2023-11-15.csv");
            _segContext = segContext;
            _fcfcorSeg = fcfcorSeg;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        //public IActionResult ReadData()
        //{
        //    using StreamReader reader = new(_path);
        //    using CsvReader csv = new(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        //    _ = csv.Context.RegisterClassMap<MebSegmentMapper>();
        //    using IDbContextTransaction dbContextTransaction = _fcfcorSeg.Database.BeginTransaction();
        //    try
        //    {
        //        IEnumerable<MebSegmentsV3> data = csv.GetRecords<MebSegmentsV3>();
        //        int effected = _fcfcorSeg.Database.ExecuteSqlRaw("DELETE FROM MEB_SEGMENTS_V3");


        //        if (effected <= 0)
        //            return BadRequest();


        //        IEnumerable<MebSegmentsV3Bk> BkData = _mapper.Map<IEnumerable<MebSegmentsV3Bk>>(data);

        //        bool dataInesrtRes = _fcfcorSeg.BulkInsert(data);
        //        bool dataBkInsert = _fcfcorSeg.BulkInsert(BkData);
        //        if (!dataInesrtRes || !dataBkInsert)
        //        {
        //            dbContextTransaction.Rollback();
        //            return BadRequest();
        //        }

        //        dbContextTransaction.Commit();
        //        return Ok("done");
        //    }
        //    catch (Exception ex)
        //    {
        //        dbContextTransaction.Rollback();
        //        return BadRequest();
        //    }
        //}









        //public IActionResult WriteData()
        //{
        //    Microsoft.EntityFrameworkCore.DbSet<ArtAmlAlertDetailView> data = _sasAmlContext.ArtAmlAlertDetailViews;
        //    CsvConfiguration configuration = new(CultureInfo.InvariantCulture);

        //    using (StreamWriter streamWriter = new(_path))
        //    using (CsvWriter csvWriter = new(streamWriter, configuration))
        //    {
        //        csvWriter.WriteRecords(data);
        //    }

        //    // Optionally, you can return a response to the client
        //    return Ok("CSV file has been created at: " + _path);

        //}


        //public string getDateNow()
        //{
        //    string c = DateTime.Now.ToString("yyyy-MM-dd");
        //    string strFilePath = $"C:\\Users\\sasinst\\PycharmProjects\\MEB_V2\\MEB_Segmentation\\Segmentation_{c}.csv";

        //    //return Content(JsonConvert.SerializeObject(strFilePath), "application/json");
        //    return strFilePath;
        //}

        //public DataTable CSVtoDataTable()
        //{

        //    string c = DateTime.Now.ToShortDateString();
        //    string strFilePath = getDateNow(); //"C:\\Users\\sasinst\\PycharmProjects\\MEB_Segmentation\\07\\Segmentation_04-28-2022.csv";

        //    //char csvDelimiter = ',';
        //    //DataTable dt = new DataTable();
        //    //using (StreamReader sr = new StreamReader(strFilePath))
        //    //{
        //    //    string[] headers = sr.ReadLine().Split(csvDelimiter);
        //    //    foreach (string header in headers)
        //    //    {
        //    //        try
        //    //        {
        //    //            dt.Columns.Add(header);
        //    //        }
        //    //        catch { }
        //    //    }
        //    //    while (!sr.EndOfStream)
        //    //    {
        //    //        string[] rows = sr.ReadLine().Split(csvDelimiter);
        //    //        DataRow dr = dt.NewRow();
        //    //        for (int i = 0; i < headers.Length; i++)
        //    //        {
        //    //            dr[i] = rows[i];
        //    //        }
        //    //        dt.Rows.Add(dr);
        //    //    }

        //    //}
        //    //return dt;

        //    DataTable myData = new DataTable();

        //    try
        //    {
        //        using (TextFieldParser reader = new TextFieldParser(strFilePath))
        //        {
        //            reader.SetDelimiters(new string[] { "," });
        //            reader.HasFieldsEnclosedInQuotes = true;
        //            string[] col_headers = reader.ReadFields();
        //            foreach (string h in col_headers)
        //            {
        //                DataColumn d1 = new DataColumn(h);
        //                d1.AllowDBNull = true;
        //                myData.Columns.Add(d1);
        //            }

        //            while (!reader.EndOfData)
        //            {
        //                string[] row_data = reader.ReadFields();
        //                myData.Rows.Add(row_data);
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    return myData;

        //}


        //public ContentResult BulkInsertDataTable()
        //{




        //    DataTable dt = CSVtoDataTable();
        //    List<Segmentation_Automation.MebSegmentsV3> segments = new List<Segmentation_Automation.MebSegmentsV3>();
        //    var connectionStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

        //    string queryString = "delete from fcfcore.meb_segments_v3";
        //    using (OracleConnection connection = new OracleConnection(connectionStr))
        //    {
        //        OracleCommand command = new OracleCommand(queryString, connection);
        //        connection.Open();
        //        //OracleDataReader reader = command.ExecuteReader();
        //        try
        //        {
        //            command.ExecuteNonQuery();

        //            //while (reader.Read())
        //            //{
        //            //    Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetInt32(1));
        //            //}
        //        }
        //        finally
        //        {
        //            // always call Close when done reading.
        //            connection.Close();
        //        }
        //    }



        //    int counter = 0;
        //    //foreach (DataColumn col in dt.Columns)
        //    //{
        //    foreach (DataRow row in dt.Rows)
        //    {


        //        try
        //        {
        //            Models.MebSegmentsV3 temp = new Models.MebSegmentsV3();

        //            Console.WriteLine(row["RISK_CLASSIFICATION"]);
        //            Console.WriteLine(row["RISK_CLASSIFICATION"].ToString());
        //            Console.WriteLine(Convert.ToDecimal(row["RISK_CLASSIFICATION"]));
        //            Console.WriteLine(row["TOTAL_CREDIT_AMOUNT"]);
        //            var customer = fcfcore.Set<Segmentation_Automation.MebSegmentsV3>();





        //            counter += 1;
        //            //segments.Add(temp);


        //            //fcfcore.Add(temp);
        //            //fcfcore.MebSegmentsV3s.AddAsync(temp);




        //            segments.Add(new Segmentation_Automation.MebSegmentsV3
        //            {

        //                MonthKey = (string)row["MONTH_KEY"].ToString() ?? "0",
        //                PartyNumber = (string)row["PARTY_NUMBER"].ToString() ?? "0",
        //                RiskClassification = Convert.ToDecimal(row["RISK_CLASSIFICATION"]),
        //                PartyTypeDesc = (string)row["PARTY_TYPE_DESC"].ToString() ?? "0",
        //                IndustryCode = (string)row["INDUSTRY_CODE"].ToString() ?? "0",
        //                IndustryDesc = (string)row["INDUSTRY_DESC"].ToString() ?? "0",
        //                OccupationCode = (string)row["OCCUPATION_CODE"].ToString() ?? "0",
        //                OccupationDesc = (string)row["OCCUPATION_DESC"].ToString() ?? "0",
        //                TotalCreditAmount = Convert.ToDecimal(row["TOTAL_CREDIT_AMOUNT"]),
        //                TotalDebitAmount = Convert.ToDecimal(row["TOTAL_DEBIT_AMOUNT"]),
        //                TotalCreditCnt = Convert.ToDecimal(row["TOTAL_CREDIT_CNT"]),
        //                TotalDebitCnt = Convert.ToDecimal(row["TOTAL_DEBIT_CNT"]),
        //                TotalAmount = Convert.ToDecimal(row["TOTAL_AMOUNT"]),
        //                TotalCnt = Convert.ToDecimal(row["TOTAL_CNT"]),
        //                AvgTotalAmt = Convert.ToDecimal(row["AVG_TOTAL_AMT"]),
        //                MaxTotalAmt = Convert.ToDecimal(row["MAX_TOTAL_AMT"]),
        //                MinTotalAmt = Convert.ToDecimal(row["MIN_TOTAL_AMT"]),
        //                AvgTotalCAmt = Convert.ToDecimal(row["AVG_TOTAL_C_AMT"]),
        //                MaxTotalCAmt = Convert.ToDecimal(row["MAX_TOTAL_C_AMT"]),
        //                MinTotalCAmt = Convert.ToDecimal(row["MIN_TOTAL_C_AMT"]),
        //                AvgTotalDAmt = Convert.ToDecimal(row["AVG_TOTAL_D_AMT"]),
        //                MaxTotalDAmt = Convert.ToDecimal(row["MAX_TOTAL_D_AMT"]),
        //                MinTotalDAmt = Convert.ToDecimal(row["MIN_TOTAL_D_AMT"]),
        //                NumberOfLocations = Convert.ToDecimal(row["NUMBER_OF_LOCATIONS"]),
        //                AvgWireCAmt = Convert.ToDecimal(row["AVG_WIRE_C_AMT"]),
        //                MaxWireCAmt = Convert.ToDecimal(row["MAX_WIRE_C_AMT"]),
        //                TotalWireCAmt = Convert.ToDecimal(row["TOTAL_WIRE_C_AMT"]),
        //                MinWireCAmt = Convert.ToDecimal(row["MIN_WIRE_C_AMT"]),
        //                TotalWireCCnt = Convert.ToDecimal(row["TOTAL_WIRE_C_CNT"]),
        //                MaxWireDAmt = Convert.ToDecimal(row["MAX_WIRE_D_AMT"]),
        //                TotalWireDAmt = Convert.ToDecimal(row["TOTAL_WIRE_D_AMT"]),
        //                TotalWireDCnt = Convert.ToDecimal(row["TOTAL_WIRE_D_CNT"]),
        //                MinWireDAmt = Convert.ToDecimal(row["MIN_WIRE_D_AMT"]),
        //                AvgWireDAmt = Convert.ToDecimal(row["AVG_WIRE_D_AMT"]),
        //                AvgBuysecurityCAmt = Convert.ToDecimal(row["AVG_BUYSECURITY_C_AMT"]),
        //                TotalBuysecurityCCnt = Convert.ToDecimal(row["TOTAL_BUYSECURITY_C_CNT"]),
        //                TotalBuysecurityCAmt = Convert.ToDecimal(row["TOTAL_BUYSECURITY_C_AMT"]),

        //                MinBuysecurityCAmt = Convert.ToDecimal(row["MIN_BUYSECURITY_C_AMT"]),
        //                MaxBuysecurityCAmt = Convert.ToDecimal(row["MAX_BUYSECURITY_C_AMT"]),
        //                TotalCashCAmt = Convert.ToDecimal(row["TOTAL_CASH_C_AMT"]),
        //                TotalCashCCnt = Convert.ToDecimal(row["TOTAL_CASH_C_CNT"]),
        //                MinCashCAmt = Convert.ToDecimal(row["MIN_CASH_C_AMT"]),
        //                AvgCashCAmt = Convert.ToDecimal(row["AVG_CASH_C_AMT"]),
        //                MaxCashCAmt = Convert.ToDecimal(row["MAX_CASH_C_AMT"]),
        //                AvgCashDAmt = Convert.ToDecimal(row["AVG_CASH_D_AMT"]),
        //                TotalCashDAmt = Convert.ToDecimal(row["TOTAL_CASH_D_AMT"]),
        //                TotalCashDCnt = Convert.ToDecimal(row["TOTAL_CASH_D_CNT"]),
        //                MinCashDAmt = Convert.ToDecimal(row["MIN_CASH_D_AMT"]),
        //                MaxCashDAmt = Convert.ToDecimal(row["MAX_CASH_D_AMT"]),
        //                TotalCheckDCnt = Convert.ToDecimal(row["TOTAL_CHECK_D_CNT"]),
        //                AvgCheckDAmt = Convert.ToDecimal(row["AVG_CHECK_D_AMT"]),
        //                MaxCheckDAmt = Convert.ToDecimal(row["MAX_CHECK_D_AMT"]),
        //                TotalCheckDAmt = Convert.ToDecimal(row["TOTAL_CHECK_D_AMT"]),
        //                MinCheckDAmt = Convert.ToDecimal(row["MIN_CHECK_D_AMT"]),
        //                MaxClearingcheckCAmt = Convert.ToDecimal(row["MAX_CLEARINGCHECK_C_AMT"]),
        //                MinClearingcheckCAmt = Convert.ToDecimal(row["MIN_CLEARINGCHECK_C_AMT"]),
        //                AvgClearingcheckCAmt = Convert.ToDecimal(row["AVG_CLEARINGCHECK_C_AMT"]),
        //                TotalClearingcheckCAmt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_C_AMT"]),
        //                TotalClearingcheckCCnt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_C_CNT"]),
        //                MaxClearingcheckDAmt = Convert.ToDecimal(row["MAX_CLEARINGCHECK_D_AMT"]),
        //                AvgClearingcheckDAmt = Convert.ToDecimal(row["AVG_CLEARINGCHECK_D_AMT"]),

        //                TotalClearingcheckDAmt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_D_AMT"]),
        //                TotalClearingcheckDCnt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_D_CNT"]),
        //                MinClearingcheckDAmt = Convert.ToDecimal(row["MIN_CLEARINGCHECK_D_AMT"]),
        //                AvgDerivativesCAmt = Convert.ToDecimal(row["AVG_DERIVATIVES_C_AMT"]),
        //                MaxDerivativesCAmt = Convert.ToDecimal(row["MAX_DERIVATIVES_C_AMT"]),
        //                TotalDerivativesCAmt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_C_AMT"]),
        //                MinDerivativesCAmt = Convert.ToDecimal(row["MIN_DERIVATIVES_C_AMT"]),
        //                TotalDerivativesCCnt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_C_CNT"]),
        //                MaxDerivativesDAmt = Convert.ToDecimal(row["MAX_DERIVATIVES_D_AMT"]),
        //                TotalDerivativesDAmt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_D_AMT"]),
        //                TotalDerivativesDCnt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_D_CNT"]),
        //                MinDerivativesDAmt = Convert.ToDecimal(row["MIN_DERIVATIVES_D_AMT"]),
        //                AvgDerivativesDAmt = Convert.ToDecimal(row["AVG_DERIVATIVES_D_AMT"]),
        //                AvgInhousecheckCAmt = Convert.ToDecimal(row["AVG_INHOUSECHECK_C_AMT"]),
        //                TotalInhousecheckCAmt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_C_AMT"]),
        //                MinInhousecheckCAmt = Convert.ToDecimal(row["MIN_INHOUSECHECK_C_AMT"]),
        //                MaxInhousecheckCAmt = Convert.ToDecimal(row["MAX_INHOUSECHECK_C_AMT"]),
        //                TotalInhousecheckCCnt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_C_CNT"]),
        //                TotalInhousecheckDCnt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_D_CNT"]),
        //                AvgInhousecheckDAmt = Convert.ToDecimal(row["AVG_INHOUSECHECK_D_AMT"]),
        //                TotalInhousecheckDAmt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_D_AMT"]),
        //                MinInhousecheckDAmt = Convert.ToDecimal(row["MIN_INHOUSECHECK_D_AMT"]),
        //                MaxInhousecheckDAmt = Convert.ToDecimal(row["MAX_INHOUSECHECK_D_AMT"]),
        //                MaxInternaltransferCAmt = Convert.ToDecimal(row["MAX_INTERNALTRANSFER_C_AMT"]),
        //                MinInternaltransferCAmt = Convert.ToDecimal(row["MIN_INTERNALTRANSFER_C_AMT"]),
        //                TotalInternaltransferCCnt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_C_CNT"]),
        //                TotalInternaltransferCAmt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_C_AMT"]),
        //                AvgInternaltransferCAmt = Convert.ToDecimal(row["AVG_INTERNALTRANSFER_C_AMT"]),
        //                MinInternaltransferDAmt = Convert.ToDecimal(row["MIN_INTERNALTRANSFER_D_AMT"]),
        //                TotalInternaltransferDCnt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_D_CNT"]),
        //                AvgInternaltransferDAmt = Convert.ToDecimal(row["AVG_INTERNALTRANSFER_D_AMT"]),
        //                TotalInternaltransferDAmt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_D_AMT"]),
        //                MaxInternaltransferDAmt = Convert.ToDecimal(row["MAX_INTERNALTRANSFER_D_AMT"]),
        //                MaxLcBlClcnCAmt = Convert.ToDecimal(row["MAX_LC_BL_CLCN_C_AMT"]),
        //                MinLcBlClcnCAmt = Convert.ToDecimal(row["MIN_LC_BL_CLCN_C_AMT"]),
        //                TotalLcBlClcnCCnt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_C_CNT"]),
        //                AvgLcBlClcnCAmt = Convert.ToDecimal(row["AVG_LC_BL_CLCN_C_AMT"]),
        //                TotalLcBlClcnCAmt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_C_AMT"]),
        //                TotalLcBlClcnDAmt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_D_AMT"]),
        //                MaxLcBlClcnDAmt = Convert.ToDecimal(row["MAX_LC_BL_CLCN_D_AMT"]),
        //                MinLcBlClcnDAmt = Convert.ToDecimal(row["MIN_LC_BL_CLCN_D_AMT"]),
        //                AvgLcBlClcnDAmt = Convert.ToDecimal(row["AVG_LC_BL_CLCN_D_AMT"]),
        //                TotalLcBlClcnDCnt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_D_CNT"]),
        //                TotalLccollectionCCnt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_C_CNT"]),
        //                MaxLccollectionCAmt = Convert.ToDecimal(row["MAX_LCCOLLECTION_C_AMT"]),
        //                AvgLccollectionCAmt = Convert.ToDecimal(row["AVG_LCCOLLECTION_C_AMT"]),
        //                MinLccollectionCAmt = Convert.ToDecimal(row["MIN_LCCOLLECTION_C_AMT"]),
        //                TotalLccollectionCAmt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_C_AMT"]),
        //                TotalLccollectionDCnt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_D_CNT"]),
        //                AvgLccollectionDAmt = Convert.ToDecimal(row["AVG_LCCOLLECTION_D_AMT"]),
        //                MaxLccollectionDAmt = Convert.ToDecimal(row["MAX_LCCOLLECTION_D_AMT"]),
        //                TotalLccollectionDAmt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_D_AMT"]),
        //                MinLccollectionDAmt = Convert.ToDecimal(row["MIN_LCCOLLECTION_D_AMT"]),
        //                TotalLoanCCnt = Convert.ToDecimal(row["TOTAL_LOAN_C_CNT"]),
        //                AvgLoanCAmt = Convert.ToDecimal(row["AVG_LOAN_C_AMT"]),
        //                MinLoanCAmt = Convert.ToDecimal(row["MIN_LOAN_C_AMT"]),
        //                TotalLoanCAmt = Convert.ToDecimal(row["TOTAL_LOAN_C_AMT"]),
        //                MaxLoanCAmt = Convert.ToDecimal(row["MAX_LOAN_C_AMT"]),
        //                TotalLoanDAmt = Convert.ToDecimal(row["TOTAL_LOAN_D_AMT"]),
        //                MaxLoanDAmt = Convert.ToDecimal(row["MAX_LOAN_D_AMT"]),
        //                MinLoanDAmt = Convert.ToDecimal(row["MIN_LOAN_D_AMT"]),
        //                TotalLoanDCnt = Convert.ToDecimal(row["TOTAL_LOAN_D_CNT"]),
        //                AvgLoanDAmt = Convert.ToDecimal(row["AVG_LOAN_D_AMT"]),
        //                MaxLoandisbursementCAmt = Convert.ToDecimal(row["MAX_LOANDISBURSEMENT_C_AMT"]),
        //                MinLoandisbursementCAmt = Convert.ToDecimal(row["MIN_LOANDISBURSEMENT_C_AMT"]),
        //                AvgLoandisbursementCAmt = Convert.ToDecimal(row["AVG_LOANDISBURSEMENT_C_AMT"]),
        //                TotalLoandisbursementCAmt = Convert.ToDecimal(row["TOTAL_LOANDISBURSEMENT_C_AMT"]),
        //                TotalLoandisbursementCCnt = Convert.ToDecimal(row["TOTAL_LOANDISBURSEMENT_C_CNT"]),
        //                AvgLoantopUpCAmt = Convert.ToDecimal(row["AVG_LOANTOP_UP_C_AMT"]),
        //                MinLoantopUpCAmt = Convert.ToDecimal(row["MIN_LOANTOP_UP_C_AMT"]),
        //                TotalLoantopUpCAmt = Convert.ToDecimal(row["TOTAL_LOANTOP_UP_C_AMT"]),
        //                TotalLoantopUpCCnt = Convert.ToDecimal(row["TOTAL_LOANTOP_UP_C_CNT"]),
        //                MaxLoantopUpCAmt = Convert.ToDecimal(row["MAX_LOANTOP_UP_C_AMT"]),
        //                AvgMngrschckissnceCAmt = Convert.ToDecimal(row["AVG_MNGRSCHCKISSNCE_C_AMT"]),
        //                TotalMngrschckissnceCCnt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_C_CNT"]),
        //                MaxMngrschckissnceCAmt = Convert.ToDecimal(row["MAX_MNGRSCHCKISSNCE_C_AMT"]),
        //                MinMngrschckissnceCAmt = Convert.ToDecimal(row["MIN_MNGRSCHCKISSNCE_C_AMT"]),
        //                TotalMngrschckissnceCAmt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_C_AMT"]),
        //                MaxMngrschckissnceDAmt = Convert.ToDecimal(row["MAX_MNGRSCHCKISSNCE_D_AMT"]),
        //                TotalMngrschckissnceDAmt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_D_AMT"]),
        //                MinMngrschckissnceDAmt = Convert.ToDecimal(row["MIN_MNGRSCHCKISSNCE_D_AMT"]),
        //                TotalMngrschckissnceDCnt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_D_CNT"]),
        //                AvgMngrschckissnceDAmt = Convert.ToDecimal(row["AVG_MNGRSCHCKISSNCE_D_AMT"]),
        //                TotalMiscCCnt = Convert.ToDecimal(row["TOTAL_MISC_C_CNT"]),
        //                AvgMiscCAmt = Convert.ToDecimal(row["AVG_MISC_C_AMT"]),
        //                TotalMiscCAmt = Convert.ToDecimal(row["TOTAL_MISC_C_AMT"]),
        //                MinMiscCAmt = Convert.ToDecimal(row["MIN_MISC_C_AMT"]),
        //                MaxMiscCAmt = Convert.ToDecimal(row["MAX_MISC_C_AMT"]),
        //                TotalMiscDAmt = Convert.ToDecimal(row["TOTAL_MISC_D_AMT"]),
        //                AvgMiscDAmt = Convert.ToDecimal(row["AVG_MISC_D_AMT"]),
        //                MaxMiscDAmt = Convert.ToDecimal(row["MAX_MISC_D_AMT"]),
        //                MinMiscDAmt = Convert.ToDecimal(row["MIN_MISC_D_AMT"]),
        //                TotalMiscDCnt = Convert.ToDecimal(row["TOTAL_MISC_D_CNT"]),
        //                AvgOutwrdchqrtrnDAmt = Convert.ToDecimal(row["AVG_OUTWRDCHQRTRN_D_AMT"]),
        //                TotalOutwrdchqrtrnDCnt = Convert.ToDecimal(row["TOTAL_OUTWRDCHQRTRN_D_CNT"]),
        //                TotalOutwrdchqrtrnDAmt = Convert.ToDecimal(row["TOTAL_OUTWRDCHQRTRN_D_AMT"]),
        //                MinOutwrdchqrtrnDAmt = Convert.ToDecimal(row["MIN_OUTWRDCHQRTRN_D_AMT"]),
        //                MaxOutwrdchqrtrnDAmt = Convert.ToDecimal(row["MAX_OUTWRDCHQRTRN_D_AMT"]),
        //                AvgPymntofinstllmntDAmt = Convert.ToDecimal(row["AVG_PYMNTOFINSTLLMNT_D_AMT"]),
        //                TotalPymntofinstllmntDCnt = Convert.ToDecimal(row["TOTAL_PYMNTOFINSTLLMNT_D_CNT"]),
        //                TotalPymntofinstllmntDAmt = Convert.ToDecimal(row["TOTAL_PYMNTOFINSTLLMNT_D_AMT"]),
        //                MinPymntofinstllmntDAmt = Convert.ToDecimal(row["MIN_PYMNTOFINSTLLMNT_D_AMT"]),
        //                MaxPymntofinstllmntDAmt = Convert.ToDecimal(row["MAX_PYMNTOFINSTLLMNT_D_AMT"]),
        //                AvgReturnedwiresDAmt = Convert.ToDecimal(row["AVG_RETURNEDWIRES_D_AMT"]),
        //                MaxReturnedwiresDAmt = Convert.ToDecimal(row["MAX_RETURNEDWIRES_D_AMT"]),
        //                TotalReturnedwiresDAmt = Convert.ToDecimal(row["TOTAL_RETURNEDWIRES_D_AMT"]),
        //                MinReturnedwiresDAmt = Convert.ToDecimal(row["MIN_RETURNEDWIRES_D_AMT"]),
        //                TotalReturnedwiresDCnt = Convert.ToDecimal(row["TOTAL_RETURNEDWIRES_D_CNT"]),
        //                MaxReturnchequeCAmt = Convert.ToDecimal(row["MAX_RETURNCHEQUE_C_AMT"]),
        //                TotalReturnchequeCAmt = Convert.ToDecimal(row["TOTAL_RETURNCHEQUE_C_AMT"]),
        //                TotalReturnchequeCCnt = Convert.ToDecimal(row["TOTAL_RETURNCHEQUE_C_CNT"]),
        //                MinReturnchequeCAmt = Convert.ToDecimal(row["MIN_RETURNCHEQUE_C_AMT"]),
        //                AvgReturnchequeCAmt = Convert.ToDecimal(row["AVG_RETURNCHEQUE_C_AMT"]),
        //                TotalSalarycreditCAmt = Convert.ToDecimal(row["TOTAL_SALARYCREDIT_C_AMT"]),
        //                TotalSalarycreditCCnt = Convert.ToDecimal(row["TOTAL_SALARYCREDIT_C_CNT"]),
        //                MinSalarycreditCAmt = Convert.ToDecimal(row["MIN_SALARYCREDIT_C_AMT"]),
        //                AvgSalarycreditCAmt = Convert.ToDecimal(row["AVG_SALARYCREDIT_C_AMT"]),
        //                MaxSalarycreditCAmt = Convert.ToDecimal(row["MAX_SALARYCREDIT_C_AMT"]),
        //                AvgSalarydebitDAmt = Convert.ToDecimal(row["AVG_SALARYDEBIT_D_AMT"]),
        //                TotalSalarydebitDAmt = Convert.ToDecimal(row["TOTAL_SALARYDEBIT_D_AMT"]),
        //                TotalSalarydebitDCnt = Convert.ToDecimal(row["TOTAL_SALARYDEBIT_D_CNT"]),
        //                MinSalarydebitDAmt = Convert.ToDecimal(row["MIN_SALARYDEBIT_D_AMT"]),
        //                MaxSalarydebitDAmt = Convert.ToDecimal(row["MAX_SALARYDEBIT_D_AMT"]),
        //                TotalSecuritiesCCnt = Convert.ToDecimal(row["TOTAL_SECURITIES_C_CNT"]),
        //                AvgSecuritiesCAmt = Convert.ToDecimal(row["AVG_SECURITIES_C_AMT"]),
        //                MaxSecuritiesCAmt = Convert.ToDecimal(row["MAX_SECURITIES_C_AMT"]),
        //                TotalSecuritiesCAmt = Convert.ToDecimal(row["TOTAL_SECURITIES_C_AMT"]),
        //                MinSecuritiesCAmt = Convert.ToDecimal(row["MIN_SECURITIES_C_AMT"]),
        //                MaxSecuritiesDAmt = Convert.ToDecimal(row["MAX_SECURITIES_D_AMT"]),
        //                MinSecuritiesDAmt = Convert.ToDecimal(row["MIN_SECURITIES_D_AMT"]),
        //                AvgSecuritiesDAmt = Convert.ToDecimal(row["AVG_SECURITIES_D_AMT"]),
        //                TotalSecuritiesDAmt = Convert.ToDecimal(row["TOTAL_SECURITIES_D_AMT"]),
        //                TotalSecuritiesDCnt = Convert.ToDecimal(row["TOTAL_SECURITIES_D_CNT"]),
        //                MaxSellsecurityDAmt = Convert.ToDecimal(row["MAX_SELLSECURITY_D_AMT"]),
        //                AvgSellsecurityDAmt = Convert.ToDecimal(row["AVG_SELLSECURITY_D_AMT"]),
        //                TotalSellsecurityDAmt = Convert.ToDecimal(row["TOTAL_SELLSECURITY_D_AMT"]),
        //                TotalSellsecurityDCnt = Convert.ToDecimal(row["TOTAL_SELLSECURITY_D_CNT"]),
        //                MinSellsecurityDAmt = Convert.ToDecimal(row["MIN_SELLSECURITY_D_AMT"]),
        //                TotalTdredemptionCAmt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_C_AMT"]),
        //                TotalTdredemptionCCnt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_C_CNT"]),
        //                MinTdredemptionCAmt = Convert.ToDecimal(row["MIN_TDREDEMPTION_C_AMT"]),

        //                AvgTdredemptionCAmt = Convert.ToDecimal(row["AVG_TDREDEMPTION_C_AMT"]),
        //                MaxTdredemptionCAmt = Convert.ToDecimal(row["MAX_TDREDEMPTION_C_AMT"]),
        //                AvgTdredemptionDAmt = Convert.ToDecimal(row["AVG_TDREDEMPTION_D_AMT"]),
        //                TotalTdredemptionDAmt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_D_AMT"]),
        //                TotalTdredemptionDCnt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_D_CNT"]),
        //                MinTdredemptionDAmt = Convert.ToDecimal(row["MIN_TDREDEMPTION_D_AMT"]),
        //                MaxTdredemptionDAmt = Convert.ToDecimal(row["MAX_TDREDEMPTION_D_AMT"]),
        //                TotalTermdepositCCnt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_C_CNT"]),
        //                AvgTermdepositCAmt = Convert.ToDecimal(row["AVG_TERMDEPOSIT_C_AMT"]),
        //                MaxTermdepositCAmt = Convert.ToDecimal(row["MAX_TERMDEPOSIT_C_AMT"]),
        //                TotalTermdepositCAmt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_C_AMT"]),
        //                MinTermdepositCAmt = Convert.ToDecimal(row["MIN_TERMDEPOSIT_C_AMT"]),
        //                MaxTermdepositDAmt = Convert.ToDecimal(row["MAX_TERMDEPOSIT_D_AMT"]),
        //                MinTermdepositDAmt = Convert.ToDecimal(row["MIN_TERMDEPOSIT_D_AMT"]),
        //                AvgTermdepositDAmt = Convert.ToDecimal(row["AVG_TERMDEPOSIT_D_AMT"]),
        //                TotalTermdepositDAmt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_D_AMT"]),
        //                TotalTermdepositDCnt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_D_CNT"]),
        //                MaxTtissuanceDAmt = Convert.ToDecimal(row["MAX_TTISSUANCE_D_AMT"]),
        //                AvgTtissuanceDAmt = Convert.ToDecimal(row["AVG_TTISSUANCE_D_AMT"]),
        //                TotalTtissuanceDAmt = Convert.ToDecimal(row["TOTAL_TTISSUANCE_D_AMT"]),
        //                TotalTtissuanceDCnt = Convert.ToDecimal(row["TOTAL_TTISSUANCE_D_CNT"]),
        //                MinTtissuanceDAmt = Convert.ToDecimal(row["MIN_TTISSUANCE_D_AMT"]),
        //                MaxMls = Convert.ToDecimal(row["MAX_MLS"]),
        //                AlertsCnt = Convert.ToDecimal(row["ALERTS_CNT"]),
        //                Segment = (string)row["segment"].ToString() ?? "0",
        //                SegmentSorted = (string)row["segment_sorted"].ToString() ?? "0"




        //            });
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine($"Error {e.Message.ToString()}");
        //        }



        //    }
        //    fcfcore.MebSegmentsV3s.AddRange(segments);
        //    fcfcore.SaveChanges();
        //    //}


        //    string[] qureries = { "drop table ART_MEB_SEGMENTS_V3_TB; ", "create table ART_MEB_SEGMENTS_V3_TB as select* from ART_MEB_SEGMENTS_V3;",
        //    "drop table ART_ALL_SEGS_FEATRS_STATCS_TB;","create table ART_ALL_SEGS_FEATRS_STATCS_TB as select* from ART_ALL_SEGS_FEATRS_STATCS;",
        //    "drop table ART_INDUSTRY_SEGMENT_TB;","create table ART_INDUSTRY_SEGMENT_TB as select* from ART_INDUSTRY_SEGMENT;",
        //    "drop table ART_ALL_SEGS_OUTLIERS_LIMIT_TB;","create table ART_ALL_SEGS_OUTLIERS_LIMIT_TB as select* from ART_ALL_SEGS_OUTLIERS_LIMIT;",
        //    "drop table ART_ALL_SEGMENTS_OUTLIERS_TB;","create table ART_ALL_SEGMENTS_OUTLIERS_TB as select* from ART_ALL_SEGMENTS_OUTLIERS;",
        //    "drop table ART_SEGOUTVSALLOUT_TB;","create table ART_SEGOUTVSALLOUT_TB as select* from ART_SEGOUTVSALLOUT;",
        //    "drop table ART_SEGOUTVSALLCUST_TB;","create table ART_SEGOUTVSALLCUST_TB as select* from ART_SEGOUTVSALLCUST;",
        //    "drop table ART_CUSTS_PER_TYPE_TB;","create table ART_CUSTS_PER_TYPE_TB as select* from ART_CUSTS_PER_TYPE;",
        //    "drop table ART_ALL_SEGMENT_CUST_COUNT_TB;","create table ART_ALL_SEGMENT_CUST_COUNT_TB as select* from ART_ALL_SEGMENT_CUST_COUNT;",
        //    "drop table ART_ALERTS_PER_SEGMENT_TB;","create table ART_ALERTS_PER_SEGMENT_TB as select* from ART_ALERTS_PER_SEGMENT;"};

        //    foreach (string line in qureries)
        //    {
        //        using (OracleConnection connection = new OracleConnection(connectionStr))
        //        {
        //            OracleCommand command = new OracleCommand(line, connection);
        //            connection.Open();
        //            //OracleDataReader reader = command.ExecuteReader();
        //            try
        //            {
        //                command.ExecuteNonQuery();

        //                //while (reader.Read())
        //                //{
        //                //    Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetInt32(1));
        //                //}
        //            }
        //            finally
        //            {
        //                // always call Close when done reading.
        //                connection.Close();
        //            }
        //        }
        //    }
        //    //fcfcore.MebSegmentsV3s = dt;

        //    return Content(JsonConvert.SerializeObject(Ok(new { result = "Successs" })), "application/json");

        //}



        //public ContentResult BulkInsertDataTable_BK()
        //{




        //    DataTable dt = CSVtoDataTable();
        //    List<Segmentation_Automation.MebSegmentsV3Bk> segments = new List<Segmentation_Automation.MebSegmentsV3Bk>();
        //    int counter = 0;
        //    //foreach (DataColumn col in dt.Columns)
        //    //{
        //    foreach (DataRow row in dt.Rows)
        //    {


        //        try
        //        {
        //            Models.MebSegmentsV3 temp = new Models.MebSegmentsV3();

        //            Console.WriteLine(row["RISK_CLASSIFICATION"]);
        //            Console.WriteLine(row["RISK_CLASSIFICATION"].ToString());
        //            Console.WriteLine(Convert.ToDecimal(row["RISK_CLASSIFICATION"]));
        //            Console.WriteLine(row["TOTAL_CREDIT_AMOUNT"]);
        //            var customer = fcfcore.Set<Segmentation_Automation.MebSegmentsV3>();


        //            //temp.MonthKey = (string)row["MONTH_KEY"];
        //            //temp.PartyNumber = (string)row["PARTY_NUMBER"];
        //            //temp.RiskClassification = Convert.ToDecimal(row["RISK_CLASSIFICATION"]);
        //            //temp.PartyTypeDesc = (string)row["PARTY_TYPE_DESC"];
        //            //temp.IndustryCode = (string)row["INDUSTRY_CODE"];
        //            //temp.IndustryDesc = (string)row["INDUSTRY_DESC"];
        //            //temp.OccupationCode = (string)row["OCCUPATION_CODE"];
        //            //temp.OccupationDesc = (string)row["OCCUPATION_DESC"];
        //            //temp.TotalCreditAmount = (decimal)row["TOTAL_CREDIT_AMOUNT"];
        //            //temp.TotalDebitAmount = (decimal)row["TOTAL_DEBIT_AMOUNT"];
        //            //temp.TotalCreditCnt = (decimal)row["TOTAL_CREDIT_CNT"];
        //            //temp.TotalDebitCnt = (decimal)row["TOTAL_DEBIT_CNT"];
        //            //temp.TotalAmount = (decimal)row["TOTAL_AMOUNT"];
        //            //temp.TotalCnt = (decimal)row["TOTAL_CNT"];





        //            //temp.AvgTotalAmt = (decimal)row["AVG_TOTAL_AMT"];
        //            //temp.MaxTotalAmt = (decimal)row["MAX_TOTAL_AMT"];
        //            //temp.MinTotalAmt = (decimal)row["MIN_TOTAL_AMT"];
        //            //temp.AvgTotalCAmt = (decimal)row["AVG_TOTAL_C_AMT"];
        //            //temp.MaxTotalCAmt = (decimal)row["MAX_TOTAL_C_AMT"];
        //            //temp.MinTotalCAmt = (decimal)row["MIN_TOTAL_C_AMT"];
        //            //temp.AvgTotalDAmt = (decimal)row["AVG_TOTAL_D_AMT"];
        //            //temp.MaxTotalDAmt = (decimal)row["MAX_TOTAL_D_AMT"];
        //            //temp.MinTotalDAmt = (decimal)row["MIN_TOTAL_D_AMT"];
        //            //temp.NumberOfLocations = (decimal)row["NUMBER_OF_LOCATIONS"];
        //            //temp.AvgWireCAmt = (decimal)row["AVG_WIRE_C_AMT"];
        //            //temp.MaxWireCAmt = (decimal)row["MAX_WIRE_C_AMT"];
        //            //temp.TotalWireCAmt = (decimal)row["TOTAL_WIRE_C_AMT"];
        //            //temp.MinWireCAmt = (decimal)row["MIN_WIRE_C_AMT"];
        //            //temp.TotalWireCCnt = (decimal)row["TOTAL_WIRE_C_CNT"];
        //            //temp.MaxWireDAmt = (decimal)row["MAX_WIRE_D_AMT"];
        //            //temp.TotalWireDAmt = (decimal)row["TOTAL_WIRE_D_AMT"];
        //            //temp.TotalWireDCnt = (decimal)row["TOTAL_WIRE_D_CNT"];
        //            //temp.MinWireDAmt = (decimal)row["MIN_WIRE_D_AMT"];
        //            //temp.AvgWireDAmt = (decimal)row["AVG_WIRE_D_AMT"];
        //            //temp.AvgBuysecurityCAmt = (decimal)row["AVG_BUYSECURITY_C_AMT"];
        //            //temp.TotalBuysecurityCCnt = (decimal)row["TOTAL_BUYSECURITY_C_CNT"];
        //            //temp.TotalBuysecurityCAmt = (decimal)row["TOTAL_BUYSECURITY_C_AMT"];

        //            //temp.MinBuysecurityCAmt = (decimal)row["MIN_BUYSECURITY_C_AMT"];
        //            //temp.MaxBuysecurityCAmt = (decimal)row["MAX_BUYSECURITY_C_AMT"];
        //            //temp.TotalCashCAmt = (decimal)row["TOTAL_CASH_C_AMT"];
        //            //temp.TotalCashCCnt = (decimal)row["TOTAL_CASH_C_CNT"];
        //            //temp.MinCashCAmt = (decimal)row["MIN_CASH_C_AMT"];
        //            //temp.AvgCashCAmt = (decimal)row["AVG_CASH_C_AMT"];
        //            //temp.MaxCashCAmt = (decimal)row["MAX_CASH_C_AMT"];
        //            //temp.AvgCashDAmt = (decimal)row["AVG_CASH_D_AMT"];
        //            //temp.TotalCashDAmt = (decimal)row["TOTAL_CASH_D_AMT"];
        //            //temp.TotalCashDCnt = (decimal)row["TOTAL_CASH_D_CNT"];
        //            //temp.MinCashDAmt = (decimal)row["MIN_CASH_D_AMT"];
        //            //temp.MaxCashDAmt = (decimal)row["MAX_CASH_D_AMT"];
        //            //temp.TotalCheckDCnt = (decimal)row["TOTAL_CHECK_D_CNT"];
        //            //temp.AvgCheckDAmt = (decimal)row["AVG_CHECK_D_AMT"];
        //            //temp.MaxCheckDAmt = (decimal)row["MAX_CHECK_D_AMT"];
        //            //temp.TotalCheckDAmt = (decimal)row["TOTAL_CHECK_D_AMT"];
        //            //temp.MinCheckDAmt = (decimal)row["MIN_CHECK_D_AMT"];
        //            //temp.MaxClearingcheckCAmt = (decimal)row["MAX_CLEARINGCHECK_C_AMT"];
        //            //temp.MinClearingcheckCAmt = (decimal)row["MIN_CLEARINGCHECK_C_AMT"];
        //            //temp.AvgClearingcheckCAmt = (decimal)row["AVG_CLEARINGCHECK_C_AMT"];
        //            //temp.TotalClearingcheckCAmt = (decimal)row["TOTAL_CLEARINGCHECK_C_AMT"];
        //            //temp.TotalClearingcheckCCnt = (decimal)row["TOTAL_CLEARINGCHECK_C_CNT"];
        //            //temp.MaxClearingcheckDAmt = (decimal)row["MAX_CLEARINGCHECK_D_AMT"];
        //            //temp.AvgClearingcheckDAmt = (decimal)row["AVG_CLEARINGCHECK_D_AMT"];

        //            //temp.TotalClearingcheckDAmt = (decimal)row["TOTAL_CLEARINGCHECK_D_AMT"];
        //            //temp.TotalClearingcheckDCnt = (decimal)row["TOTAL_CLEARINGCHECK_D_CNT"];
        //            //temp.MinClearingcheckDAmt = (decimal)row["MIN_CLEARINGCHECK_D_AMT"];
        //            //temp.AvgDerivativesCAmt = (decimal)row["AVG_DERIVATIVES_C_AMT"];
        //            //temp.MaxDerivativesCAmt = (decimal)row["MAX_DERIVATIVES_C_AMT"];
        //            //temp.TotalDerivativesCAmt = (decimal)row["TOTAL_DERIVATIVES_C_AMT"];
        //            //temp.MinDerivativesCAmt = (decimal)row["MIN_DERIVATIVES_C_AMT"];
        //            //temp.TotalDerivativesCCnt = (decimal)row["TOTAL_DERIVATIVES_C_CNT"];
        //            //temp.MaxDerivativesDAmt = (decimal)row["MAX_DERIVATIVES_D_AMT"];
        //            //temp.TotalDerivativesDAmt = (decimal)row["TOTAL_DERIVATIVES_D_AMT"];
        //            //temp.TotalDerivativesDCnt = (decimal)row["TOTAL_DERIVATIVES_D_CNT"];
        //            //temp.MinDerivativesDAmt = (decimal)row["MIN_DERIVATIVES_D_AMT"];
        //            //temp.AvgDerivativesDAmt = (decimal)row["AVG_DERIVATIVES_D_AMT"];
        //            //temp.AvgInhousecheckCAmt = (decimal)row["AVG_INHOUSECHECK_C_AMT"];
        //            //temp.TotalInhousecheckCAmt = (decimal)row["TOTAL_INHOUSECHECK_C_AMT"];
        //            //temp.MinInhousecheckCAmt = (decimal)row["MIN_INHOUSECHECK_C_AMT"];
        //            //temp.MaxInhousecheckCAmt = (decimal)row["MAX_INHOUSECHECK_C_AMT"];
        //            //temp.TotalInhousecheckCCnt = (decimal)row["TOTAL_INHOUSECHECK_C_CNT"];
        //            //temp.TotalInhousecheckDCnt = (decimal)row["TOTAL_INHOUSECHECK_D_CNT"];
        //            //temp.AvgInhousecheckDAmt = (decimal)row["AVG_INHOUSECHECK_D_AMT"];
        //            //temp.TotalInhousecheckDAmt = (decimal)row["TOTAL_INHOUSECHECK_D_AMT"];
        //            //temp.MinInhousecheckDAmt = (decimal)row["MIN_INHOUSECHECK_D_AMT"];
        //            //temp.MaxInhousecheckDAmt = (decimal)row["MAX_INHOUSECHECK_D_AMT"];
        //            //temp.MaxInternaltransferCAmt = (decimal)row["MAX_INTERNALTRANSFER_C_AMT"];
        //            //temp.MinInternaltransferCAmt = (decimal)row["MIN_INTERNALTRANSFER_C_AMT"];
        //            //temp.TotalInternaltransferCCnt = (decimal)row["TOTAL_INTERNALTRANSFER_C_CNT"];
        //            //temp.TotalInternaltransferCAmt = (decimal)row["TOTAL_INTERNALTRANSFER_C_AMT"];
        //            //temp.AvgInternaltransferCAmt = (decimal)row["AVG_INTERNALTRANSFER_C_AMT"];
        //            //temp.MinInternaltransferDAmt = (decimal)row["MIN_INTERNALTRANSFER_D_AMT"];
        //            //temp.TotalInternaltransferDCnt = (decimal)row["TOTAL_INTERNALTRANSFER_D_CNT"];
        //            //temp.AvgInternaltransferDAmt = (decimal)row["AVG_INTERNALTRANSFER_D_AMT"];
        //            //temp.TotalInternaltransferDAmt = (decimal)row["TOTAL_INTERNALTRANSFER_D_AMT"];
        //            //temp.MaxInternaltransferDAmt = (decimal)row["MAX_INTERNALTRANSFER_D_AMT"];
        //            //temp.MaxLcBlClcnCAmt = (decimal)row["MAX_LC_BL_CLCN_C_AMT"];
        //            //temp.MinLcBlClcnCAmt = (decimal)row["MIN_LC_BL_CLCN_C_AMT"];
        //            //temp.TotalLcBlClcnCCnt = (decimal)row["TOTAL_LC_BL_CLCN_C_CNT"];
        //            //temp.AvgLcBlClcnCAmt = (decimal)row["AVG_LC_BL_CLCN_C_AMT"];
        //            //temp.TotalLcBlClcnCAmt = (decimal)row["TOTAL_LC_BL_CLCN_C_AMT"];
        //            //temp.TotalLcBlClcnDAmt = (decimal)row["TOTAL_LC_BL_CLCN_D_AMT"];
        //            //temp.MaxLcBlClcnDAmt = (decimal)row["MAX_LC_BL_CLCN_D_AMT"];
        //            //temp.MinLcBlClcnDAmt = (decimal)row["MIN_LC_BL_CLCN_D_AMT"];
        //            //temp.AvgLcBlClcnDAmt = (decimal)row["AVG_LC_BL_CLCN_D_AMT"];
        //            //temp.TotalLcBlClcnDCnt = (decimal)row["TOTAL_LC_BL_CLCN_D_CNT"];
        //            //temp.TotalLccollectionCCnt = (decimal)row["TOTAL_LCCOLLECTION_C_CNT"];
        //            //temp.MaxLccollectionCAmt = (decimal)row["MAX_LCCOLLECTION_C_AMT"];
        //            //temp.AvgLccollectionCAmt = (decimal)row["AVG_LCCOLLECTION_C_AMT"];
        //            //temp.MinLccollectionCAmt = (decimal)row["MIN_LCCOLLECTION_C_AMT"];
        //            //temp.TotalLccollectionCAmt = (decimal)row["TOTAL_LCCOLLECTION_C_AMT"];
        //            //temp.TotalLccollectionDCnt = (decimal)row["TOTAL_LCCOLLECTION_D_CNT"];
        //            //temp.AvgLccollectionDAmt = (decimal)row["AVG_LCCOLLECTION_D_AMT"];
        //            //temp.MaxLccollectionDAmt = (decimal)row["MAX_LCCOLLECTION_D_AMT"];
        //            //temp.TotalLccollectionDAmt = (decimal)row["TOTAL_LCCOLLECTION_D_AMT"];
        //            //temp.MinLccollectionDAmt = (decimal)row["MIN_LCCOLLECTION_D_AMT"];
        //            //temp.TotalLoanCCnt = (decimal)row["TOTAL_LOAN_C_CNT"];
        //            //temp.AvgLoanCAmt = (decimal)row["AVG_LOAN_C_AMT"];
        //            //temp.MinLoanCAmt = (decimal)row["MIN_LOAN_C_AMT"];
        //            //temp.TotalLoanCAmt = (decimal)row["TOTAL_LOAN_C_AMT"];
        //            //temp.MaxLoanCAmt = (decimal)row["MAX_LOAN_C_AMT"];
        //            //temp.TotalLoanDAmt = (decimal)row["TOTAL_LOAN_D_AMT"];
        //            //temp.MaxLoanDAmt = (decimal)row["MAX_LOAN_D_AMT"];
        //            //temp.MinLoanDAmt = (decimal)row["MIN_LOAN_D_AMT"];
        //            //temp.TotalLoanDCnt = (decimal)row["TOTAL_LOAN_D_CNT"];
        //            //temp.AvgLoanDAmt = (decimal)row["AVG_LOAN_D_AMT"];
        //            //temp.MaxLoandisbursementCAmt = (decimal)row["MAX_LOANDISBURSEMENT_C_AMT"];
        //            //temp.MinLoandisbursementCAmt = (decimal)row["MIN_LOANDISBURSEMENT_C_AMT"];
        //            //temp.AvgLoandisbursementCAmt = (decimal)row["AVG_LOANDISBURSEMENT_C_AMT"];
        //            //temp.TotalLoandisbursementCAmt = (decimal)row["TOTAL_LOANDISBURSEMENT_C_AMT"];
        //            //temp.TotalLoandisbursementCCnt = (decimal)row["TOTAL_LOANDISBURSEMENT_C_CNT"];
        //            //temp.AvgLoantopUpCAmt = (decimal)row["AVG_LOANTOP_UP_C_AMT"];
        //            //temp.MinLoantopUpCAmt = (decimal)row["MIN_LOANTOP_UP_C_AMT"];
        //            //temp.TotalLoantopUpCAmt = (decimal)row["TOTAL_LOANTOP_UP_C_AMT"];
        //            //temp.TotalLoantopUpCCnt = (decimal)row["TOTAL_LOANTOP_UP_C_CNT"];
        //            //temp.MaxLoantopUpCAmt = (decimal)row["MAX_LOANTOP_UP_C_AMT"];
        //            //temp.AvgMngrschckissnceCAmt = (decimal)row["AVG_MNGRSCHCKISSNCE_C_AMT"];
        //            //temp.TotalMngrschckissnceCCnt = (decimal)row["TOTAL_MNGRSCHCKISSNCE_C_CNT"];
        //            //temp.MaxMngrschckissnceCAmt = (decimal)row["MAX_MNGRSCHCKISSNCE_C_AMT"];
        //            //temp.MinMngrschckissnceCAmt = (decimal)row["MIN_MNGRSCHCKISSNCE_C_AMT"];
        //            //temp.TotalMngrschckissnceCAmt = (decimal)row["TOTAL_MNGRSCHCKISSNCE_C_AMT"];
        //            //temp.MaxMngrschckissnceDAmt = (decimal)row["MAX_MNGRSCHCKISSNCE_D_AMT"];
        //            //temp.TotalMngrschckissnceDAmt = (decimal)row["TOTAL_MNGRSCHCKISSNCE_D_AMT"];
        //            //temp.MinMngrschckissnceDAmt = (decimal)row["MIN_MNGRSCHCKISSNCE_D_AMT"];
        //            //temp.TotalMngrschckissnceDCnt = (decimal)row["TOTAL_MNGRSCHCKISSNCE_D_CNT"];
        //            //temp.AvgMngrschckissnceDAmt = (decimal)row["AVG_MNGRSCHCKISSNCE_D_AMT"];
        //            //temp.TotalMiscCCnt = (decimal)row["TOTAL_MISC_C_CNT"];
        //            //temp.AvgMiscCAmt = (decimal)row["AVG_MISC_C_AMT"];
        //            //temp.TotalMiscCAmt = (decimal)row["TOTAL_MISC_C_AMT"];
        //            //temp.MinMiscCAmt = (decimal)row["MIN_MISC_C_AMT"];
        //            //temp.MaxMiscCAmt = (decimal)row["MAX_MISC_C_AMT"];
        //            //temp.TotalMiscDAmt = (decimal)row["TOTAL_MISC_D_AMT"];
        //            //temp.AvgMiscDAmt = (decimal)row["AVG_MISC_D_AMT"];
        //            //temp.MaxMiscDAmt = (decimal)row["MAX_MISC_D_AMT"];
        //            //temp.MinMiscDAmt = (decimal)row["MIN_MISC_D_AMT"];
        //            //temp.TotalMiscDCnt = (decimal)row["TOTAL_MISC_D_CNT"];
        //            //temp.AvgOutwrdchqrtrnDAmt = (decimal)row["AVG_OUTWRDCHQRTRN_D_AMT"];
        //            //temp.TotalOutwrdchqrtrnDCnt = (decimal)row["TOTAL_OUTWRDCHQRTRN_D_CNT"];
        //            //temp.TotalOutwrdchqrtrnDAmt = (decimal)row["TOTAL_OUTWRDCHQRTRN_D_AMT"];
        //            //temp.MinOutwrdchqrtrnDAmt = (decimal)row["MIN_OUTWRDCHQRTRN_D_AMT"];
        //            //temp.MaxOutwrdchqrtrnDAmt = (decimal)row["MAX_OUTWRDCHQRTRN_D_AMT"];
        //            //temp.AvgPymntofinstllmntDAmt = (decimal)row["AVG_PYMNTOFINSTLLMNT_D_AMT"];
        //            //temp.TotalPymntofinstllmntDCnt = (decimal)row["TOTAL_PYMNTOFINSTLLMNT_D_CNT"];
        //            //temp.TotalPymntofinstllmntDAmt = (decimal)row["TOTAL_PYMNTOFINSTLLMNT_D_AMT"];
        //            //temp.MinPymntofinstllmntDAmt = (decimal)row["MIN_PYMNTOFINSTLLMNT_D_AMT"];
        //            //temp.MaxPymntofinstllmntDAmt = (decimal)row["MAX_PYMNTOFINSTLLMNT_D_AMT"];
        //            //temp.AvgReturnedwiresDAmt = (decimal)row["AVG_RETURNEDWIRES_D_AMT"];
        //            //temp.MaxReturnedwiresDAmt = (decimal)row["MAX_RETURNEDWIRES_D_AMT"];
        //            //temp.TotalReturnedwiresDAmt = (decimal)row["TOTAL_RETURNEDWIRES_D_AMT"];
        //            //temp.MinReturnedwiresDAmt = (decimal)row["MIN_RETURNEDWIRES_D_AMT"];
        //            //temp.TotalReturnedwiresDCnt = (decimal)row["TOTAL_RETURNEDWIRES_D_CNT"];
        //            //temp.MaxReturnchequeCAmt = (decimal)row["MAX_RETURNCHEQUE_C_AMT"];
        //            //temp.TotalReturnchequeCAmt = (decimal)row["TOTAL_RETURNCHEQUE_C_AMT"];
        //            //temp.TotalReturnchequeCCnt = (decimal)row["TOTAL_RETURNCHEQUE_C_CNT"];
        //            //temp.MinReturnchequeCAmt = (decimal)row["MIN_RETURNCHEQUE_C_AMT"];
        //            //temp.AvgReturnchequeCAmt = (decimal)row["AVG_RETURNCHEQUE_C_AMT"];
        //            //temp.TotalSalarycreditCAmt = (decimal)row["TOTAL_SALARYCREDIT_C_AMT"];
        //            //temp.TotalSalarycreditCCnt = (decimal)row["TOTAL_SALARYCREDIT_C_CNT"];
        //            //temp.MinSalarycreditCAmt = (decimal)row["MIN_SALARYCREDIT_C_AMT"];
        //            //temp.AvgSalarycreditCAmt = (decimal)row["AVG_SALARYCREDIT_C_AMT"];
        //            //temp.MaxSalarycreditCAmt = (decimal)row["MAX_SALARYCREDIT_C_AMT"];
        //            //temp.AvgSalarydebitDAmt = (decimal)row["AVG_SALARYDEBIT_D_AMT"];
        //            //temp.TotalSalarydebitDAmt = (decimal)row["TOTAL_SALARYDEBIT_D_AMT"];
        //            //temp.TotalSalarydebitDCnt = (decimal)row["TOTAL_SALARYDEBIT_D_CNT"];
        //            //temp.MinSalarydebitDAmt = (decimal)row["MIN_SALARYDEBIT_D_AMT"];
        //            //temp.MaxSalarydebitDAmt = (decimal)row["MAX_SALARYDEBIT_D_AMT"];
        //            //temp.TotalSecuritiesCCnt = (decimal)row["TOTAL_SECURITIES_C_CNT"];
        //            //temp.AvgSecuritiesCAmt = (decimal)row["AVG_SECURITIES_C_AMT"];
        //            //temp.MaxSecuritiesCAmt = (decimal)row["MAX_SECURITIES_C_AMT"];
        //            //temp.TotalSecuritiesCAmt = (decimal)row["TOTAL_SECURITIES_C_AMT"];
        //            //temp.MinSecuritiesCAmt = (decimal)row["MIN_SECURITIES_C_AMT"];
        //            //temp.MaxSecuritiesDAmt = (decimal)row["MAX_SECURITIES_D_AMT"];
        //            //temp.MinSecuritiesDAmt = (decimal)row["MIN_SECURITIES_D_AMT"];
        //            //temp.AvgSecuritiesDAmt = (decimal)row["AVG_SECURITIES_D_AMT"];
        //            //temp.TotalSecuritiesDAmt = (decimal)row["TOTAL_SECURITIES_D_AMT"];
        //            //temp.TotalSecuritiesDCnt = (decimal)row["TOTAL_SECURITIES_D_CNT"];
        //            //temp.MaxSellsecurityDAmt = (decimal)row["MAX_SELLSECURITY_D_AMT"];
        //            //temp.AvgSellsecurityDAmt = (decimal)row["AVG_SELLSECURITY_D_AMT"];
        //            //temp.TotalSellsecurityDAmt = (decimal)row["TOTAL_SELLSECURITY_D_AMT"];
        //            //temp.TotalSellsecurityDCnt = (decimal)row["TOTAL_SELLSECURITY_D_CNT"];
        //            //temp.MinSellsecurityDAmt = (decimal)row["MIN_SELLSECURITY_D_AMT"];
        //            //temp.TotalTdredemptionCAmt = (decimal)row["TOTAL_TDREDEMPTION_C_AMT"];
        //            //temp.TotalTdredemptionCCnt = (decimal)row["TOTAL_TDREDEMPTION_C_CNT"];
        //            //temp.MinTdredemptionCAmt = (decimal)row["MIN_TDREDEMPTION_C_AMT"];

        //            //temp.AvgTdredemptionCAmt = (decimal)row["AVG_TDREDEMPTION_C_AMT"];
        //            //temp.MaxTdredemptionCAmt = (decimal)row["MAX_TDREDEMPTION_C_AMT"];
        //            //temp.AvgTdredemptionDAmt = (decimal)row["AVG_TDREDEMPTION_D_AMT"];
        //            //temp.TotalTdredemptionDAmt = (decimal)row["TOTAL_TDREDEMPTION_D_AMT"];
        //            //temp.TotalTdredemptionDCnt = (decimal)row["TOTAL_TDREDEMPTION_D_CNT"];
        //            //temp.MinTdredemptionDAmt = (decimal)row["MIN_TDREDEMPTION_D_AMT"];
        //            //temp.MaxTdredemptionDAmt = (decimal)row["MAX_TDREDEMPTION_D_AMT"];
        //            //temp.TotalTermdepositCCnt = (decimal)row["TOTAL_TERMDEPOSIT_C_CNT"];
        //            //temp.AvgTermdepositCAmt = (decimal)row["AVG_TERMDEPOSIT_C_AMT"];
        //            //temp.MaxTermdepositCAmt = (decimal)row["MAX_TERMDEPOSIT_C_AMT"];
        //            //temp.TotalTermdepositCAmt = (decimal)row["TOTAL_TERMDEPOSIT_C_AMT"];
        //            //temp.MinTermdepositCAmt = (decimal)row["MIN_TERMDEPOSIT_C_AMT"];
        //            //temp.MaxTermdepositDAmt = (decimal)row["MAX_TERMDEPOSIT_D_AMT"];
        //            //temp.MinTermdepositDAmt = (decimal)row["MIN_TERMDEPOSIT_D_AMT"];
        //            //temp.AvgTermdepositDAmt = (decimal)row["AVG_TERMDEPOSIT_D_AMT"];
        //            //temp.TotalTermdepositDAmt = (decimal)row["TOTAL_TERMDEPOSIT_D_AMT"];
        //            //temp.TotalTermdepositDCnt = (decimal)row["TOTAL_TERMDEPOSIT_D_CNT"];
        //            //temp.MaxTtissuanceDAmt = (decimal)row["MAX_TTISSUANCE_D_AMT"];
        //            //temp.AvgTtissuanceDAmt = (decimal)row["AVG_TTISSUANCE_D_AMT"];
        //            //temp.TotalTtissuanceDAmt = (decimal)row["TOTAL_TTISSUANCE_D_AMT"];
        //            //temp.TotalTtissuanceDCnt = (decimal)row["TOTAL_TTISSUANCE_D_CNT"];
        //            //temp.MinTtissuanceDAmt = (decimal)row["MIN_TTISSUANCE_D_AMT"];
        //            //temp.MaxMls = (decimal)row["MAX_MLS"];
        //            //temp.AlertsCnt = (decimal)row["ALERTS_CNT"];
        //            //temp.Segment = (string)row["segment"];
        //            //temp.SegmentSorted = (string)row["segment_sorted"];

        //            counter += 1;
        //            //segments.Add(temp);


        //            //fcfcore.Add(temp);
        //            //fcfcore.MebSegmentsV3s.AddAsync(temp);




        //            segments.Add(new Segmentation_Automation.MebSegmentsV3Bk
        //            {

        //                MonthKey = (string)row["MONTH_KEY"].ToString() ?? "0",
        //                PartyNumber = (string)row["PARTY_NUMBER"].ToString() ?? "0",
        //                RiskClassification = Convert.ToDecimal(row["RISK_CLASSIFICATION"]),
        //                PartyTypeDesc = (string)row["PARTY_TYPE_DESC"].ToString() ?? "0",
        //                IndustryCode = (string)row["INDUSTRY_CODE"].ToString() ?? "0",
        //                IndustryDesc = (string)row["INDUSTRY_DESC"].ToString() ?? "0",
        //                OccupationCode = (string)row["OCCUPATION_CODE"].ToString() ?? "0",
        //                OccupationDesc = (string)row["OCCUPATION_DESC"].ToString() ?? "0",
        //                TotalCreditAmount = Convert.ToDecimal(row["TOTAL_CREDIT_AMOUNT"]),
        //                TotalDebitAmount = Convert.ToDecimal(row["TOTAL_DEBIT_AMOUNT"]),
        //                TotalCreditCnt = Convert.ToDecimal(row["TOTAL_CREDIT_CNT"]),
        //                TotalDebitCnt = Convert.ToDecimal(row["TOTAL_DEBIT_CNT"]),
        //                TotalAmount = Convert.ToDecimal(row["TOTAL_AMOUNT"]),
        //                TotalCnt = Convert.ToDecimal(row["TOTAL_CNT"]),
        //                AvgTotalAmt = Convert.ToDecimal(row["AVG_TOTAL_AMT"]),
        //                MaxTotalAmt = Convert.ToDecimal(row["MAX_TOTAL_AMT"]),
        //                MinTotalAmt = Convert.ToDecimal(row["MIN_TOTAL_AMT"]),
        //                AvgTotalCAmt = Convert.ToDecimal(row["AVG_TOTAL_C_AMT"]),
        //                MaxTotalCAmt = Convert.ToDecimal(row["MAX_TOTAL_C_AMT"]),
        //                MinTotalCAmt = Convert.ToDecimal(row["MIN_TOTAL_C_AMT"]),
        //                AvgTotalDAmt = Convert.ToDecimal(row["AVG_TOTAL_D_AMT"]),
        //                MaxTotalDAmt = Convert.ToDecimal(row["MAX_TOTAL_D_AMT"]),
        //                MinTotalDAmt = Convert.ToDecimal(row["MIN_TOTAL_D_AMT"]),
        //                NumberOfLocations = Convert.ToDecimal(row["NUMBER_OF_LOCATIONS"]),
        //                AvgWireCAmt = Convert.ToDecimal(row["AVG_WIRE_C_AMT"]),
        //                MaxWireCAmt = Convert.ToDecimal(row["MAX_WIRE_C_AMT"]),
        //                TotalWireCAmt = Convert.ToDecimal(row["TOTAL_WIRE_C_AMT"]),
        //                MinWireCAmt = Convert.ToDecimal(row["MIN_WIRE_C_AMT"]),
        //                TotalWireCCnt = Convert.ToDecimal(row["TOTAL_WIRE_C_CNT"]),
        //                MaxWireDAmt = Convert.ToDecimal(row["MAX_WIRE_D_AMT"]),
        //                TotalWireDAmt = Convert.ToDecimal(row["TOTAL_WIRE_D_AMT"]),
        //                TotalWireDCnt = Convert.ToDecimal(row["TOTAL_WIRE_D_CNT"]),
        //                MinWireDAmt = Convert.ToDecimal(row["MIN_WIRE_D_AMT"]),
        //                AvgWireDAmt = Convert.ToDecimal(row["AVG_WIRE_D_AMT"]),
        //                AvgBuysecurityCAmt = Convert.ToDecimal(row["AVG_BUYSECURITY_C_AMT"]),
        //                TotalBuysecurityCCnt = Convert.ToDecimal(row["TOTAL_BUYSECURITY_C_CNT"]),
        //                TotalBuysecurityCAmt = Convert.ToDecimal(row["TOTAL_BUYSECURITY_C_AMT"]),

        //                MinBuysecurityCAmt = Convert.ToDecimal(row["MIN_BUYSECURITY_C_AMT"]),
        //                MaxBuysecurityCAmt = Convert.ToDecimal(row["MAX_BUYSECURITY_C_AMT"]),
        //                TotalCashCAmt = Convert.ToDecimal(row["TOTAL_CASH_C_AMT"]),
        //                TotalCashCCnt = Convert.ToDecimal(row["TOTAL_CASH_C_CNT"]),
        //                MinCashCAmt = Convert.ToDecimal(row["MIN_CASH_C_AMT"]),
        //                AvgCashCAmt = Convert.ToDecimal(row["AVG_CASH_C_AMT"]),
        //                MaxCashCAmt = Convert.ToDecimal(row["MAX_CASH_C_AMT"]),
        //                AvgCashDAmt = Convert.ToDecimal(row["AVG_CASH_D_AMT"]),
        //                TotalCashDAmt = Convert.ToDecimal(row["TOTAL_CASH_D_AMT"]),
        //                TotalCashDCnt = Convert.ToDecimal(row["TOTAL_CASH_D_CNT"]),
        //                MinCashDAmt = Convert.ToDecimal(row["MIN_CASH_D_AMT"]),
        //                MaxCashDAmt = Convert.ToDecimal(row["MAX_CASH_D_AMT"]),
        //                TotalCheckDCnt = Convert.ToDecimal(row["TOTAL_CHECK_D_CNT"]),
        //                AvgCheckDAmt = Convert.ToDecimal(row["AVG_CHECK_D_AMT"]),
        //                MaxCheckDAmt = Convert.ToDecimal(row["MAX_CHECK_D_AMT"]),
        //                TotalCheckDAmt = Convert.ToDecimal(row["TOTAL_CHECK_D_AMT"]),
        //                MinCheckDAmt = Convert.ToDecimal(row["MIN_CHECK_D_AMT"]),
        //                MaxClearingcheckCAmt = Convert.ToDecimal(row["MAX_CLEARINGCHECK_C_AMT"]),
        //                MinClearingcheckCAmt = Convert.ToDecimal(row["MIN_CLEARINGCHECK_C_AMT"]),
        //                AvgClearingcheckCAmt = Convert.ToDecimal(row["AVG_CLEARINGCHECK_C_AMT"]),
        //                TotalClearingcheckCAmt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_C_AMT"]),
        //                TotalClearingcheckCCnt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_C_CNT"]),
        //                MaxClearingcheckDAmt = Convert.ToDecimal(row["MAX_CLEARINGCHECK_D_AMT"]),
        //                AvgClearingcheckDAmt = Convert.ToDecimal(row["AVG_CLEARINGCHECK_D_AMT"]),

        //                TotalClearingcheckDAmt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_D_AMT"]),
        //                TotalClearingcheckDCnt = Convert.ToDecimal(row["TOTAL_CLEARINGCHECK_D_CNT"]),
        //                MinClearingcheckDAmt = Convert.ToDecimal(row["MIN_CLEARINGCHECK_D_AMT"]),
        //                AvgDerivativesCAmt = Convert.ToDecimal(row["AVG_DERIVATIVES_C_AMT"]),
        //                MaxDerivativesCAmt = Convert.ToDecimal(row["MAX_DERIVATIVES_C_AMT"]),
        //                TotalDerivativesCAmt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_C_AMT"]),
        //                MinDerivativesCAmt = Convert.ToDecimal(row["MIN_DERIVATIVES_C_AMT"]),
        //                TotalDerivativesCCnt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_C_CNT"]),
        //                MaxDerivativesDAmt = Convert.ToDecimal(row["MAX_DERIVATIVES_D_AMT"]),
        //                TotalDerivativesDAmt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_D_AMT"]),
        //                TotalDerivativesDCnt = Convert.ToDecimal(row["TOTAL_DERIVATIVES_D_CNT"]),
        //                MinDerivativesDAmt = Convert.ToDecimal(row["MIN_DERIVATIVES_D_AMT"]),
        //                AvgDerivativesDAmt = Convert.ToDecimal(row["AVG_DERIVATIVES_D_AMT"]),
        //                AvgInhousecheckCAmt = Convert.ToDecimal(row["AVG_INHOUSECHECK_C_AMT"]),
        //                TotalInhousecheckCAmt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_C_AMT"]),
        //                MinInhousecheckCAmt = Convert.ToDecimal(row["MIN_INHOUSECHECK_C_AMT"]),
        //                MaxInhousecheckCAmt = Convert.ToDecimal(row["MAX_INHOUSECHECK_C_AMT"]),
        //                TotalInhousecheckCCnt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_C_CNT"]),
        //                TotalInhousecheckDCnt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_D_CNT"]),
        //                AvgInhousecheckDAmt = Convert.ToDecimal(row["AVG_INHOUSECHECK_D_AMT"]),
        //                TotalInhousecheckDAmt = Convert.ToDecimal(row["TOTAL_INHOUSECHECK_D_AMT"]),
        //                MinInhousecheckDAmt = Convert.ToDecimal(row["MIN_INHOUSECHECK_D_AMT"]),
        //                MaxInhousecheckDAmt = Convert.ToDecimal(row["MAX_INHOUSECHECK_D_AMT"]),
        //                MaxInternaltransferCAmt = Convert.ToDecimal(row["MAX_INTERNALTRANSFER_C_AMT"]),
        //                MinInternaltransferCAmt = Convert.ToDecimal(row["MIN_INTERNALTRANSFER_C_AMT"]),
        //                TotalInternaltransferCCnt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_C_CNT"]),
        //                TotalInternaltransferCAmt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_C_AMT"]),
        //                AvgInternaltransferCAmt = Convert.ToDecimal(row["AVG_INTERNALTRANSFER_C_AMT"]),
        //                MinInternaltransferDAmt = Convert.ToDecimal(row["MIN_INTERNALTRANSFER_D_AMT"]),
        //                TotalInternaltransferDCnt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_D_CNT"]),
        //                AvgInternaltransferDAmt = Convert.ToDecimal(row["AVG_INTERNALTRANSFER_D_AMT"]),
        //                TotalInternaltransferDAmt = Convert.ToDecimal(row["TOTAL_INTERNALTRANSFER_D_AMT"]),
        //                MaxInternaltransferDAmt = Convert.ToDecimal(row["MAX_INTERNALTRANSFER_D_AMT"]),
        //                MaxLcBlClcnCAmt = Convert.ToDecimal(row["MAX_LC_BL_CLCN_C_AMT"]),
        //                MinLcBlClcnCAmt = Convert.ToDecimal(row["MIN_LC_BL_CLCN_C_AMT"]),
        //                TotalLcBlClcnCCnt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_C_CNT"]),
        //                AvgLcBlClcnCAmt = Convert.ToDecimal(row["AVG_LC_BL_CLCN_C_AMT"]),
        //                TotalLcBlClcnCAmt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_C_AMT"]),
        //                TotalLcBlClcnDAmt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_D_AMT"]),
        //                MaxLcBlClcnDAmt = Convert.ToDecimal(row["MAX_LC_BL_CLCN_D_AMT"]),
        //                MinLcBlClcnDAmt = Convert.ToDecimal(row["MIN_LC_BL_CLCN_D_AMT"]),
        //                AvgLcBlClcnDAmt = Convert.ToDecimal(row["AVG_LC_BL_CLCN_D_AMT"]),
        //                TotalLcBlClcnDCnt = Convert.ToDecimal(row["TOTAL_LC_BL_CLCN_D_CNT"]),
        //                TotalLccollectionCCnt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_C_CNT"]),
        //                MaxLccollectionCAmt = Convert.ToDecimal(row["MAX_LCCOLLECTION_C_AMT"]),
        //                AvgLccollectionCAmt = Convert.ToDecimal(row["AVG_LCCOLLECTION_C_AMT"]),
        //                MinLccollectionCAmt = Convert.ToDecimal(row["MIN_LCCOLLECTION_C_AMT"]),
        //                TotalLccollectionCAmt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_C_AMT"]),
        //                TotalLccollectionDCnt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_D_CNT"]),
        //                AvgLccollectionDAmt = Convert.ToDecimal(row["AVG_LCCOLLECTION_D_AMT"]),
        //                MaxLccollectionDAmt = Convert.ToDecimal(row["MAX_LCCOLLECTION_D_AMT"]),
        //                TotalLccollectionDAmt = Convert.ToDecimal(row["TOTAL_LCCOLLECTION_D_AMT"]),
        //                MinLccollectionDAmt = Convert.ToDecimal(row["MIN_LCCOLLECTION_D_AMT"]),
        //                TotalLoanCCnt = Convert.ToDecimal(row["TOTAL_LOAN_C_CNT"]),
        //                AvgLoanCAmt = Convert.ToDecimal(row["AVG_LOAN_C_AMT"]),
        //                MinLoanCAmt = Convert.ToDecimal(row["MIN_LOAN_C_AMT"]),
        //                TotalLoanCAmt = Convert.ToDecimal(row["TOTAL_LOAN_C_AMT"]),
        //                MaxLoanCAmt = Convert.ToDecimal(row["MAX_LOAN_C_AMT"]),
        //                TotalLoanDAmt = Convert.ToDecimal(row["TOTAL_LOAN_D_AMT"]),
        //                MaxLoanDAmt = Convert.ToDecimal(row["MAX_LOAN_D_AMT"]),
        //                MinLoanDAmt = Convert.ToDecimal(row["MIN_LOAN_D_AMT"]),
        //                TotalLoanDCnt = Convert.ToDecimal(row["TOTAL_LOAN_D_CNT"]),
        //                AvgLoanDAmt = Convert.ToDecimal(row["AVG_LOAN_D_AMT"]),
        //                MaxLoandisbursementCAmt = Convert.ToDecimal(row["MAX_LOANDISBURSEMENT_C_AMT"]),
        //                MinLoandisbursementCAmt = Convert.ToDecimal(row["MIN_LOANDISBURSEMENT_C_AMT"]),
        //                AvgLoandisbursementCAmt = Convert.ToDecimal(row["AVG_LOANDISBURSEMENT_C_AMT"]),
        //                TotalLoandisbursementCAmt = Convert.ToDecimal(row["TOTAL_LOANDISBURSEMENT_C_AMT"]),
        //                TotalLoandisbursementCCnt = Convert.ToDecimal(row["TOTAL_LOANDISBURSEMENT_C_CNT"]),
        //                AvgLoantopUpCAmt = Convert.ToDecimal(row["AVG_LOANTOP_UP_C_AMT"]),
        //                MinLoantopUpCAmt = Convert.ToDecimal(row["MIN_LOANTOP_UP_C_AMT"]),
        //                TotalLoantopUpCAmt = Convert.ToDecimal(row["TOTAL_LOANTOP_UP_C_AMT"]),
        //                TotalLoantopUpCCnt = Convert.ToDecimal(row["TOTAL_LOANTOP_UP_C_CNT"]),
        //                MaxLoantopUpCAmt = Convert.ToDecimal(row["MAX_LOANTOP_UP_C_AMT"]),
        //                AvgMngrschckissnceCAmt = Convert.ToDecimal(row["AVG_MNGRSCHCKISSNCE_C_AMT"]),
        //                TotalMngrschckissnceCCnt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_C_CNT"]),
        //                MaxMngrschckissnceCAmt = Convert.ToDecimal(row["MAX_MNGRSCHCKISSNCE_C_AMT"]),
        //                MinMngrschckissnceCAmt = Convert.ToDecimal(row["MIN_MNGRSCHCKISSNCE_C_AMT"]),
        //                TotalMngrschckissnceCAmt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_C_AMT"]),
        //                MaxMngrschckissnceDAmt = Convert.ToDecimal(row["MAX_MNGRSCHCKISSNCE_D_AMT"]),
        //                TotalMngrschckissnceDAmt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_D_AMT"]),
        //                MinMngrschckissnceDAmt = Convert.ToDecimal(row["MIN_MNGRSCHCKISSNCE_D_AMT"]),
        //                TotalMngrschckissnceDCnt = Convert.ToDecimal(row["TOTAL_MNGRSCHCKISSNCE_D_CNT"]),
        //                AvgMngrschckissnceDAmt = Convert.ToDecimal(row["AVG_MNGRSCHCKISSNCE_D_AMT"]),
        //                TotalMiscCCnt = Convert.ToDecimal(row["TOTAL_MISC_C_CNT"]),
        //                AvgMiscCAmt = Convert.ToDecimal(row["AVG_MISC_C_AMT"]),
        //                TotalMiscCAmt = Convert.ToDecimal(row["TOTAL_MISC_C_AMT"]),
        //                MinMiscCAmt = Convert.ToDecimal(row["MIN_MISC_C_AMT"]),
        //                MaxMiscCAmt = Convert.ToDecimal(row["MAX_MISC_C_AMT"]),
        //                TotalMiscDAmt = Convert.ToDecimal(row["TOTAL_MISC_D_AMT"]),
        //                AvgMiscDAmt = Convert.ToDecimal(row["AVG_MISC_D_AMT"]),
        //                MaxMiscDAmt = Convert.ToDecimal(row["MAX_MISC_D_AMT"]),
        //                MinMiscDAmt = Convert.ToDecimal(row["MIN_MISC_D_AMT"]),
        //                TotalMiscDCnt = Convert.ToDecimal(row["TOTAL_MISC_D_CNT"]),
        //                AvgOutwrdchqrtrnDAmt = Convert.ToDecimal(row["AVG_OUTWRDCHQRTRN_D_AMT"]),
        //                TotalOutwrdchqrtrnDCnt = Convert.ToDecimal(row["TOTAL_OUTWRDCHQRTRN_D_CNT"]),
        //                TotalOutwrdchqrtrnDAmt = Convert.ToDecimal(row["TOTAL_OUTWRDCHQRTRN_D_AMT"]),
        //                MinOutwrdchqrtrnDAmt = Convert.ToDecimal(row["MIN_OUTWRDCHQRTRN_D_AMT"]),
        //                MaxOutwrdchqrtrnDAmt = Convert.ToDecimal(row["MAX_OUTWRDCHQRTRN_D_AMT"]),
        //                AvgPymntofinstllmntDAmt = Convert.ToDecimal(row["AVG_PYMNTOFINSTLLMNT_D_AMT"]),
        //                TotalPymntofinstllmntDCnt = Convert.ToDecimal(row["TOTAL_PYMNTOFINSTLLMNT_D_CNT"]),
        //                TotalPymntofinstllmntDAmt = Convert.ToDecimal(row["TOTAL_PYMNTOFINSTLLMNT_D_AMT"]),
        //                MinPymntofinstllmntDAmt = Convert.ToDecimal(row["MIN_PYMNTOFINSTLLMNT_D_AMT"]),
        //                MaxPymntofinstllmntDAmt = Convert.ToDecimal(row["MAX_PYMNTOFINSTLLMNT_D_AMT"]),
        //                AvgReturnedwiresDAmt = Convert.ToDecimal(row["AVG_RETURNEDWIRES_D_AMT"]),
        //                MaxReturnedwiresDAmt = Convert.ToDecimal(row["MAX_RETURNEDWIRES_D_AMT"]),
        //                TotalReturnedwiresDAmt = Convert.ToDecimal(row["TOTAL_RETURNEDWIRES_D_AMT"]),
        //                MinReturnedwiresDAmt = Convert.ToDecimal(row["MIN_RETURNEDWIRES_D_AMT"]),
        //                TotalReturnedwiresDCnt = Convert.ToDecimal(row["TOTAL_RETURNEDWIRES_D_CNT"]),
        //                MaxReturnchequeCAmt = Convert.ToDecimal(row["MAX_RETURNCHEQUE_C_AMT"]),
        //                TotalReturnchequeCAmt = Convert.ToDecimal(row["TOTAL_RETURNCHEQUE_C_AMT"]),
        //                TotalReturnchequeCCnt = Convert.ToDecimal(row["TOTAL_RETURNCHEQUE_C_CNT"]),
        //                MinReturnchequeCAmt = Convert.ToDecimal(row["MIN_RETURNCHEQUE_C_AMT"]),
        //                AvgReturnchequeCAmt = Convert.ToDecimal(row["AVG_RETURNCHEQUE_C_AMT"]),
        //                TotalSalarycreditCAmt = Convert.ToDecimal(row["TOTAL_SALARYCREDIT_C_AMT"]),
        //                TotalSalarycreditCCnt = Convert.ToDecimal(row["TOTAL_SALARYCREDIT_C_CNT"]),
        //                MinSalarycreditCAmt = Convert.ToDecimal(row["MIN_SALARYCREDIT_C_AMT"]),
        //                AvgSalarycreditCAmt = Convert.ToDecimal(row["AVG_SALARYCREDIT_C_AMT"]),
        //                MaxSalarycreditCAmt = Convert.ToDecimal(row["MAX_SALARYCREDIT_C_AMT"]),
        //                AvgSalarydebitDAmt = Convert.ToDecimal(row["AVG_SALARYDEBIT_D_AMT"]),
        //                TotalSalarydebitDAmt = Convert.ToDecimal(row["TOTAL_SALARYDEBIT_D_AMT"]),
        //                TotalSalarydebitDCnt = Convert.ToDecimal(row["TOTAL_SALARYDEBIT_D_CNT"]),
        //                MinSalarydebitDAmt = Convert.ToDecimal(row["MIN_SALARYDEBIT_D_AMT"]),
        //                MaxSalarydebitDAmt = Convert.ToDecimal(row["MAX_SALARYDEBIT_D_AMT"]),
        //                TotalSecuritiesCCnt = Convert.ToDecimal(row["TOTAL_SECURITIES_C_CNT"]),
        //                AvgSecuritiesCAmt = Convert.ToDecimal(row["AVG_SECURITIES_C_AMT"]),
        //                MaxSecuritiesCAmt = Convert.ToDecimal(row["MAX_SECURITIES_C_AMT"]),
        //                TotalSecuritiesCAmt = Convert.ToDecimal(row["TOTAL_SECURITIES_C_AMT"]),
        //                MinSecuritiesCAmt = Convert.ToDecimal(row["MIN_SECURITIES_C_AMT"]),
        //                MaxSecuritiesDAmt = Convert.ToDecimal(row["MAX_SECURITIES_D_AMT"]),
        //                MinSecuritiesDAmt = Convert.ToDecimal(row["MIN_SECURITIES_D_AMT"]),
        //                AvgSecuritiesDAmt = Convert.ToDecimal(row["AVG_SECURITIES_D_AMT"]),
        //                TotalSecuritiesDAmt = Convert.ToDecimal(row["TOTAL_SECURITIES_D_AMT"]),
        //                TotalSecuritiesDCnt = Convert.ToDecimal(row["TOTAL_SECURITIES_D_CNT"]),
        //                MaxSellsecurityDAmt = Convert.ToDecimal(row["MAX_SELLSECURITY_D_AMT"]),
        //                AvgSellsecurityDAmt = Convert.ToDecimal(row["AVG_SELLSECURITY_D_AMT"]),
        //                TotalSellsecurityDAmt = Convert.ToDecimal(row["TOTAL_SELLSECURITY_D_AMT"]),
        //                TotalSellsecurityDCnt = Convert.ToDecimal(row["TOTAL_SELLSECURITY_D_CNT"]),
        //                MinSellsecurityDAmt = Convert.ToDecimal(row["MIN_SELLSECURITY_D_AMT"]),
        //                TotalTdredemptionCAmt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_C_AMT"]),
        //                TotalTdredemptionCCnt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_C_CNT"]),
        //                MinTdredemptionCAmt = Convert.ToDecimal(row["MIN_TDREDEMPTION_C_AMT"]),

        //                AvgTdredemptionCAmt = Convert.ToDecimal(row["AVG_TDREDEMPTION_C_AMT"]),
        //                MaxTdredemptionCAmt = Convert.ToDecimal(row["MAX_TDREDEMPTION_C_AMT"]),
        //                AvgTdredemptionDAmt = Convert.ToDecimal(row["AVG_TDREDEMPTION_D_AMT"]),
        //                TotalTdredemptionDAmt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_D_AMT"]),
        //                TotalTdredemptionDCnt = Convert.ToDecimal(row["TOTAL_TDREDEMPTION_D_CNT"]),
        //                MinTdredemptionDAmt = Convert.ToDecimal(row["MIN_TDREDEMPTION_D_AMT"]),
        //                MaxTdredemptionDAmt = Convert.ToDecimal(row["MAX_TDREDEMPTION_D_AMT"]),
        //                TotalTermdepositCCnt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_C_CNT"]),
        //                AvgTermdepositCAmt = Convert.ToDecimal(row["AVG_TERMDEPOSIT_C_AMT"]),
        //                MaxTermdepositCAmt = Convert.ToDecimal(row["MAX_TERMDEPOSIT_C_AMT"]),
        //                TotalTermdepositCAmt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_C_AMT"]),
        //                MinTermdepositCAmt = Convert.ToDecimal(row["MIN_TERMDEPOSIT_C_AMT"]),
        //                MaxTermdepositDAmt = Convert.ToDecimal(row["MAX_TERMDEPOSIT_D_AMT"]),
        //                MinTermdepositDAmt = Convert.ToDecimal(row["MIN_TERMDEPOSIT_D_AMT"]),
        //                AvgTermdepositDAmt = Convert.ToDecimal(row["AVG_TERMDEPOSIT_D_AMT"]),
        //                TotalTermdepositDAmt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_D_AMT"]),
        //                TotalTermdepositDCnt = Convert.ToDecimal(row["TOTAL_TERMDEPOSIT_D_CNT"]),
        //                MaxTtissuanceDAmt = Convert.ToDecimal(row["MAX_TTISSUANCE_D_AMT"]),
        //                AvgTtissuanceDAmt = Convert.ToDecimal(row["AVG_TTISSUANCE_D_AMT"]),
        //                TotalTtissuanceDAmt = Convert.ToDecimal(row["TOTAL_TTISSUANCE_D_AMT"]),
        //                TotalTtissuanceDCnt = Convert.ToDecimal(row["TOTAL_TTISSUANCE_D_CNT"]),
        //                MinTtissuanceDAmt = Convert.ToDecimal(row["MIN_TTISSUANCE_D_AMT"]),
        //                MaxMls = Convert.ToDecimal(row["MAX_MLS"]),
        //                AlertsCnt = Convert.ToDecimal(row["ALERTS_CNT"]),
        //                Segment = (string)row["segment"].ToString() ?? "0",
        //                SegmentSorted = (string)row["segment_sorted"].ToString() ?? "0"




        //            });
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine($"Error {e.Message.ToString()}");
        //        }




















        //    }
        //    fcfcore.MebSegmentsV3Bks.AddRange(segments);
        //    fcfcore.SaveChanges();
        //    //}


        //    //fcfcore.MebSegmentsV3s = dt;

        //    return Content(JsonConvert.SerializeObject(Ok(new { result = "Successs" })), "application/json");

        //}


    }
}
