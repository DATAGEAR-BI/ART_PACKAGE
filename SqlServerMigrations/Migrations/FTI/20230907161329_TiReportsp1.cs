using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.FTI
{
    public partial class TiReportsp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            //ART_CASES_INITIATED_FROM_BRANCH
            migrationBuilder.Sql($@"CREATE OR ALTER VIEW [ART_DB].[ART_CASES_INITIATED_FROM_BRANCH] AS
                               select cl.case_id ECM_REFERENCE, 
                                cl.behalfOfBranch BRANCH_ID,
                                cl.Create_Date CASE_CREATION_DATE, cl.APPLICANTNAME CUSTOMER_NAME,
                                CL.transaction_amount AMOUNT, CL.transaction_currency CURRENCY,
                                CL.primary_owner PRIMARY_OWNER, cs.Val_Desc CASE_STATUS,
                                CL.Update_User_Id LAST_ACTION_TOKEN_BY
                                ,prod.Val_Desc PRODUCT,
                                prod_type.Val_Desc PRODUCT_TYPE,
                                EV.Val_Desc EVENT_NAME,
                                applicantId APPLICANT_ID,
                                expiryDate EXPIRY_DATE,
                                beneficiaryName BENEFICIARY_NAME
                                from DGECM.DGCmgmt.case_live cl
                                left join DGECM.DGCmgmt.Ref_Table_Val prod on cl.product = prod.Val_Cd and prod.Ref_Table_Name='ABK_FTI_PRODUCT'
                                left join DGECM.DGCmgmt.Ref_Table_Val prod_type on cl.productType = prod_type.Val_Cd and prod_type.Ref_Table_Name='ABK_FTI_PRODUCT_TYPE'
                                left join DGECM.DGCmgmt.Ref_Table_Val EV on cl.eventName = EV.Val_Cd and EV.Ref_Table_Name='FTI_EVENT'
                                left join DGECM.DGCmgmt.Ref_Table_Val cs on cl.Case_Stat_Cd = cs.Val_Cd and cs.Ref_Table_Name='RT_CASE_STATUS'");
            //ART_DGECM_ACTIVITIES
            migrationBuilder.Sql($@"CREATE OR ALTER VIEW [ART_DB].[ART_DGECM_ACTIVITIES] AS
                                      select cl.case_id ECM_REFERENCE, 
                                        cl.behalfOfBranch BRANCH_ID,
                                        cl.Create_Date CASE_CREATION_DATE, cl.APPLICANTNAME CUSTOMER_NAME,
                                        CL.transaction_amount AMOUNT, CL.transaction_currency CURRENCY,
                                        CL.primary_owner PRIMARY_OWNER, cs.Val_Desc CASE_STATUS,
                                        COMMENTS.DESCRIPTION CASE_COMMENTS
                                        ,prod.Val_Desc PRODUCT,
                                        prod_type.Val_Desc PRODUCT_TYPE,
                                        EV.Val_Desc EVENT_NAME,
                                        REFERENCE,
                                        ParentCaseId PARENT_CASE_ID
                                        from DGECM.DGCmgmt.case_live cl
                                        left join DGECM.DGCmgmt.Ref_Table_Val prod on cl.product = prod.Val_Cd and prod.Ref_Table_Name='ABK_FTI_PRODUCT'
                                        left join DGECM.DGCmgmt.Ref_Table_Val prod_type on cl.productType = prod_type.Val_Cd and prod_type.Ref_Table_Name='ABK_FTI_PRODUCT_TYPE'
                                        left join DGECM.DGCmgmt.Ref_Table_Val EV on cl.eventName = EV.Val_Cd and EV.Ref_Table_Name='FTI_EVENT'
                                        left join DGECM_METADATA.DGECM_METADATA.COMMENTS COMMENTS on cl.Case_Rk = COMMENTS.ENTITY_RK 
                                        left join DGECM.DGCmgmt.Ref_Table_Val cs on cl.Case_Stat_Cd = cs.Val_Cd and cs.Ref_Table_Name='RT_CASE_STATUS'");
            //ART_ECM_FTI_FULL_CYCLE
            migrationBuilder.Sql($@"CREATE OR ALTER VIEW [ART_DB].[ART_ECM_FTI_FULL_CYCLE] AS
                            select 
                                        cl.case_id ECM_REFERENCE, 
                                        cl.Create_Date CASE_CREATION_DATE, 
                                        cl.behalfOfBranch BRANCH_ID,
                                        cl.APPLICANTNAME CUSTOMER_NAME,
                                        prod.Val_Desc PRODUCT,
                                        prod_type.Val_Desc PRODUCT_TYPE,
                                        EV.Val_Desc NAME,
                                        CL.transaction_amount AMOUNT, 
                                        CL.transaction_currency CURRENCY,
                                        CL.primary_owner PRIMARY_OWNER, 
                                        cs.Val_Desc CASE_STATUS,
                                        CL.Update_User_Id LAST_ACTION_TOKEN_BY,
                                        mstr.master_ref FTI_REFERENCE,
                                        evname.longna85 Event_Name,
                                        (case when Baseevent.STATUS ='i' then 'In progress' 
                                        when Baseevent.STATUS ='c' then 'Completed'
                                        when Baseevent.STATUS ='a' then 'Aborted'
                                        end) Event_Status,
                                        baseevent.start_date EVENT_CREATION_DATE,
                                        evstp.ASSNTOUNME Master_Assigned_To,
                                        (case
                                        when evstp.type='x' then 'Abort'
                                        when evstp.type='a1' then 'Review'
                                        when evstp.type='a2' then 'Final review'
                                        when evstp.type='c' then 'Create'
                                        when evstp.type='i' then 'Input'
                                        when evstp.type='l' then 'Log'
                                        when evstp.type='r' then 'Release'
                                        when evstp.type='-' then 'Complete'
                                        when evstp.type='c1' then 'Limit check'
                                        when evstp.type='c2' then 'Final limit check'
                                        when evstp.type='g' then 'Gateway'
                                        when evstp.type='s' then 'SWIFT In'
                                        when evstp.type='rf' then 'Rate fixing'
                                        when evstp.type='a%' then '*Review/Final review*'
                                        when evstp.type='ra' then 'Fix auth'
                                        when evstp.type='m' then 'Limit approval'
                                        when evstp.type='fp' then 'Print'
                                        when evstp.type='w' then 'Watch list check'
                                        when evstp.type='rp' then 'Release pending'
                                        when evstp.type='pr' then 'Post release'
                                        when evstp.type='ie' then 'Exchange'
                                        when evstp.type='er' then 'External review'
                                        when evstp.type='in' then 'Internal'
                                        when evstp.type='sy' then 'Synchronisation'
                                        when evstp.type='b' then 'Batch'
                                        when evstp.type='gi' then 'Gwy auto input'
                                        when evstp.type='bi' then 'EoD auto input'
                                        when evstp.type='ci' then 'Int auto input'
                                        when evstp.type='si' then 'Swft auto input'
                                        when evstp.type='ar' then 'Auto reject'
                                        end
                                        )Event_Steps,
                                        (case
                                        when evstp.STATUS ='i' then 'Initiated'
                                        when evstp.STATUS ='d' then 'Assigned'
                                        when evstp.STATUS ='p' then 'Pended'
                                        when evstp.STATUS ='w' then 'Awaiting'
                                        when evstp.STATUS ='r' then 'Requested'
                                        when evstp.STATUS ='q' then 'Received'
                                        when evstp.STATUS ='j' then 'Rejected'
                                        when evstp.STATUS ='t' then 'Returned'
                                        when evstp.STATUS ='a' then 'Aborted'
                                        when evstp.STATUS ='c' then 'Completed'
                                        end
                                        ) STEP_STATUS,
                                        STARTDTIME STARTED_TIME ,
                                        LSTMODTIME LAST_MOD_TIME,
                                        LSTMODUSER LAST_MOD_USER

                                        /*The are 2 columns will be available on a popup window 
                                        ECM Comments
                                        Master Note
                                        */

                                        from DGECM.DGCmgmt.case_live cl
                                        left join DGECM.DGCmgmt.Ref_Table_Val prod on cl.product = prod.Val_Cd and prod.Ref_Table_Name='ABK_FTI_PRODUCT'
                                        left join DGECM.DGCmgmt.Ref_Table_Val prod_type on cl.productType = prod_type.Val_Cd and prod_type.Ref_Table_Name='ABK_FTI_PRODUCT_TYPE'
                                        left join DGECM.DGCmgmt.Ref_Table_Val EV on cl.eventName = EV.Val_Cd and EV.Ref_Table_Name='FTI_EVENT'
                                        left join DGECM.DGCmgmt.Ref_Table_Val cs on cl.Case_Stat_Cd = cs.Val_Cd and cs.Ref_Table_Name='RT_CASE_STATUS'
                                        --left join DGECM_METADATA.COMMENTS comm on CL.case_rk=comm.entity_rk
                                        left join tizone1.extevent ext on cl.case_id COLLATE Arabic_CI_AS =trim(ext.ecm_ref)
                                        left join tizone1.Baseevent on Baseevent.key97 = ext.event
                                        left join tizone1.master mstr on Baseevent.master_key = mstr.key97
                                        left join tizone1.EXEMPL30 evname on mstr.exemplar = evname.key97
                                        left join tizone1.EVENTSTEP evstp on BASEEVENT.KEY97=evstp.EVENT_KEY");
            //ART_FTI_ACTIVITIES
            migrationBuilder.Sql($@"CREATE OR ALTER VIEW [ART_DB].[ART_FTI_ACTIVITIES] as
                                    select 
                                        Mstr.MASTER_REF FTI_REFERENCE, 
                                        product.longna85 PRODUCT,
                                        evname.longna85 EVENT_NAME,
                                        (case when Baseevent.STATUS ='i' then 'In progress' 
                                        when Baseevent.STATUS ='c' then 'Completed'
                                        when Baseevent.STATUS ='a' then 'Aborted'
                                        end) Event_Status,
                                        baseevent.start_date EVENT_CREATION_DATE,
                                        evstp.ASSNTOUNME Master_Assigned_To,
                                        (case
                                        when evstp.type='x' then 'Abort'
                                        when evstp.type='a1' then 'Review'
                                        when evstp.type='a2' then 'Final review'
                                        when evstp.type='c' then 'Create'
                                        when evstp.type='i' then 'Input'
                                        when evstp.type='l' then 'Log'
                                        when evstp.type='r' then 'Release'
                                        when evstp.type='-' then 'Complete'
                                        when evstp.type='c1' then 'Limit check'
                                        when evstp.type='c2' then 'Final limit check'
                                        when evstp.type='g' then 'Gateway'
                                        when evstp.type='s' then 'SWIFT In'
                                        when evstp.type='rf' then 'Rate fixing'
                                        when evstp.type='a%' then '*Review/Final review*'
                                        when evstp.type='ra' then 'Fix auth'
                                        when evstp.type='m' then 'Limit approval'
                                        when evstp.type='fp' then 'Print'
                                        when evstp.type='w' then 'Watch list check'
                                        when evstp.type='rp' then 'Release pending'
                                        when evstp.type='pr' then 'Post release'
                                        when evstp.type='ie' then 'Exchange'
                                        when evstp.type='er' then 'External review'
                                        when evstp.type='in' then 'Internal'
                                        when evstp.type='sy' then 'Synchronisation'
                                        when evstp.type='b' then 'Batch'
                                        when evstp.type='gi' then 'Gwy auto input'
                                        when evstp.type='bi' then 'EoD auto input'
                                        when evstp.type='ci' then 'Int auto input'
                                        when evstp.type='si' then 'Swft auto input'
                                        when evstp.type='ar' then 'Auto reject'
                                        end
                                        )Event_Steps,
                                        (case
                                        when evstp.STATUS ='i' then 'Initiated'
                                        when evstp.STATUS ='d' then 'Assigned'
                                        when evstp.STATUS ='p' then 'Pended'
                                        when evstp.STATUS ='w' then 'Awaiting'
                                        when evstp.STATUS ='r' then 'Requested'
                                        when evstp.STATUS ='q' then 'Received'
                                        when evstp.STATUS ='j' then 'Rejected'
                                        when evstp.STATUS ='t' then 'Returned'
                                        when evstp.STATUS ='a' then 'Aborted'
                                        when evstp.STATUS ='c' then 'Completed'
                                        end
                                        ) STEP_STATUS,
                                        ext.ecm_ref ECM_REFERENCE
                                        from
                                        tizone1.master Mstr
                                        left join tizone1.EXEMPL30 product on mstr.exemplar = product.key97
                                        left join tizone1.Baseevent on Baseevent.master_key = mstr.key97
                                         join tizone1.EXEMPL30 evname on Baseevent.exemplar = evname.key97
                                        left join tizone1.EVENTSTEP evstp on BASEEVENT.KEY97=evstp.EVENT_KEY

                                        left join tizone1.extevent ext on Baseevent.key97 = ext.event");
            //ART_FTI_ECM_TRANSACTIONS
            migrationBuilder.Sql($@"CREATE OR ALTER VIEW [ART_DB].[ART_FTI_ECM_TRANSACTIONS] AS
                        SELECT 
                        CL.Case_Id ECM_REFERENCE,
                        prod.val_desc PRODUCT,
                        prodtype.val_desc PRODUCTTYPE,
                        mstr.master_ref FTI_REFERENCE,
                        evname.longna85 Event_Name,
                        (case when Baseevent.STATUS ='i' then 'In progress' 
                        when Baseevent.STATUS ='c' then 'Completed'
                        when Baseevent.STATUS ='a' then 'Aborted'
                        end) Event_Status,
                        baseevent.start_date EVENT_CREATION_DATE,
                        transaction_amount , 
                        transaction_currency,
                        exteve.ECMGROUP FIRST_LINE_PARTY,
                        --exteve.ECMREF ECM_REFERENCE,
                        exteve.FTIINST TRADE_INSTRUCTIONS,
                        exteve.ECMINST FIRST_LINE_INSTRUCTIONS

                        FROM
                        DGECM.dgcmgmt.case_live cl
                        left join DGECM.dgcmgmt.ref_table_val prod on cl.product=prod.val_cd
                        left join DGECM.dgcmgmt.ref_table_val prodtype on cl.producttype=prodtype.val_cd
                        left join DGECM.dgcmgmt.ref_table_val event on cl.eventname=event.val_cd
                        left join TIZONE1.extevent ext on cl.case_id COLLATE Arabic_CI_AS =trim(ext.ecm_ref)
                        left join TIZONE1.Baseevent on Baseevent.key97 = ext.event
                        left join TIZONE1.master mstr on Baseevent.master_key = mstr.key97
                        left join TIZONE1.EXEMPL30 evname on mstr.exemplar = evname.key97
                        left join TIZONE1.EXTEVENTECM exteve on Baseevent.EXTFIELD = exteve.fk_event");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
